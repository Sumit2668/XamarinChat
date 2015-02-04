using XamarinChat.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace XamarinChat
{
	/// <summary>
	/// Connect view model.
	/// </summary>
	public class ConnectViewModel : ViewModel
	{
		/// <summary>
		/// Occurs when connected.
		/// </summary>
		public event EventHandler Connected;

		string _name;

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get
			{ 
				return _name;
			}
			set
			{ 
				if(_name != value)
				{
					_name = value;
					OnPropertyChanged("Name");
					CanConnect = !string.IsNullOrEmpty(_name);
				}

			}
		}

		bool _canConnect;

		/// <summary>
		/// Gets or sets a value indicating whether this instance can connect.
		/// </summary>
		/// <value><c>true</c> if this instance can connect; otherwise, <c>false</c>.</value>
		public bool CanConnect
		{
			get
			{ 
				return _canConnect;
			}
			set
			{
				if(_canConnect != value)
				{
					_canConnect = value;
					OnPropertyChanged("CanConnect");
				}
			}
		}

		/// <summary>
		/// Gets the connect command.
		/// </summary>
		/// <value>The connect command.</value>
		public ICommand ConnectCommand { get; private set; }

		/// <summary>
		/// Gets or sets the chat service.
		/// </summary>
		/// <value>The chat service.</value>
		IChatService ChatService { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinChat.ConnectViewModel"/> class.
		/// </summary>
		/// <param name="chatService">Chat service.</param>
		public ConnectViewModel(IChatService chatService)
		{
			ChatService = chatService;
			ConnectCommand = new Command(async nothing => {
				await ChatService.Connect();
				await ChatService.NewClient(new XamarinChat.Models.Client { Name = Name });
				OnConnected();
			}, nothing => CanConnect);
		}

		/// <summary>
		/// Raises the connected event.
		/// </summary>
		protected void OnConnected()
		{
			var tmp = Connected;
			if(tmp != null)
				tmp(this, EventArgs.Empty);
		}
	}
}


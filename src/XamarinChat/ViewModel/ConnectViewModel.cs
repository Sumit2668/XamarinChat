using XamarinChat.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinChat
{
	/// <summary>
	/// Connect view model.
	/// </summary>
	public class ConnectViewModel : ViewModel
	{
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
		}
	}
}


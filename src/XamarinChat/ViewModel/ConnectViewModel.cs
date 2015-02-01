using XamarinChat.Services;
using GalaSoft.MvvmLight;
using XamarinChat.Services.Implements;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinChat
{
	/// <summary>
	/// Connect view model.
	/// </summary>
	public class ConnectViewModel : ViewModelBase
	{
		string _clientName;

		public string ClientName
		{
			get
			{ 
				return _clientName;
			}
			set
			{ 
				_clientName = value;
				CanConnect = !string.IsNullOrEmpty(_clientName);
			}
		}

		bool _canConnect = false;

		public bool CanConnect
		{
			get 
			{ 
				return _canConnect;
			}
			set 
			{ 
				if(Set(() => CanConnect, ref _canConnect, value))
				{
					RaisePropertyChanged(() => CanConnect);
				}
			}
		}

		private bool _showSpinner;

		public bool ShowSpinner 
		{ 
			get 
			{ 
				return _showSpinner; 
			} 
			set 
			{ 
				if(Set(() => ShowSpinner, ref _showSpinner, value))
				{
					RaisePropertyChanged(() => ShowSpinner);
				}
			}
		}

		/// <summary>
		/// Gets the IncrementCommand.
		/// </summary>
		public ICommand ConnectCommand
		{
			get
			{
				return new RelayCommand(ConnectAsync);
			}
		}

		/// <summary>
		/// Connect.
		/// </summary>
		async void ConnectAsync()
		{
			CanConnect = false;
			await ChatService.Connect();
			await ChatService.NewClient(new XamarinChat.Models.Client { Name = ClientName });
			CanConnect = true;
		}

		/// <summary>
		/// Gets or sets the chat service.
		/// </summary>
		/// <value>The chat service.</value>
		public IChatService ChatService { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinChat.ConnectViewModel"/> class.
		/// </summary>
		public ConnectViewModel()
		{
			ChatService = new ChatService();
		}
	}
}


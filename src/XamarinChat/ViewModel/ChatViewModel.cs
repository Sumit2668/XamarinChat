using System;
using XamarinChat.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinChat
{
	/// <summary>
	/// Chat view model.
	/// </summary>
	public class ChatViewModel : ViewModel
	{
		string _message;

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message
		{
			get
			{ 
				return _message;
			}
			set 
			{
				if(_message != value)
				{
					_message = value;
					OnPropertyChanged("Message");
					CanSend = !string.IsNullOrEmpty(_message);
				}
			}
		}

		bool _canSend;

		/// <summary>
		/// Gets or sets a value indicating whether this instance can send.
		/// </summary>
		/// <value><c>true</c> if this instance can send; otherwise, <c>false</c>.</value>
		public bool CanSend
		{
			get
			{ 
				return _canSend;
			}
			set
			{
				if(_canSend != value)
				{
					_canSend = value;
					OnPropertyChanged("CanSend");
				}
			}
		}

		/// <summary>
		/// Gets the send command.
		/// </summary>
		/// <value>The send command.</value>
		public ICommand SendCommand { get; private set; }

		/// <summary>
		/// Gets or sets the chat service.
		/// </summary>
		/// <value>The chat service.</value>
		IChatService ChatService { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinChat.ChatViewModel"/> class.
		/// </summary>
		/// <param name="chatService">Chat service.</param>
		public ChatViewModel(IChatService chatService)
		{
			ChatService = chatService;
			SendCommand = new Command( async nothing => await ChatService.Send(new XamarinChat.Models.ClientMessage{ Client = new XamarinChat.Models.Client { Name = "Test" }, Message = Message }), nothing => CanSend);
		}
	}
}


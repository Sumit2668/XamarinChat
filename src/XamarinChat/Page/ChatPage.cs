using Xamarin.Forms;

namespace XamarinChat
{
	/// <summary>
	/// Chat page.
	/// </summary>
	public sealed class ChatPage : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinChat.ChatPage"/> class.
		/// </summary>
		public ChatPage()
		{
			InitializeComponent();
			ShowConnect();
		}

		/// <summary>
		/// Shows the connect page.
		/// </summary>
		async void ShowConnect()
		{
			var page = new ConnectPage();
			page.Closed += (object sender, string e) => Bind(e);
			await Navigation.PushModalAsync(page);
		}

		/// <summary>
		/// Initializes the component.
		/// </summary>
		void InitializeComponent()
		{
			var layout = new StackLayout();

			var label = new Label 
			{ 
				Text = "Chat"
			};

			var textBox = new Entry 
			{
				Placeholder = "Message",
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.Center
			};
			textBox.SetBinding <ChatViewModel>(Entry.TextProperty, vm => vm.Message);

			var button = new Button 
			{ 
				Text = "Envoyé",
				HorizontalOptions =LayoutOptions.Center
			};
			button.SetBinding<ChatViewModel>(VisualElement.IsEnabledProperty, vm => vm.CanSend);
			button.SetBinding<ChatViewModel>(Button.CommandProperty, vm => vm.SendCommand);

			var listView = new ListView();
			listView.SetBinding<ChatViewModel>(ListView.ItemsSourceProperty, vm => vm.Messages);

			layout.Children.Add(label);
			layout.Children.Add(textBox);
			layout.Children.Add(button);
			layout.Children.Add(listView);

			Content = layout;
		}

		/// <summary>
		/// Bind ViewModel.
		/// </summary>
		/// <param name="name">Name.</param>
		void Bind(string name)
		{
			var viewModel = ViewModelFactory.Get<ChatViewModel>();
			viewModel.Name = name;
			viewModel.InitializeEvents();
			BindingContext = viewModel;
		}
	}
}


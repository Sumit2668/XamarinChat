using System;
using Xamarin.Forms;

namespace XamarinChat
{
	/// <summary>
	/// Chat page.
	/// </summary>
	public class ChatPage : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinChat.ChatPage"/> class.
		/// </summary>
		public ChatPage()
		{
			InitializeComponent();
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

			layout.Children.Add(label);
			layout.Children.Add(textBox);
			layout.Children.Add(button);

			Content = layout;

			var viewModel = ViewModelFactory.Get<ChatViewModel>();
			BindingContext = viewModel;
		}
	}
}


using System;
using Xamarin.Forms;

namespace XamarinChat
{
	/// <summary>
	/// Connect page.
	/// </summary>
	public sealed class ConnectPage : ContentPage
	{
		/// <summary>
		/// Occurs when connected.
		/// </summary>
		public event EventHandler<string> Closed;

		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinChat.ConnectPage"/> class.
		/// </summary>
		public ConnectPage()
		{
			InitializeComponent();
			Bind();
		}

		/// <summary>
		/// Initializes the component.
		/// </summary>
		void InitializeComponent()
		{
			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center
			};

			var textBox = new Entry 
			{ 
				Placeholder = "Name",
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.Center
			};
			textBox.SetBinding(Entry.TextProperty, "Name");

			var label = new Label
			{
				XAlign = TextAlignment.Center,
				BindingContext = textBox
			};
			label.SetBinding<Entry>(Label.TextProperty, t => t.Text , BindingMode.Default, null, "Hello {0} !");

			var button = new Button
			{
				VerticalOptions = LayoutOptions.Center,
				Text = "Connect",
				IsEnabled = false
			};
			button.SetBinding<ConnectViewModel>(VisualElement.IsEnabledProperty, vm => vm.CanConnect);
			button.SetBinding<ConnectViewModel>(Button.CommandProperty, vm => vm.ConnectCommand);

			layout.Children.Add(label);
			layout.Children.Add(textBox);
			layout.Children.Add(button);
			Content = layout;
		}

		/// <summary>
		/// Bind ViewModel.
		/// </summary>
		void Bind()
		{
			var viewModel = ViewModelFactory.Get<ConnectViewModel>();
			viewModel.Connected += async (sender, e) => {
				await DisplayAlert("Connexion", string.Format("Bienvenu sur le chat {0}", viewModel.Name), "OK");
				await Navigation.PopModalAsync();
				OnClosed(viewModel.Name);
			};

			BindingContext = viewModel;
		}

		/// <summary>
		/// Raises the closed event.
		/// </summary>
		/// <param name="name">Name.</param>
		private void OnClosed(string name)
		{
			var tmp = Closed;
			if(tmp != null)
				tmp(this, name);
		}
	}
}


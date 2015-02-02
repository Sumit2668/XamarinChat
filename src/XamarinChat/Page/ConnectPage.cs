using System;
using Xamarin.Forms;

namespace XamarinChat
{
	public class ConnectPage : ContentPage
	{
		public ConnectPage()
		{
			InitializeComponent();
			BindingContext = ViewModelFactory.Get<ConnectViewModel>();
		}

		public void InitializeComponent()
		{
			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center
			};

			var textBox = new Entry 
			{ 
				Placeholder = "Name" 
			};
			textBox.SetBinding(Entry.TextProperty, "ClientName");

			var label = new Label
			{
				XAlign = TextAlignment.Center,
				BindingContext = textBox
			};
			label.SetBinding<Entry>(Label.TextProperty, t => t.Text , BindingMode.Default, null, "Hello {0} !");

			var button = new Button
			{
				VerticalOptions = LayoutOptions.Center,
				Text = "Connect"
			};

			layout.Children.Add(label);
			layout.Children.Add(textBox);
			layout.Children.Add(button);

			Content = layout;
		}
	}
}


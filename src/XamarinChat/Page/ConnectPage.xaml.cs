using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinChat
{
	public partial class ConnectPage : ContentPage
	{
		public ConnectPage()
		{
			BindingContext = ViewModelLocator.Connect;
			InitializeComponent();

		}
	}
}


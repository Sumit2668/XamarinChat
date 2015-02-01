using System;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using XamarinChat.Services;
using XamarinChat.Services.Implements;

namespace XamarinChat
{
	public static class ViewModelLocator
	{
		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<ConnectViewModel>();

			SimpleIoc.Default.Register<IChatService, ChatService>();
		}

		public static ConnectViewModel Connect
		{
			get
			{
				var service = ServiceLocator.Current.GetInstance<IChatService>();
				var viewModel = ServiceLocator.Current.GetInstance<ConnectViewModel>();
				return viewModel;
			}
		}
	}
}


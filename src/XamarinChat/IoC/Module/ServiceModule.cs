using Ninject.Modules;
using XamarinChat.Services;
using XamarinChat.Services.Implements;

namespace XamarinChat
{
	public class ServiceModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IChatService>().To<ChatService>().InSingletonScope();
		}
	}
}


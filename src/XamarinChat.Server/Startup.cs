using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(XamarinChat.Server.Startup))]

namespace XamarinChat.Server
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR();
		}
	}
}


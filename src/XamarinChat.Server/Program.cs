using System;
using Microsoft.Owin.Hosting;
using AutoMapper;
using XamarinChat.Models;

namespace XamarinChat.Server
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Mapper.CreateMap<ClientMessage, ServerMessage>();

			var url = "http://localhost:8080";
			using (WebApp.Start(url))
			{
				Console.WriteLine("Server running on {0}", url);
				Console.ReadLine();
			}
		}
	}
}

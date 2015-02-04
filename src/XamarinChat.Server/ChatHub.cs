using System;
using Newtonsoft.Json;
using XamarinChat.Models;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Microsoft.AspNet.SignalR;

namespace XamarinChat.Server
{
	/// <summary>
	/// Chat hub.
	/// </summary>
	public class ChatHub : Hub
	{
		/// <summary>
		/// Send the specified jsonMessage.
		/// </summary>
		/// <param name="jsonMessage">Json message.</param>
		public void Send(string jsonMessage)
		{
			var clientMessage = JsonConvert.DeserializeObject<ClientMessage>(jsonMessage,new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});

			var serverMessage = Mapper.Map<ServerMessage>(clientMessage);
			serverMessage.ServerDate = DateTime.Now;

			Console.WriteLine(string.Format("{0} - {1}\n{2}", serverMessage.ServerDate.ToShortDateString(), serverMessage.Client.Name, serverMessage.Message));

			Clients.All.broadcastMessage(JsonConvert.SerializeObject(serverMessage, new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			}));
		}

		/// <summary>
		/// New client connect.
		/// </summary>
		/// <param name="jsonMessage">Json message.</param>
		public void NewClient(string jsonMessage)
		{
			var client = JsonConvert.DeserializeObject<Client>(jsonMessage,new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine(string.Format("New client : {0}", client.Name));
			Console.ForegroundColor = ConsoleColor.White;

			Clients.All.broadcastNewClient(jsonMessage);
		}
	}
}


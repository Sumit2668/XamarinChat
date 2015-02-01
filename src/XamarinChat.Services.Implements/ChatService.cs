using System;
using XamarinChat.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XamarinChat.Services.Implements
{
	/// <summary>
	/// Chat service.
	/// </summary>
	public class ChatService : IChatService
	{
		/// <summary>
		/// Gets or sets the connection.
		/// </summary>
		/// <value>The connection.</value>
		HubConnection Connection { get; set; }

		/// <summary>
		/// Gets or sets the proxy.
		/// </summary>
		/// <value>The proxy.</value>
		IHubProxy Proxy { get; set; }

		/// <summary>
		/// Occurs when server message received.
		/// </summary>
		public event EventHandler<ServerMessage> ServerMessageReceived;

		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinChat.Services.Implements.ChatService"/> class.
		/// </summary>
		public ChatService()
		{
			Connection = new HubConnection("http://localhost:8080");
			Proxy = Connection.CreateHubProxy("chatHub");
		}

		/// <summary>
		/// Connect this instance.
		/// </summary>
		public async Task Connect()
		{
			await Connection.Start();

			Proxy.On("broadcastMessage", (string message) =>
			{
				var data = JsonConvert.DeserializeObject<ServerMessage>(message, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
				ServerMessageReceived(this, data);
			});
		}

		/// <summary>
		/// Send the specified message.
		/// </summary>
		/// <param name="message">Message.</param>
		public async Task Send(ClientMessage message)
		{
			var jsonMessage = JsonConvert.SerializeObject(message, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
			await Proxy.Invoke("Send", jsonMessage);
		}

		/// <summary>
		/// Send the client information.
		/// </summary>
		/// <param name="client">Client.</param>
		public async Task NewClient(Client client)
		{
			var jsonMessage = JsonConvert.SerializeObject(client, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

			await Proxy.Invoke("NewClient", jsonMessage);
		}
	}
}


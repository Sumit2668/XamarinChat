using System.Threading.Tasks;
using XamarinChat.Models;
using System;

namespace XamarinChat.Services
{
	/// <summary>
	/// Chat service.
	/// </summary>
	public interface IChatService
	{
		/// <summary>
		/// Connect this instance.
		/// </summary>
		Task Connect();

		/// <summary>
		/// Send the specified message.
		/// </summary>
		/// <param name="message">Message.</param>
		Task Send(ClientMessage message);

		/// <summary>
		/// Send the client information.
		/// </summary>
		/// <param name="client">Client.</param>
		Task NewClient(Client client);

		/// <summary>
		/// Occurs when server message received.
		/// </summary>
		event EventHandler<ServerMessage> ServerMessageReceived;
	}
}


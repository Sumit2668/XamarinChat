using System;

namespace XamarinChat.Models
{
	/// <summary>
	/// Server message.
	/// </summary>
	public class ServerMessage
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public Client Name { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the server date.
		/// </summary>
		/// <value>The server date.</value>
		public DateTime ServerDate { get; set; }
	}
}


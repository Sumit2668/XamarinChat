namespace XamarinChat.Models
{
	/// <summary>
	/// Client message.
	/// </summary>
	public class ClientMessage
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public Client Client { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; set; }
	}
}


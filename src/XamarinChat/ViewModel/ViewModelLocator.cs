namespace XamarinChat
{
	/// <summary>
	/// View model locator.
	/// </summary>
	public static class ViewModelLocator
	{
		public static ConnectViewModel Connect
		{
			get
			{
				return Host.Get<ConnectViewModel>();
			}
		}
	}
}


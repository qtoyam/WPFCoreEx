namespace WPFCoreEx.Abstractions.Services
{
	public interface IMessageService
	{
		public bool TryGetSaveFilePath(out string saveFile, string extension = "", string action = "");

		public bool TryGetFile(out string filePath, string? fileType = null, string[]? extensions = null);

		public bool TryGetFile(out string filePath, string fileType, string extension);

		public void SendSilentMessage(string message);

		public void SendMessage(string message);

		public void SendWarning(string message);

		public void SendError(string message);

		public void SendException(Exception ex);
	}
}

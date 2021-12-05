using System;
using System.Text;
using System.Windows;

using Microsoft.Win32;

using WPFCoreEx.Abstractions.Services;

namespace WPFCoreEx.Services
{
#nullable enable
	public class EventMessageService : IMessageService
	{
		public Window Owner { get; set; } = null!;

		public EventMessageService()
		{

		}

		public void RegisterAllDefault(Window owner)
		{
			Owner = owner;
			MessageReceived = SilentMessageReceived = WarningReceived = ErrorReceived = (msg) => MessageBox.Show(Owner, msg);
			ExceptionReceived = (ex) => MessageBox.Show(Owner, ex.Message);
		}

		public void UnregisterAll()
		{
			SilentMessageReceived = null;
			MessageReceived = null;
			WarningReceived = null;
			ErrorReceived = null;
			ExceptionReceived = null;
			Owner = null!;
		}

		public void SendMessage(string message) => MessageReceived?.Invoke(message);
		public void SendSilentMessage(string message) => SilentMessageReceived?.Invoke(message);
		public void SendWarning(string message) => WarningReceived?.Invoke(message);
		public void SendError(string message) => ErrorReceived?.Invoke(message);
		public void SendException(Exception ex) => ExceptionReceived?.Invoke(ex);

		public event Action<string>? SilentMessageReceived;
		public event Action<string>? MessageReceived;
		public event Action<string>? WarningReceived;
		public event Action<string>? ErrorReceived;
		public event Action<Exception>? ExceptionReceived;

		public bool TryGetFile(out string filePath, string? fileType = null, string[]? extensions = null)
		{
			var openFileDialog = new OpenFileDialog()
			{
				Multiselect = false,
				CheckFileExists = true,
				CheckPathExists = true
			};
			if (fileType != null && extensions != null)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(fileType);
				sb.Append('|');
				foreach (var extension in extensions)
				{
					sb.Append("*.");
					sb.Append(extension);
					sb.Append(';');
				}
				openFileDialog.Filter = sb.ToString();
			}
			if (openFileDialog.ShowDialog(Owner) == true)
			{
				filePath = openFileDialog.FileName;
				return true;
			}
			filePath = string.Empty;
			return false;
		}

		public bool TryGetFile(out string filePath, string fileType, string extension)
		{
			var openFileDialog = new OpenFileDialog()
			{
				Multiselect = false,
				CheckFileExists = true,
				CheckPathExists = true
			};
			StringBuilder sb = new StringBuilder();
			sb.Append(fileType);
			sb.Append("|*.");
			sb.Append(extension);

			openFileDialog.Filter = sb.ToString();
			if (openFileDialog.ShowDialog(Owner) == true)
			{
				filePath = openFileDialog.FileName;
				return true;
			}
			filePath = string.Empty;
			return false;
		}

		public bool TryGetSaveFilePath(out string saveFilePath, string extension = "", string action = "")
		{
			var saveFileDialog = new SaveFileDialog()
			{
				OverwritePrompt = true
			};
			if (!string.IsNullOrEmpty(extension))
			{
				saveFileDialog.DefaultExt = extension;
				saveFileDialog.Filter = $"(*.{extension})|*.{extension}|All files (*.*)|*.*";
			}
			if (!string.IsNullOrEmpty(action))
			{
				saveFileDialog.Title = "Build resource";
			}
			if (saveFileDialog.ShowDialog(Owner) == true)
			{
				saveFilePath = saveFileDialog.FileName;
				return true;
			}
			saveFilePath = string.Empty;
			return false;
		}
	}
}

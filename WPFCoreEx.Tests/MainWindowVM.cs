using Microsoft.Xaml.Behaviors.Core;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using WPFCoreEx.Bases;
using WPFCoreEx.Bases.Commands;
using WPFCoreEx.Commands;

namespace WPFCoreEx.Tests
{
	public class MainWindowVM : ViewModelEx<MainWindowVM>
	{

		public ObservableLinkedList<ItemVM> Items { get; } = new();


		public AsyncCommandEx<string> ShowMessageCommand => CommandManager.TryGetAsyncCommandEx<string>(out var b) ??
			b.Execute(ShowMessageAsync, false)
			.Build();


		async Task ShowMessageAsync(string message)
		{
			await Task.Delay(2000);
			MessageBox.Show(message);
		}
		//public CommandEx ShowMsgCommand =>
		//	CreateCommand()
		//	.Execute(ShowMsg)
		//	.CanExecute(()=> IsRofl && IsKek)
		//	.UpdatesOn(x=>x.)
		//	.Build();

		//public bool IsRofl { get; set; }
		//public bool IsKek { get; set; }

		//public void ShowMsg()
		//{
		//	MessageBox.Show("Test");
		//	Items.Select
		//}
	}
}

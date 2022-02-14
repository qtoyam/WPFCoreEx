using System.ComponentModel;
using System.Runtime.CompilerServices;

using WPFCoreEx.Bases.Commands;

namespace WPFCoreEx.Bases
{
	public abstract class ViewModelEx<VM> : NotifyPropBase, INotifyPropertyChanged
		where VM : ViewModelEx<VM>
	{
		protected CommandManagerVM<VM> CommandManager { get; }

		protected ViewModelEx()
		{
			CommandManager = new((VM)this);
		}

		#region NotifyPropBase
		protected override void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			CommandManager.UpdateCommands(prop);
			base.OnPropertyChanged(prop);
		}
		#endregion //NotifyPropBase
	}
}
using System.Windows.Input;

namespace WPFCoreEx.Abstractions.Commands
{
	public delegate bool CanExecuteFunc();
	public delegate bool CanExecuteFunc<T>(T parameter);

	public interface ICommandUpdatable : ICommand
	{
		void Update();
	}
}

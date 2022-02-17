using System.Windows.Input;

namespace WPFCoreEx.Abstractions.Commands
{
	public delegate bool CanExecuteFunc();
	public delegate bool CanExecuteFunc<T>(T parameter);

	public interface ICommandUpdatable : ICommand
	{
		/// <summary>
		/// Raises <see cref="ICommand.CanExecuteChanged"/> and, if enabled, update cached value of <see cref="ICommand.CanExecute(object?)"/>
		/// </summary>
		void Update();
	}
}

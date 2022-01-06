using System;
using System.Windows.Input;

namespace WPFCoreEx.Bases
{
	public class CommandEx : ICommand
	{
		#region Fields 
		private readonly Action _execute;
		private readonly Func<bool>? _canExecute;
		#endregion //Fields 
		#region Constructors 
		public CommandEx(Action execute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
		}
		public CommandEx(Action execute, Func<bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
		}
		#endregion //Constructors 
		#region ICommand Members 
		public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();
		public void Execute(object? parameter) => _execute();
		public event EventHandler? CanExecuteChanged;
		#endregion //ICommand Members 
		public void Update() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
	}

	public class CommandEx<T> : ICommand
	{
		#region Fields 
		private readonly Action<T> _execute;
		private readonly Func<bool>? _canExecute;
		#endregion //Fields 
		#region Constructors 
		public CommandEx(Action<T> execute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
		}
		public CommandEx(Action<T> execute, Func<bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
		}
		#endregion //Constructors 
		#region ICommand Members 
		public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();
		public void Execute(object? parameter) => _execute((T)parameter!);
		public event EventHandler? CanExecuteChanged;
		#endregion //ICommand Members 
		public void Update() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
	}
}

using System;
using System.Windows.Input;

using WPFCoreEx.Abstractions.Commands;
using WPFCoreEx.Helpers;

namespace WPFCoreEx.Commands
{
	public sealed class CommandEx : ICommandUpdatable
	{
		private readonly Action _execute;
		private readonly CanExecuteFunc _canExecute;

		public CommandEx(Action execute) : this(execute, null) { }
		public CommandEx(Action execute, CanExecuteFunc? canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute ?? DefaultFuncs.True;
		}

		public bool CanExecute() => _canExecute();
		public void Execute() => _execute();

		/// <summary>
		/// Checks <see cref="CanExecute"/>, if true executes command, otherwise false.
		/// </summary>
		/// <returns></returns>
		public bool TryExecute()
		{
			if (!CanExecute())
			{
				return false;
			}
			else
			{
				Execute();
				return true;
			}
		}

		/// <summary>
		/// Tells listeners to recheck <see cref="CanExecute"/>
		/// </summary>
		public void Update() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		#region ICommand
		public event EventHandler? CanExecuteChanged;
		bool ICommand.CanExecute(object? parameter) => CanExecute();
		void ICommand.Execute(object? parameter) => Execute();
		#endregion //ICommand
	}

	public sealed class CommandEx<T> : ICommandUpdatable
	{
		private readonly Action<T?> _execute;
		private readonly CanExecuteFunc<T?> _canExecute;

		public CommandEx(Action<T?> execute) : this(execute, null) { }
		public CommandEx(Action<T?> execute, CanExecuteFunc<T?>? canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute ?? DefaultFuncs<T>.True;
		}

		public bool CanExecute(T? parameter) => _canExecute(parameter);
		public void Execute(T? parameter) => _execute(parameter);

		/// <summary>
		/// Checks <see cref="CanExecute"/>, if true executes command, otherwise false.
		/// </summary>
		/// <returns></returns>
		public bool TryExecute(T? parameter)
		{
			if (!CanExecute(parameter)) return false;
			Execute(parameter);
			return true;
		}

		/// <summary>
		/// Tells listeners to recheck <see cref="CanExecute"/>
		/// </summary>
		public void Update() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		#region ICommand
		public event EventHandler? CanExecuteChanged;
		bool ICommand.CanExecute(object? parameter) => CanExecute((T?)parameter);
		void ICommand.Execute(object? parameter) => Execute((T?)parameter);
		#endregion //ICommand
	}
}

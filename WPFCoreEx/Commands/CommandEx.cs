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
		private bool? _cachedCanExecute;

		public CommandEx(Action execute, bool cacheCanExecute) : this(execute, null, cacheCanExecute) { }
		public CommandEx(Action execute, CanExecuteFunc? canExecute, bool cacheCanExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute ?? DefaultFuncs.True;
			if (cacheCanExecute)
			{
				_cachedCanExecute = _canExecute();
			}
		}

		public bool CanExecute()
		{
			if (_cachedCanExecute.HasValue)
			{
				return _cachedCanExecute.Value;
			}
			else
			{
				return _canExecute();
			}
		}

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

		public void Update()
		{
			if(_cachedCanExecute.HasValue)
			{
				bool oldCanExecute = _cachedCanExecute.Value;
				_cachedCanExecute = _canExecute();
				if (oldCanExecute == _cachedCanExecute.Value) return; //don't changed, so we dont need to raise event
			}
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		#region ICommand
		private event EventHandler? CanExecuteChanged;
		event EventHandler? ICommand.CanExecuteChanged
		{
			add => CanExecuteChanged += value;
			remove => CanExecuteChanged -= value;
		}
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

		public void Update() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		#region ICommand
		private event EventHandler? CanExecuteChanged;
		event EventHandler? ICommand.CanExecuteChanged
		{
			add => CanExecuteChanged += value;
			remove => CanExecuteChanged -= value;
		}
		bool ICommand.CanExecute(object? parameter) => CanExecute((T?)parameter);
		void ICommand.Execute(object? parameter) => Execute((T?)parameter);
		#endregion //ICommand
	}
}

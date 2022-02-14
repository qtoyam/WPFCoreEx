using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using WPFCoreEx.Abstractions.Commands;
using WPFCoreEx.Helpers;

namespace WPFCoreEx.Commands
{
	public class AsyncCommandEx : ICommandUpdatable
	{
		private readonly Func<Task> _execute;
		private readonly CanExecuteFunc _canExecute;

		private bool _isRunning = false;
		public bool IsRunning
		{
			get => _isRunning;
			set
			{
				_isRunning = value;
				Update();
			}
		}

		public AsyncCommandEx(Func<Task> execute) : this(execute, null) { }
		public AsyncCommandEx(Func<Task> execute, CanExecuteFunc? canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute ?? DefaultFuncs.True;
		}

		public bool CanExecute() => !IsRunning && _canExecute();
		public async Task ExecuteAsync()
		{
			IsRunning = true;
			await _execute().ConfigureAwait(false); //idk may fail
			IsRunning = false;
		}

		/// <summary>
		/// Returns <see cref="CanExecute"/>, if true also calls <see cref="ExecuteAsync"/>
		/// </summary>
		/// <returns></returns>
		public bool TryExecute(out Task? executionTask)
		{
			if (!CanExecute())
			{
				executionTask = null;
				return false;
			}
			else
			{
				executionTask = ExecuteAsync();
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
		void ICommand.Execute(object? parameter) => ExecuteAsync().ConfigureAwait(false);
		#endregion //ICommand
	}

	public class AsyncCommandEx<T> : ICommandUpdatable
	{
		private readonly Func<T?, Task> _execute;
		private readonly CanExecuteFunc<T?> _canExecute;
		private bool _isRunning = false;
		public bool IsRunning
		{
			get => _isRunning;
			set
			{
				_isRunning = value;
				Update();
			}
		}

		public AsyncCommandEx(Func<T?, Task> execute) : this(execute, null) { }
		public AsyncCommandEx(Func<T?, Task> execute, CanExecuteFunc<T?>? canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute ?? DefaultFuncs<T>.True;
		}

		public bool CanExecute(T? parameter) => !IsRunning && _canExecute(parameter);
		public async Task ExecuteAsync(T? parameter)
		{
			IsRunning = true;
			await _execute(parameter); //idk may fail
			IsRunning = false;
		}

		/// <summary>
		/// Returns <see cref="CanExecute"/>, if true also calls <see cref="ExecuteAsync"/>
		/// </summary>
		/// <returns></returns>
		public bool TryExecute(T? parameter, out Task? executionTask)
		{
			if (!CanExecute(parameter))
			{
				executionTask = null;
				return false;
			}
			else
			{
				executionTask = ExecuteAsync(parameter);
				return true;
			}
		}

		/// <summary>
		/// Tells listeners to recheck <see cref="CanExecute"/>
		/// </summary>
		public void Update() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		#region ICommand
		public event EventHandler? CanExecuteChanged;
		bool ICommand.CanExecute(object? parameter) => CanExecute((T?)parameter);
		void ICommand.Execute(object? parameter) => ExecuteAsync((T?)parameter).ConfigureAwait(false);
		#endregion //ICommand
	}
}

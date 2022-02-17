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
		private bool? _cachedCanExecute;

		private bool _isRunning = false;
		public bool IsRunning
		{
			get => _isRunning;
			set
			{
				_isRunning = value;
				OnCanExecuteChanged();
			}
		}

		public AsyncCommandEx(Func<Task> execute, bool cacheCanExecute) : this(execute, null, cacheCanExecute) { }
		public AsyncCommandEx(Func<Task> execute, CanExecuteFunc? canExecute, bool cacheCanExecute)
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
			if (IsRunning) return false;
			else
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
		}

		public async Task ExecuteAsync()
		{
			IsRunning = true;
			await _execute().ConfigureAwait(false); //idk may fail
			IsRunning = false;
		}

		/// <summary>
		/// Returns <see cref="CanExecute"/>, if true also calls <see cref="ExecuteAsync"/>
		/// </summary>
		/// <param name="parameter"></param>
		/// <param name="executionTask">
		/// If <see cref="CanExecute"/> returns <see langword="true"/> contains <see cref="Task"/> returned by <see cref="ExecuteAsync"/>
		/// </param>
		/// <returns></returns>
		public bool TryExecute(out Task? executionTask)
		{
			if (CanExecute())
			{
				executionTask = ExecuteAsync();
				return true;
			}
			else
			{
				executionTask = null;
				return false;
			}
		}

		public void Update()
		{
			if (_cachedCanExecute.HasValue)
			{
				bool oldCanExecute = _cachedCanExecute.Value;
				_cachedCanExecute = _canExecute();
				if (oldCanExecute == _cachedCanExecute.Value) return; //don't changed, so we dont need to raise event
			}
			OnCanExecuteChanged();
		}

		private void OnCanExecuteChanged()
		{
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
		void ICommand.Execute(object? parameter) => ExecuteAsync().ConfigureAwait(false); //also idk may fail
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
		/// <param name="parameter"></param>
		/// <param name="executionTask">
		/// If <see cref="CanExecute"/> returns <see langword="true"/> contains <see cref="Task"/> returned by <see cref="ExecuteAsync"/>
		/// </param>
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

		public void Update() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		#region ICommand
		private event EventHandler? CanExecuteChanged;
		event EventHandler? ICommand.CanExecuteChanged
		{
			add => CanExecuteChanged += value;
			remove => CanExecuteChanged -= value;
		}
		bool ICommand.CanExecute(object? parameter) => CanExecute((T?)parameter);
		void ICommand.Execute(object? parameter) => ExecuteAsync((T?)parameter).ConfigureAwait(false); //also idk may fail
		#endregion //ICommand
	}
}

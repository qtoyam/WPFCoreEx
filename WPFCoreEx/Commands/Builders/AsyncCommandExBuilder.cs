using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

using WPFCoreEx.Abstractions.Bases;
using WPFCoreEx.Abstractions.Commands;
using WPFCoreEx.Helpers;

namespace WPFCoreEx.Commands.Builders
{
	public class AsyncCommandExBuilder<VM> : CommandBuilderBase<VM>
		where VM : INotifyPropertyChanged
	{
		private Func<Task>? _executeTask;
		private CanExecuteFunc? _canExecuteFunc;
		private bool _cacheCanExecute = false;

		public AsyncCommandExBuilder(VM viewModel, ICommandRegister commandRegister, string commandName) :
			base(viewModel, commandRegister, commandName)
		{ }

		public AsyncCommandExBuilder<VM> Execute(Func<Task> execute)
		{
			ThrowIfReinit(_executeTask);
			_executeTask = execute;
			return this;
		}

		public AsyncCommandExBuilder<VM> Execute(Func<VM, Task> execute)
		{
			return Execute(new Func<Task>(
				() => execute(ViewModel)
				));
		}

		public AsyncCommandExBuilder<VM> CanExecute(CanExecuteFunc canExecute)
		{
			ThrowIfReinit(_canExecuteFunc);
			_canExecuteFunc = canExecute;
			return this;
		}

		public AsyncCommandExBuilder<VM> CanExecute(CanExecuteFunc<VM> canExecute)
		{
			return CanExecute(new CanExecuteFunc(
				() => canExecute(ViewModel)
				));
		}

		public AsyncCommandExBuilder<VM> CanExecuteObserves(Expression<Func<VM, bool>> property)
		{
			ThrowIfReinit(_canExecuteFunc);
			_canExecuteFunc = RegisterObserver(property);
			return this;
		}

		public AsyncCommandExBuilder<VM> UpdatesOn<P>(Expression<Func<VM, P>> property)
		{
			RegisterUpdater(property);
			return this;
		}

		//public AsyncCommandExBuilder<VM> UpdatesOn(params Expression<Func<VM, P>>[] properties)
		//{
		//	foreach (var property in properties)
		//	{
		//		RegisterUpdater(property);
		//	}
		//	return this;
		//}

		public AsyncCommandExBuilder<VM> CacheCanExecute()
		{
			_cacheCanExecute = true;
			return this;
		}

		public AsyncCommandEx Build()
		{
			AsyncCommandEx command = new(_executeTask!, _canExecuteFunc, _cacheCanExecute); //will throw if _executeTask == null
			CommandRegister.RegisterCommand(CommandName, command, DependentProps);
			return command;
		}
	}

	public class AsyncCommandExBuilder<VM, T> : CommandBuilderBase<VM>
		where VM : INotifyPropertyChanged
	{
		private bool _checkNull = false;

		private Func<T?, Task>? _executeTask;
		private CanExecuteFunc<T?>? _canExecuteFunc;

		public AsyncCommandExBuilder(VM viewModel, ICommandRegister commandRegister, string commandName) :
			base(viewModel, commandRegister, commandName)
		{ }

		public AsyncCommandExBuilder<VM, T> Execute(Func<T?, Task> execute)
		{
			ThrowIfReinit(_executeTask);
			_executeTask = execute;
			return this;
		}

		public AsyncCommandExBuilder<VM, T> Execute(Func<VM, T?, Task> execute)
		{
			return Execute(new Func<T?, Task>(
				parameter => execute(ViewModel, parameter)
				));
		}

		public AsyncCommandExBuilder<VM, T> Execute(Func<T, Task> execute, bool checkNull)
		{
			ThrowIfReinit(_canExecuteFunc);
			_executeTask = execute!;
			_checkNull = checkNull;
			return this;
		}

		public AsyncCommandExBuilder<VM, T> CanExecute(CanExecuteFunc<T?> canExecute)
		{
			ThrowIfReinit(_canExecuteFunc);
			_canExecuteFunc = canExecute;
			return this;
		}

		public AsyncCommandExBuilder<VM, T> CanExecuteObserves(Expression<Func<VM, bool>> property)
		{
			ThrowIfReinit(_canExecuteFunc);
			var compiledFunc = RegisterObserver(property);
			_canExecuteFunc = _ => compiledFunc();
			return this;
		}

		public AsyncCommandExBuilder<VM, T> UpdatesOn<P>(Expression<Func<VM, P>> property)
		{
			RegisterUpdater(property);
			return this;
		}

		//public AsyncCommandExBuilder<VM, T> UpdatesOn(params Expression<Func<VM, object>>[] properties)
		//{
		//	foreach (var property in properties)
		//	{
		//		RegisterUpdater(property);
		//	}
		//	return this;
		//}

		public AsyncCommandEx<T> Build()
		{
			if (_checkNull)
			{
				if (_canExecuteFunc == null)
				{
					_canExecuteFunc = DefaultFuncs<T>.NotNull;
				}
				else //!=null
				{
					_canExecuteFunc = p => DefaultFuncs<T>.NotNull(p) && _canExecuteFunc(p);
				}
			}
			AsyncCommandEx<T> command = new(_executeTask!, _canExecuteFunc); //will throw if _executeTask == null
			CommandRegister.RegisterCommand(CommandName, command, DependentProps);
			return command;
		}
	}
}

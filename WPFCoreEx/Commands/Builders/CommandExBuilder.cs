using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

using WPFCoreEx.Abstractions.Bases;
using WPFCoreEx.Abstractions.Commands;
using WPFCoreEx.Abstractions.Exceptions;
using WPFCoreEx.Helpers;

using static WPFCoreEx.Helpers.ExpressionHelper;

namespace WPFCoreEx.Commands.Builders
{
	public class CommandExBuilder<VM> : CommandBuilderBase<VM>
		where VM : INotifyPropertyChanged
	{
		private Action? _executeAction;
		private CanExecuteFunc? _canExecuteFunc;
		private bool _cacheCanExecute = false;

		internal CommandExBuilder(VM viewModel, ICommandRegister commandRegister, string commandName) :
			base(viewModel, commandRegister, commandName)
		{ }

		public CommandExBuilder<VM> Execute(Action execute)
		{
			ThrowIfReinit(_executeAction);
			_executeAction = execute;
			return this;
		}

		public CommandExBuilder<VM> Execute(Action<VM> execute)
		{
			return Execute(new Action(
				() => execute(ViewModel)
				));
		}

		public CommandExBuilder<VM> CanExecute(CanExecuteFunc canExecute)
		{
			ThrowIfReinit(_canExecuteFunc);
			_canExecuteFunc = canExecute;
			return this;
		}

		public CommandExBuilder<VM> CanExecute(CanExecuteFunc<VM> canExecute)
		{
			return CanExecute(new CanExecuteFunc(
				() => canExecute(ViewModel)
				));
		}

		public CommandExBuilder<VM> CanExecuteObserves(Expression<Func<VM, bool>> property)
		{
			ThrowIfReinit(_canExecuteFunc);
			_canExecuteFunc = RegisterObserver(property);
			return this;
		}

		public CommandExBuilder<VM> UpdatesOn<P>(Expression<Func<VM, P>> property)
		{
			RegisterUpdater(property);
			return this;
		}

		//public CommandExBuilder<VM> UpdatesOn(params Expression<Func<VM, object?>>[] properties)
		//{
		//	foreach (var property in properties)
		//	{
		//		RegisterUpdater(property);
		//	}
		//	return this;
		//}

		public CommandExBuilder<VM> CacheCanExecute()
		{
			_cacheCanExecute = true;
			return this;
		}

		public CommandEx Build()
		{
			CommandEx command = new(_executeAction!, _canExecuteFunc, _cacheCanExecute); //will throw if _executeTask == null
			CommandRegister.RegisterCommand(CommandName, command, DependentProps);
			return command;
		}
	}

	public class CommandExBuilder<VM, T> : CommandBuilderBase<VM>
		where VM : INotifyPropertyChanged
	{
		private bool _checkNull = false;

		private Action<T?>? _executeAction;
		private CanExecuteFunc<T?>? _canExecuteFunc;

		internal CommandExBuilder(VM viewModel, ICommandRegister commandRegister, string commandName) :
			base(viewModel, commandRegister, commandName)
		{ }


		public CommandExBuilder<VM, T> Execute(Action<T?> execute)
		{
			ThrowIfReinit(_executeAction);
			_executeAction = execute;
			return this;
		}

		public CommandExBuilder<VM, T> Execute(Action<VM, T?> execute)
		{
			return Execute(new Action<T?>(
				parameter => execute(ViewModel, parameter)
				));
		}

		public CommandExBuilder<VM, T> Execute(Action<T> execute, bool checkNull)
		{
			ThrowIfReinit(_executeAction);
			_executeAction = execute!;
			_checkNull = checkNull;
			return this;
		}

		public CommandExBuilder<VM, T> CanExecute(CanExecuteFunc<T?> canExecute)
		{
			ThrowIfReinit(_canExecuteFunc);
			_canExecuteFunc = canExecute;
			return this;
		}

		public CommandExBuilder<VM, T> CanExecuteObserves(Expression<Func<VM, bool>> property)
		{
			ThrowIfReinit(_canExecuteFunc);
			var compiledFunc = RegisterObserver(property);
			_canExecuteFunc = _ => compiledFunc();
			return this;
		}

		public CommandExBuilder<VM, T> UpdatesOn<P>(Expression<Func<VM, P>> property)
		{
			RegisterUpdater(property);
			return this;
		}

		//public CommandExBuilder<VM, T> UpdatesOn(params Expression<Func<VM, object?>>[] properties)
		//{
		//	foreach (var property in properties)
		//	{
		//		RegisterUpdater(property);
		//	}
		//	return this;
		//}

		public CommandEx<T> Build()
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
			CommandEx<T> command = new(_executeAction!, _canExecuteFunc); //will throw if _executeTask == null
			CommandRegister.RegisterCommand(CommandName, command, DependentProps);
			return command;
		}
	}
}

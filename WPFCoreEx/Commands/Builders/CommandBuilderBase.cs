using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

using WPFCoreEx.Abstractions.Bases;
using WPFCoreEx.Abstractions.Commands;
using WPFCoreEx.Abstractions.Exceptions;

using static WPFCoreEx.Helpers.ExpressionHelper;

namespace WPFCoreEx.Commands.Builders
{
	public abstract class CommandBuilderBase<VM>
		where VM : INotifyPropertyChanged
	{
		protected List<string> DependentProps { get; } = new();
		protected VM ViewModel { get; }
		protected ICommandRegister CommandRegister { get; }
		protected string CommandName { get; }

		protected CommandBuilderBase(VM viewModel, ICommandRegister commandRegister, string commandName)
		{
			ViewModel = viewModel;
			CommandRegister = commandRegister;
			CommandName = commandName;
		}

		protected void RegisterUpdater<P>(Expression<Func<VM, P>> property)
		{
			DependentProps.Add(GetPropertyName(property));
		}

		/// <summary>
		/// Register <see cref="DependentProps"/> with provided property.
		/// </summary>
		/// <param name="property">Expression with property/></param>
		/// <returns>Compiled <see cref="CanExecuteFunc"/> from expression</returns>
		protected CanExecuteFunc RegisterObserver(Expression<Func<VM, bool>> property)
		{
			DependentProps.Add(GetPropertyName(property, out var func));
			return new(
				() => func(ViewModel)
				);
		}

		protected void ThrowIfReinit(object? obj, [CallerMemberName] string func = "")
		{
			if (obj != null) throw new ReinitException(func);
		}
	}
}

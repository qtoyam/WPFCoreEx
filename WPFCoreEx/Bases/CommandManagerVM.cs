using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using WPFCoreEx.Abstractions.Bases;
using WPFCoreEx.Abstractions.Commands;
using WPFCoreEx.Abstractions.Exceptions;
using WPFCoreEx.Commands;
using WPFCoreEx.Commands.Builders;

namespace WPFCoreEx.Bases.Commands
{
	public sealed class CommandManagerVM<VM> : ICommandRegister
		where VM : INotifyPropertyChanged
	{
		/// <summary>
		/// key = command name, value = command
		/// </summary>
		private readonly Dictionary<string, ICommandUpdatable> _registeredCommands = new();
		/// <summary>
		/// key = property name, value = commands which CanExecute relies on this prop
		/// </summary>
		private readonly Dictionary<string, Collection<ICommandUpdatable>> _propertyDependents = new();
		/// <summary>
		/// <see cref="VM"/> associated with current <see cref="CommandManagerVM{VM}"/>
		/// </summary>
		private readonly VM _viewModel;

		public CommandManagerVM(VM viewModel)
		{
			_viewModel = viewModel;
		}

		#region No param builders
		/// <summary>
		/// Returns command if it already created, otherwise initialize builder for command type.
		/// </summary>
		/// <param name="builder">Builder if command not created</param>
		/// <param name="commandName">Automatically passes property getter</param>
		/// <returns>Command if already created</returns>
		/// <exception cref="ReregException">Thrown if command already created but with different type.</exception>
		public CommandEx? TryGetCommandEx(out CommandExBuilder<VM> builder,[CallerMemberName] string commandName = "")
		{
			if(_registeredCommands.TryGetValue(commandName, out var command))
			{
				builder = null!;
				if (command is CommandEx ce) return ce;
				else throw new ReregException(commandName);
			}
			else
			{
				builder = new CommandExBuilder<VM>(_viewModel,this, commandName);
				return null;
			}
		}
		/// <summary>
		/// Returns command if it already created, otherwise initialize builder for command type.
		/// </summary>
		/// <param name="builder">Builder if command not created</param>
		/// <param name="commandName">Automatically passes property getter</param>
		/// <returns>Command if already created</returns>
		/// <exception cref="ReregException">Thrown if command already created but with different type.</exception>
		public AsyncCommandEx? TryGetAsyncCommandEx(out AsyncCommandExBuilder<VM> builder, [CallerMemberName] string commandName = "")
		{
			if (_registeredCommands.TryGetValue(commandName, out var command))
			{
				builder = null!;
				if (command is AsyncCommandEx ce) return ce;
				else throw new ReregException(commandName);
			}
			else
			{
				builder = new AsyncCommandExBuilder<VM>(_viewModel,this, commandName);
				return null;
			}
		}
		#endregion //No param builders

		#region Generic builders
		/// <summary>
		/// Returns command if it already created, otherwise initialize builder for command type.
		/// </summary>
		/// <param name="builder">Builder if command not created</param>
		/// <param name="commandName">Automatically passes property getter</param>
		/// <returns>Command if already created</returns>
		/// <exception cref="ReregException">Thrown if command already created but with different type.</exception>
		public CommandEx<T>? TryGetCommandEx<T>(out CommandExBuilder<VM, T> builder, [CallerMemberName] string commandName = "")
		{
			if (_registeredCommands.TryGetValue(commandName, out var command))
			{
				builder = null!;
				if (command is CommandEx<T> ce) return ce;
				else throw new ReregException(commandName);
			}
			else
			{
				builder = new CommandExBuilder<VM, T>(_viewModel,this, commandName);
				return null;
			}
		}
		/// <summary>
		/// Returns command if it already created, otherwise initialize builder for command type.
		/// </summary>
		/// <param name="builder">Builder if command not created</param>
		/// <param name="commandName">Automatically passes property getter</param>
		/// <returns>Command if already created</returns>
		/// <exception cref="ReregException">Thrown if command already created but with different type.</exception>
		public AsyncCommandEx<T>? TryGetAsyncCommandEx<T>(out AsyncCommandExBuilder<VM, T> builder, [CallerMemberName] string commandName = "")
		{
			if (_registeredCommands.TryGetValue(commandName, out var command))
			{
				builder = null!;
				if (command is AsyncCommandEx<T> ce) return ce;
				else throw new ReregException(commandName);
			}
			else
			{
				builder = new AsyncCommandExBuilder<VM, T>(_viewModel,this, commandName);
				return null;
			}
		}
		#endregion //Generic builders

		public void UpdateCommands(string propertyName)
		{
			if (propertyName != null && _propertyDependents.TryGetValue(propertyName, out var commands))
			{
				foreach (var command in commands)
				{
					command.Update();
				}
			}
		}

		void ICommandRegister.RegisterCommand(string commandName, ICommandUpdatable command, IEnumerable<string> propDependents)
		{
			_registeredCommands[commandName] = command;
			foreach(var prop in propDependents)
			{
				if(!_propertyDependents.TryGetValue(prop, out var commands))
				{
					commands = new();
					_propertyDependents.Add(prop, commands);
				}
				commands.Add(command);
			}
		}
	}
}

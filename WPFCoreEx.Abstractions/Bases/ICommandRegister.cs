using WPFCoreEx.Abstractions.Commands;

namespace WPFCoreEx.Abstractions.Bases
{
	public interface ICommandRegister
	{
		void RegisterCommand(string commandName,ICommandUpdatable command, IEnumerable<string> propDependents);
	}
}

using System;

namespace Dream.Core
{
	public interface ICommandBus
	{
		void RegisterAndExecute(Func<ICommand> command);
	}
}
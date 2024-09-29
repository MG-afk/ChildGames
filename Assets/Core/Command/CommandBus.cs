using System;

namespace Dream.Core
{
	public class CommandBus : ICommandBus
	{
		private readonly CommandResolver _commandResolver;

		public CommandBus(CommandResolver commandResolver)
		{
			_commandResolver = commandResolver;
		}

		public void RegisterAndExecute(Func<ICommand> command)
		{
			var commandToExecute = command();

			_commandResolver.Resolve(commandToExecute);

			commandToExecute.Execute();
		}
	}
}
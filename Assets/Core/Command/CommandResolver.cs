using Zenject;

namespace Dream.Core
{
	public sealed class CommandResolver
	{
		private readonly DiContainer _container;

		public CommandResolver(DiContainer container)
		{
			_container = container;
		}

		public void Resolve(ICommand command)
		{
			_container.Inject(command);
		}
	}
}
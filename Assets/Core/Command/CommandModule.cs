using Zenject;

namespace Dream.Core
{
	public static class CommandModule
	{
		public static void Install(DiContainer container)
		{
			container.BindInterfacesAndSelfTo<CommandBus>().AsSingle();
			container.Bind<CommandResolver>().AsSingle();
		}
	}
}
using Zenject;

namespace XMG.ChildGame
{
	public class AppStartup : IInitializable
	{
		private readonly GameSelectorView.Factory _gameSelectorViewFactory;

		public AppStartup(GameSelectorView.Factory gameSelectorViewFactory)
		{
			_gameSelectorViewFactory = gameSelectorViewFactory;
		}

		public void Initialize()
		{
			_gameSelectorViewFactory.Create();
		}
	}
}
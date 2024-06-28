using Zenject;

namespace XMG.ChildGame
{
	public class GameSelectorStartup : IInitializable
	{
		private readonly GameSelectorView.Factory _gameSelectorViewFactory;

		public GameSelectorStartup(GameSelectorView.Factory gameSelectorViewFactory)
		{
			_gameSelectorViewFactory = gameSelectorViewFactory;
		}

		public void Initialize()
		{
			_gameSelectorViewFactory.Create();
		}
	}
}
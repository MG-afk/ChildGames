using Dream.Core;
using Zenject;

namespace XMG.ChildGame
{
	public class GameSelectorStartup : IInitializable
	{
		private readonly IPresenterStageManager _presenterStageManager;

		public GameSelectorStartup(IPresenterStageManager presenterStageManager)
		{
			_presenterStageManager = presenterStageManager;
		}

		public void Initialize()
		{
			_presenterStageManager.CreatePanelPresenter<GameSelectorPresenter, GameSelectorView>();
		}
	}
}
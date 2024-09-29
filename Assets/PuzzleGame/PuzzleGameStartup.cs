using Dream.Core;
using System;
using XMG.ChildGame.Navigation;
using Zenject;

namespace XMG.ChildGame.Puzzle
{
	public class PuzzleGameStartup : IInitializable, IDisposable
	{
		private readonly IPresenterStageManager _presenterStageManager;

		public PuzzleGameStartup(IPresenterStageManager presenterStageManager)
		{
			_presenterStageManager = presenterStageManager;
		}


		public void Initialize()
		{
			_presenterStageManager.CreatePanelPresenter<NavigationPresenter, NavigationView>();
			_presenterStageManager.CreatePresenter<PuzzlePresenter, PuzzleView>();
		}

		public void Dispose()
		{
		}
	}
}

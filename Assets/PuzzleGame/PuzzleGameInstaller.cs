using UnityEngine;

namespace XMG.ChildGame.Puzzle
{
	public class PuzzleGameInstaller : BaseAppInstaller
	{
		[SerializeField]
		private PuzzleViewContainer _puzzleViewContainer;

		public override void InstallBindings()
		{
			base.InstallBindings();
			Container.BindInterfacesAndSelfTo<PuzzleGameStartup>().AsSingle();

			BindFactoryViewWithPresenter<PuzzleView, PuzzlePresenter>(Container, _puzzleViewContainer.PuzzleView);
		}
	}
}
using UnityEngine;
using XMG.ChildGame.Navigation;
using Zenject;

namespace XMG.ChildGame.Puzzle
{
	[CreateAssetMenu(fileName = "PuzzleGameInstaller", menuName = "Installers/PuzzleGameInstaller")]
	public class PuzzleGameInstaller : ScriptableObjectInstaller<PuzzleGameInstaller>
	{
		[SerializeField]
		private AppContainer _appContainer;

		[SerializeField]
		private PuzzleViewContainer _puzzleViewContainer;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PuzzleGameStartup>().AsSingle();

			Container.BindView<NavigationView, NavigationView.Factory, NavigationController>(_appContainer.NavigationView);
			Container.BindView<PuzzleView, PuzzleView.Factory, PuzzleController>(_puzzleViewContainer.PuzzleView);
		}
	}
}
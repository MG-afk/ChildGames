using UnityEngine;
using XMG.ChildGame.Navigation;
using Zenject;

namespace XMG.ChildGame.GameSelector
{
	[CreateAssetMenu(fileName = "GameSelectorInstaller", menuName = "Installers/GameSelectorInstaller")]
	public class GameSelectorInstaller : ScriptableObjectInstaller<GameSelectorInstaller>
	{
		[SerializeField]
		private AppContainer _appContainer;

		[SerializeField]
		private GameSelectorContainer _gameSelectorViewContainer;

		[SerializeField]
		private MiniGameData[] _miniGames;

		public override void InstallBindings()
		{

			Container.Bind<MiniGamesProvider>().AsSingle().WithArguments(_miniGames);

			Container.Bind<IInitializable>()
				.To<GameSelectorStartup>()
				.AsSingle();

			Container.BindView<GameSelectorView, GameSelectorView.Factory, GameSelectorController>(_gameSelectorViewContainer.GameSelectorView);
			Container.BindView<NavigationView, NavigationView.Factory, NavigationController>(_appContainer.NavigationView);
		}
	}
}

using UnityEngine;
using Zenject;

namespace XMG.ChildGame.GameSelector
{
	public class GameSelectorInstaller : BaseAppInstaller
	{
		[SerializeField]
		private GameSelectorContainer _gameSelectorViewContainer;

		[SerializeField]
		private MiniGameData[] _miniGames;

		public override void InstallBindings()
		{
			base.InstallBindings();
			Container.Bind<MiniGamesProvider>().AsSingle().WithArguments(_miniGames);

			BindFactoryViewWithPresenter<GameSelectorView, GameSelectorPresenter>(Container, _gameSelectorViewContainer.GameSelector);

			Container.Bind<IInitializable>()
				.To<GameSelectorStartup>()
				.AsSingle();
		}
	}
}

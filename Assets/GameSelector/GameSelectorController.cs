using UnityEngine;
using UnityEngine.SceneManagement;
using XMG.ChildGame.Dentist;
using Zenject;

namespace XMG.ChildGame
{
	public class GameSelectorController : BaseController
	{
		private readonly MiniGame[] _miniGames;
		private readonly DiContainer _diContainer;

		public BindableProperty<int> CurrentGameIndex { get; }
		public MiniGame[] MiniGames => _miniGames;
		public int AmountOfGames => _miniGames.Length;

		public GameSelectorController(MiniGame[] miniGames, DiContainer diContainer)
		{
			_miniGames = miniGames;
			_diContainer = diContainer;

			CurrentGameIndex = new(0);
		}

		public void StartGame()
		{
			var selectedGame = _miniGames[CurrentGameIndex.Value];

			SceneManager.LoadSceneAsync(selectedGame.SceneId, LoadSceneMode.Additive);

			Install(selectedGame.Installer);
		}

		public void Install<T>(T _) where T : Installer
		{
			_diContainer.Install<T>();
		}

		public void SelectGame(SideIndex sideIndex)
		{
			var sideIndexValue = (int)sideIndex;
			var newGameIndex = (CurrentGameIndex.Value + sideIndexValue) % AmountOfGames;

			CurrentGameIndex.Value = newGameIndex < 0 ? AmountOfGames - 1 : newGameIndex;
		}
	}
}

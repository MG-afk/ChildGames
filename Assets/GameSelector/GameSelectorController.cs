using System.Linq;
using UnityEngine.SceneManagement;
using XMG.ChildGame.Navigation;

namespace XMG.ChildGame
{
	public class GameSelectorController : BaseController
	{
		private readonly MiniGamesProvider _miniGamesProvider;

		private IMiniGame _currentLoadedMiniGame;

		public BindableProperty<int> CurrentGameIndex { get; }
		public MiniGamesProvider MiniGamesProvider => _miniGamesProvider;
		public int AmountOfGames => _miniGamesProvider.GamesByType.Count;

		public GameSelectorController(MiniGamesProvider miniGamesProvider, NavigationView.Factory navigationFactory)
		{
			_miniGamesProvider = miniGamesProvider;

			CurrentGameIndex = new(0);
		}

		public void StartGame()
		{
			var selectedGameKey = _miniGamesProvider.GamesByType.Keys.ToArray()[CurrentGameIndex.Value];
			_currentLoadedMiniGame = _miniGamesProvider.GamesByType[selectedGameKey];

			SceneManager.LoadScene(_currentLoadedMiniGame.SceneId);
		}

		public void SelectGame(SideIndex sideIndex)
		{
			var sideIndexValue = (int)sideIndex;
			var newGameIndex = (CurrentGameIndex.Value + sideIndexValue) % AmountOfGames;

			CurrentGameIndex.Value = newGameIndex < 0 ? AmountOfGames - 1 : newGameIndex;
		}
	}
}

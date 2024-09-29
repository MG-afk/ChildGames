using Dream.Core;
using System.Linq;
using UnityEngine.SceneManagement;
using Zenject;

namespace XMG.ChildGame
{
	public class GameSelectorPresenter : BasePresenter<GameSelectorView>
	{
		private MiniGamesProvider _miniGamesProvider;
		private IMiniGame _currentLoadedMiniGame;

		private BindableProperty<int> _currentGameIndex { get; } = new();
		public MiniGamesProvider MiniGamesProvider => _miniGamesProvider;
		public int AmountOfGames => _miniGamesProvider.GamesByType.Count;

		[Inject]
		public void Construct(MiniGamesProvider miniGamesProvider)
		{
			_miniGamesProvider = miniGamesProvider;

			View.LeftButton.onClick.AddListener(() => SelectGame(SideIndex.Left));
			View.RightButton.onClick.AddListener(() => SelectGame(SideIndex.Right));
			View.PlayButton.onClick.AddListener(() => StartGame());

			ChangeIndex(0);

			_currentGameIndex.Bind(ChangeIndex, false, this);
		}

		protected override void OnDispose()
		{
			View.LeftButton.onClick.RemoveAllListeners();
			View.RightButton.onClick.RemoveAllListeners();
			View.PlayButton.onClick.RemoveAllListeners();
		}

		private void ChangeIndex(int index)
		{
			var selectedGameKey = MiniGamesProvider.GamesByType.Keys.ToArray()[index];
			var selectedGame = MiniGamesProvider.GamesByType[selectedGameKey];

			View.Image.sprite = selectedGame.PreviewImage;
		}


		public void StartGame()
		{
			var selectedGameKey = _miniGamesProvider.GamesByType.Keys.ToArray()[_currentGameIndex.Value];
			_currentLoadedMiniGame = _miniGamesProvider.GamesByType[selectedGameKey];

			SceneManager.LoadSceneAsync(_currentLoadedMiniGame.SceneId);
		}

		public void SelectGame(SideIndex sideIndex)
		{
			var sideIndexValue = (int)sideIndex;
			var newGameIndex = (_currentGameIndex.Value + sideIndexValue) % AmountOfGames;

			_currentGameIndex.Value = newGameIndex < 0 ? AmountOfGames - 1 : newGameIndex;
		}
	}
}

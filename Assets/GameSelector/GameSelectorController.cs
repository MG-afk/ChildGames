using UnityEngine;

namespace XMG.ChildGame
{
	public class GameSelectorController : BaseController
	{
		public BindableProperty<int> CurrentGameIndex { get; }
		public int AmountOfGames { get; set; }

		public GameSelectorController()
		{
			CurrentGameIndex = new(0);
		}

		public void StartGame()
		{
			Debug.Log("Start" + CurrentGameIndex.Value);
		}

		public void SelectGame(SideIndex sideIndex)
		{
			var sideIndexValue = (int)sideIndex;
			var newGameIndex = (CurrentGameIndex.Value + sideIndexValue) % AmountOfGames;

			CurrentGameIndex.Value = newGameIndex < 0 ? AmountOfGames - 1 : newGameIndex;
		}
	}
}

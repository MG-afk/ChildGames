using UnityEngine;

namespace XMG.ChildGame
{
	public class PuzzleMiniGame : BaseMiniGame
	{
		private readonly MiniGameData _miniGameData;

		public override string SceneId => "Puzzle";
		public override Sprite PreviewImage => _miniGameData.PreviewImage;

		public PuzzleMiniGame(MiniGameData miniGameData)
		{
			_miniGameData = miniGameData;
		}
	}
}
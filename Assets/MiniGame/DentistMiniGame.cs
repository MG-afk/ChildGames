using UnityEngine;

namespace XMG.ChildGame
{
	public class DentistMiniGame : BaseMiniGame
	{
		private readonly MiniGameData _miniGameData;

		public override string SceneId => "Dentist";
		public override Sprite PreviewImage => _miniGameData.PreviewImage;

		public DentistMiniGame(MiniGameData miniGameData)
		{
			_miniGameData = miniGameData;
		}
	}
}
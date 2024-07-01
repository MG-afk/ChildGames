using System;
using UnityEngine;

namespace XMG.ChildGame
{
	public enum MiniGameType
	{
		Dentist = 1,
	}

	[Serializable]
	public class MiniGameData
	{
		public MiniGameType GameType;
		public Sprite PreviewImage;
	}

	public interface IMiniGame
	{
		string SceneId { get; }
		Sprite PreviewImage { get; }
	}

	public abstract class BaseMiniGame : IMiniGame
	{
		public abstract string SceneId { get; }
		public abstract Sprite PreviewImage { get; }
	}

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
using System;
using UnityEngine;

namespace XMG.ChildGame
{
	public enum MiniGameType
	{
		Dentist = 10,
		Puzzle = 20,
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
}
using UnityEngine;

namespace XMG.ChildGame.Puzzle
{
	public sealed class PuzzlePieceSubView : MonoBehaviour
	{
		private int _value;

		public void SetNumber(int value)
		{
			_value = value;
		}

		public int GetNumber() => _value;
	}
}
using UnityEngine;

namespace XMG.ChildGame.Puzzle
{
	[CreateAssetMenu(fileName = "PuzzleViewContainer", menuName = "XMG/Containers/PuzzleViewContainer")]
	public class PuzzleViewContainer : BaseViewContainer
	{
		[field: SerializeField]
		public PuzzleView PuzzleView { get; private set; }
	}
}
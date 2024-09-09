using UnityEngine;

namespace XMG.ChildGame.Puzzle
{
	[CreateAssetMenu(fileName = "PuzzleViewContainer", menuName = "XMG/Containers/PuzzleViewContainer")]
	public class PuzzleViewContainer : BaseViewContainer
	{
		[field: SerializeField]
		public GameObject PuzzleView { get; private set; }
	}
}
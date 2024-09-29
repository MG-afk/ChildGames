using UnityEngine;

namespace XMG.ChildGame
{
	[CreateAssetMenu(fileName = "ViewContainer", menuName = "ViewContainer")]
	public class ViewContainer : BaseViewContainer
	{
		[field: SerializeField]
		public GameSelectorView GameSelector { get; private set; }
	}
}

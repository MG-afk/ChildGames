using UnityEngine;

namespace XMG.ChildGame
{
	[CreateAssetMenu(fileName = "GameSelectorContainer", menuName = "XMG/GameSelectorContainer")]
	public sealed class GameSelectorContainer : BaseViewContainer
	{
		[field: SerializeField]
		public GameObject GameSelectorView { get; private set; }
	}
}

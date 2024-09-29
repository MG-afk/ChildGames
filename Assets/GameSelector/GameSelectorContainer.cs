using UnityEngine;

namespace XMG.ChildGame
{
	[CreateAssetMenu(fileName = "GameSelectorContainer", menuName = "XMG/GameSelectorContainer")]
	public sealed class GameSelectorContainer : BaseViewContainer
	{
		[field: SerializeField]
		public GameSelectorView GameSelector { get; private set; }
	}
}

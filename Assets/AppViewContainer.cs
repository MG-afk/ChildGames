using UnityEngine;

namespace XMG.ChildGame
{
	[CreateAssetMenu(fileName = "AppViewContainer", menuName = "XMG/AppViewContainer")]
	public sealed class AppViewContainer : BaseViewContainer
	{
		[field: SerializeField]
		public GameObject GameSelectorView { get; private set; }
	}
}

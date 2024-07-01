using UnityEngine;

namespace XMG.ChildGame
{
	[CreateAssetMenu(fileName = "AppContainer", menuName = "XMG/Containers/AppContainer")]
	public sealed class AppContainer : BaseViewContainer
	{
		[field: SerializeField]
		public GameObject NavigationView { get; private set; }
	}
}
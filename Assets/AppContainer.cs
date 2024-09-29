using UnityEngine;
using XMG.ChildGame.Navigation;

namespace XMG.ChildGame
{
	[CreateAssetMenu(fileName = "AppContainer", menuName = "XMG/Containers/AppContainer")]
	public sealed class AppContainer : BaseViewContainer
	{
		[field: SerializeField]
		public NavigationView NavigationView { get; private set; }
	}
}
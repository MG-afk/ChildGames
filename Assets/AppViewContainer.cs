using UnityEngine;

namespace XMG.Core
{
	[CreateAssetMenu(fileName = "AppViewContainer", menuName = "XMG/AppViewContainer")]
	public sealed class AppViewContainer : ScriptableObject
	{
		[field: SerializeField]
		public GameObject GameSelectorView { get; private set; }
	}
}

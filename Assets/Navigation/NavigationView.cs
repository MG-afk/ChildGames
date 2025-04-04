using Dream.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace XMG.ChildGame.Navigation
{
	public class NavigationView : BaseView, Dream.Core.IPanel
	{
		[field: SerializeField]
		public Button BackButton { get; private set; }

		public sealed class Factory : PlaceholderFactory<NavigationView> { }
	}
}
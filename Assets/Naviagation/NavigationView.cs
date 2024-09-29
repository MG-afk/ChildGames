using Dream.Core;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace XMG.ChildGame.Navigation
{
	public class NavigationView : BaseView
	{
		[SerializeField]
		private Button _backButton;

		protected override void Bind()
		{
			//_backButton.RegisterCallback<ClickEvent>(_ => Controller.BackToMainScene());
		}

		protected override void BeforeDestroy()
		{
			//_backButton.UnregisterCallback<ClickEvent>(_ => Controller.BackToMainScene());
		}

		public sealed class Factory : PlaceholderFactory<NavigationView> { }
	}
}
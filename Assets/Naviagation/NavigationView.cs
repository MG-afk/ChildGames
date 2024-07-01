using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace XMG.ChildGame.Navigation
{
	public class NavigationView : BaseView<NavigationController>
	{
		[SerializeField]
		private UIDocument _document;

		private Button _backButton;

		public override void Bind()
		{
			if (!_document)
			{
				_document = GetComponent<UIDocument>();
			}

			_backButton = _document.rootVisualElement.Q<Button>("BackButton");

			_backButton.RegisterCallback<ClickEvent>(_ => Controller.BackToMainScene());
		}

		public override void BeforeDispose()
		{
			_backButton.UnregisterCallback<ClickEvent>(_ => Controller.BackToMainScene());
		}

		public sealed class Factory : PlaceholderFactory<NavigationView> { }
	}
}
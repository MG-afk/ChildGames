using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace XMG.ChildGame
{
	public class GameSelectorView : BaseView<GameSelectorController>
	{
		[SerializeField]
		private UIDocument _document;

		[SerializeField]
		private Sprite[] _sprites;

		private Button _leftButton;
		private VisualElement _image;
		private Button _rightButton;
		private Button _playButton;

		public class Factory : PlaceholderFactory<GameSelectorView> { }

		public override void Bind()
		{
			//TODO: Make the provider checking how much system left
			Controller.AmountOfGames = _sprites.Length;

			if (!_document)
			{
				_document = GetComponent<UIDocument>();
			}

			_leftButton = _document.rootVisualElement.Q("GameSelector").Q<Button>("LeftButton");
			_image = _document.rootVisualElement.Q<VisualElement>("GameSelector").Q<VisualElement>("Image");
			_rightButton = _document.rootVisualElement.Q<VisualElement>("GameSelector").Q<Button>("RightButton");
			_playButton = _document.rootVisualElement.Q<Button>("PlayButton");

			_leftButton.RegisterCallback<ClickEvent>(_ => Controller.SelectGame(SideIndex.Left));
			_rightButton.RegisterCallback<ClickEvent>(_ => Controller.SelectGame(SideIndex.Right));
			_playButton.RegisterCallback<ClickEvent>(_ => Controller.StartGame());

			Controller.CurrentGameIndex.AddListener(ChangeIndex);
		}

		public override void BeforeDispose()
		{
			_leftButton.UnregisterCallback<ClickEvent>(_ => Controller.SelectGame(SideIndex.Left));
			_rightButton.UnregisterCallback<ClickEvent>(_ => Controller.SelectGame(SideIndex.Right));
			_playButton.UnregisterCallback<ClickEvent>(_ => Controller.StartGame());

			Controller.CurrentGameIndex.RemoveListener(ChangeIndex);
		}

		private void ChangeIndex(int index)
		{
			_image.style.backgroundImage = new StyleBackground(_sprites[index]);
		}
	}
}

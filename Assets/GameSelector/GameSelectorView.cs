using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace XMG.ChildGame
{
	public sealed class GameSelectorView : BaseView<GameSelectorController>
	{
		[SerializeField]
		private UIDocument _document;

		private Button _leftButton;
		private VisualElement _image;
		private Button _rightButton;
		private Button _playButton;
		private Button _closeButton;

		public override void Bind()
		{
			if (!_document)
			{
				_document = GetComponent<UIDocument>();
			}

			_leftButton = _document.rootVisualElement.Q("GameSelector").Q<Button>("LeftButton");
			_image = _document.rootVisualElement.Q<VisualElement>("GameSelector").Q<VisualElement>("Image");
			_rightButton = _document.rootVisualElement.Q<VisualElement>("GameSelector").Q<Button>("RightButton");
			_playButton = _document.rootVisualElement.Q<Button>("PlayButton");
			_closeButton = _document.rootVisualElement.Q<Button>("CloseButton");

			_leftButton.RegisterCallback<ClickEvent>(_ => Controller.SelectGame(SideIndex.Left));
			_rightButton.RegisterCallback<ClickEvent>(_ => Controller.SelectGame(SideIndex.Right));
			_playButton.RegisterCallback<ClickEvent>(_ => Controller.StartGame());
			_closeButton.RegisterCallback<ClickEvent>(_ => Controller.CloseGame());

			Controller.CurrentGameIndex.AddListener(ChangeIndex);
		}

		public override void BeforeDispose()
		{
			_leftButton.UnregisterCallback<ClickEvent>(_ => Controller.SelectGame(SideIndex.Left));
			_rightButton.UnregisterCallback<ClickEvent>(_ => Controller.SelectGame(SideIndex.Right));
			_playButton.UnregisterCallback<ClickEvent>(_ => Controller.StartGame());
			_closeButton.UnregisterCallback<ClickEvent>(_ => Controller.CloseGame());

			Controller.CurrentGameIndex.RemoveListener(ChangeIndex);
		}

		private void ChangeIndex(int index)
		{
			var selectedGameKey = Controller.MiniGamesProvider.GamesByType.Keys.ToArray()[index];
			var selectedGame = Controller.MiniGamesProvider.GamesByType[selectedGameKey];

			_image.style.backgroundImage = new StyleBackground(selectedGame.PreviewImage);
		}

		public sealed class Factory : PlaceholderFactory<GameSelectorView> { }
	}
}

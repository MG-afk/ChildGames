using Dream.Core;
using UnityEngine;
using Zenject;

namespace XMG.ChildGame.Dentist.Tool
{
	public sealed class ToolSelectorView : BaseView
	{
		private IInputProvider _inputProvider;
		private ToolSubView _selectedTool;

		[Inject]
		public void Contructor(IInputProvider inputProvider)
		{
			_inputProvider = inputProvider;
		}

		protected override void Bind()
		{
			//_inputProvider.Clicked += Controller.ClickOnTool;
			//_inputProvider.PointerMoved += FollowPointer;
			//Controller.ClickedOnTool.AddListener(ClickOnTool);
		}
		protected override void BeforeDestroy()
		{
			//_inputProvider.Clicked -= Controller.ClickOnTool;
			//_inputProvider.PointerMoved -= FollowPointer;
			//Controller.ClickedOnTool.RemoveListener(ClickOnTool);
		}

		public void ClickOnTool(ToolSubView tool)
		{
			if (tool == null)
				return;

			_selectedTool = tool;
			_selectedTool.Selected();
		}

		private void FollowPointer()
		{
			if (_selectedTool == null)
				return;

			var worldPosition = Camera.main.ScreenToWorldPoint(
				new Vector3(_inputProvider.PointerPosition.x, _inputProvider.PointerPosition.y, -Camera.main.transform.position.z));

			_selectedTool.transform.position = new Vector3(worldPosition.x, worldPosition.y, _selectedTool.transform.position.z);
		}

		public sealed class Factory : PlaceholderFactory<ToolSelectorView> { }
	}
}
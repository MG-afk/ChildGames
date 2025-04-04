using Dream.Core;
using Dream.XMG;
using UnityEngine;
using Zenject;

namespace XMG.ChildGame.Dentist.Tool
{
	public sealed class ToolSelectorPresenter : BasePresenter<ToolSelectorView>
	{
		private IInputProvider _inputProvider;
		private ToolSubView _selectedTool;

		private Vector2 _startPosition;

		public BindableProperty<ToolSubView> ClickedOnTool { get; } = new();

		[Inject]
		public void Construct(IInputProvider inputProvider)
		{
			_inputProvider = inputProvider;
			View.transform.position = new Vector3(0, -5, 0);


			_inputProvider.Clicked += ClickOnTool;
			_inputProvider.Unclicked += UnclickOnTool;
			_inputProvider.PointerMoved += FollowPointer;
			ClickedOnTool.Bind(ClickOnTool, true, this);
		}

		protected override void OnDispose()
		{
			_inputProvider.Clicked -= ClickOnTool;
			_inputProvider.Unclicked -= UnclickOnTool;
			_inputProvider.PointerMoved -= FollowPointer;
		}

		public void ClickOnTool()
		{
			RaycasterSystem.RaycastFromMainCamera<ToolSubView>(out var tool);

			ClickedOnTool.Value = tool;
		}

		private void ClickOnTool(ToolSubView tool)
		{
			if (tool == null)
				return;

			_selectedTool = tool;
			_selectedTool.Selected();
		}

		private void UnclickOnTool()
		{
			if (_selectedTool == null)
				return;

			_selectedTool.Unselected();
			_selectedTool = null;
		}

		private void FollowPointer()
		{
			if (_selectedTool == null)
				return;

			var camera = Camera.main;

			if (camera == null)
				return;

			var worldPosition = camera.ScreenToWorldPoint(new Vector3(
				_inputProvider.PointerPosition.x,
				_inputProvider.PointerPosition.y,
				-camera.transform.position.z));

			_selectedTool.transform.position = new Vector3(worldPosition.x, worldPosition.y, _selectedTool.transform.position.z);
		}

	}
}
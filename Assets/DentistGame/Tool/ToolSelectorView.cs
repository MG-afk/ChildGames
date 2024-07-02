using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace XMG.ChildGame.Dentist.Tool
{
	public sealed class ToolSelectorView : BaseView<ToolSelectorController>
	{
		private InputControls _input;
		private ToolSubView _selectedTool;

		[Inject]
		public void Contructor(InputControls input)
		{
			_input = input;
		}

		public override void Bind()
		{
			_input.Player.Click.performed += Controller.ClickOnTool;
			_input.Player.PointerPosition.performed += FollowPointer;
			Controller.ClickedOnTool.AddListener(ClickOnTool);
		}

		public override void BeforeDispose()
		{
			_input.Player.Click.performed -= Controller.ClickOnTool;
			_input.Player.PointerPosition.performed -= FollowPointer;
			Controller.ClickedOnTool.RemoveListener(ClickOnTool);
		}

		public void ClickOnTool(ToolSubView tool)
		{
			if (tool == null)
				return;

			_selectedTool = tool;
			_selectedTool.Selected();
		}

		private void FollowPointer(InputAction.CallbackContext context)
		{
			if (_selectedTool == null)
				return;

			var screenPosition = context.ReadValue<Vector2>();
			var worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, -Camera.main.transform.position.z));

			_selectedTool.transform.position = new Vector3(worldPosition.x, worldPosition.y, _selectedTool.transform.position.z);
		}

		public sealed class Factory : PlaceholderFactory<ToolSelectorView> { }
	}
}
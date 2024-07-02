using UnityEngine.InputSystem;

namespace XMG.ChildGame.Dentist.Tool
{
	public sealed class ToolSelectorController : BaseController
	{
		public BindableProperty<ToolSubView> ClickedOnTool { get; } = new();

		public override void Dispose()
		{
		}

		public void ClickOnTool(InputAction.CallbackContext _)
		{
			RaycasterSystem.RaycastFromMainCamera<ToolSubView>(out var tool);

			ClickedOnTool.Value = tool;
		}
	}
}
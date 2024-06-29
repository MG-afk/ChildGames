using UnityEngine.InputSystem;

namespace XMG.ChildGame.Dentist.Tool
{
	public sealed class ToolSelectorController : BaseController
	{
		public BindableProperty<DentistToolSubView> ClickedOnTool { get; } = new();

		public override void Dispose()
		{
		}

		public void ClickOnTool(InputAction.CallbackContext _)
		{
			RaycasterSystem.RaycastFromMainCamera<DentistToolSubView>(out var tool);

			if (tool == null)
				return;

			ClickedOnTool.Value = tool;
		}
	}
}
using Dream.Core;

namespace XMG.ChildGame.Dentist.Tool
{
	public sealed class ToolSelectorPresenter : BasePresenter<ToolSelectorView>
	{
		public BindableProperty<ToolSubView> ClickedOnTool { get; } = new();

		protected override void OnDispose()
		{

		}

		public void ClickOnTool()
		{
			//RaycasterSystem.RaycastFromMainCamera<ToolSubView>(out var tool);

			//ClickedOnTool.Value = tool;
		}
	}
}
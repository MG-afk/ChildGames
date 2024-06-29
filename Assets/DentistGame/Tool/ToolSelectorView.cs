using XMG.ChildGame.DentistGame.Patient;
using Zenject;

namespace XMG.ChildGame.Dentist.Tool
{
	public sealed class ToolSelectorView : BaseView<ToolSelectorController>
	{
		private InputControls _input;

		[Inject]
		public void Contructor(InputControls input)
		{
			_input = input;
		}

		public override void Bind()
		{
			_input.Player.Click.performed += Controller.ClickOnTool;
			Controller.ClickedOnTool.AddListener(ClickOnTooth);
		}

		public override void BeforeDispose()
		{
			_input.Player.Click.performed -= Controller.ClickOnTool;
			Controller.ClickedOnTool.RemoveListener(ClickOnTooth);
		}

		public void ClickOnTooth(DentistToolSubView tool)
		{
		}

		public sealed class Factory : PlaceholderFactory<ToolSelectorView> { }
	}
}
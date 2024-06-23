using UnityEngine.InputSystem;

namespace XMG.ChildGame.DentistGame.Patient
{
	public class PatientController : BaseController
	{
		private readonly InputControls _input;

		public BindableProperty<bool> Clicked { get; } = new();

		public PatientController(InputControls input)
		{
			_input = input;

			_input.Player.Click.performed += OnClick;
			_input.Player.Click.canceled += OnUnclick;
		}

		public override void Dispose()
		{
			_input.Player.Click.performed -= OnClick;
			_input.Player.Click.canceled -= OnUnclick;
		}

		private void OnClick(InputAction.CallbackContext _)
		{
			Clicked.Value = true;
		}

		private void OnUnclick(InputAction.CallbackContext _)
		{
			Clicked.Value = false;
		}
	}
}

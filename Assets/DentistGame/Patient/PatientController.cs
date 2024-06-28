using UnityEngine.InputSystem;

namespace XMG.ChildGame.DentistGame.Patient
{
	public class PatientController : BaseController
	{
		public BindableProperty<ToothSubView> ClickedOnTooth { get; } = new();

		public override void Dispose()
		{
		}

		public void ClickOnTooth(InputAction.CallbackContext _)
		{
			RaycasterSystem.RaycastFromMainCamera<ToothSubView>(out var tooth);

			if (tooth == null)
				return;

			ClickedOnTooth.Value = tooth;
		}

	}
}

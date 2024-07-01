using UnityEngine.InputSystem;

namespace XMG.ChildGame.Dentist.WaitingRoom
{
	public class WaitingRoomController : BaseController
	{
		public BindableProperty<WaitingPersonSubView> ClickedOnPerson { get; } = new();

		public override void Dispose()
		{
		}

		public void ClickOnPerson(InputAction.CallbackContext _)
		{
			RaycasterSystem.RaycastFromMainCamera<WaitingPersonSubView>(out var person);

			if (person == null)
				return;

			ClickedOnPerson.Value = person;
		}
	}
}
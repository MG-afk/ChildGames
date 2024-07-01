using Zenject;

namespace XMG.ChildGame.Dentist.WaitingRoom
{
	public sealed class WaitingRoomView : BaseView<WaitingRoomController>
	{
		private InputControls _input;
		private DentistSystem _dentistSystem;

		[Inject]
		public void Contructor(InputControls input, DentistSystem dentistSystem)
		{
			_input = input;
			_dentistSystem = dentistSystem;
		}

		public override void Bind()
		{
			_input.Player.Click.performed += Controller.ClickOnPerson;
			Controller.ClickedOnPerson.AddListener(ClickOnPerson);
		}

		public override void BeforeDispose()
		{
			_input.Player.Click.performed -= Controller.ClickOnPerson;
			Controller.ClickedOnPerson.RemoveListener(ClickOnPerson);
		}

		public void ClickOnPerson(WaitingPersonSubView person)
		{
			Destroy(gameObject);

			_dentistSystem.LoadPatient(person.Data);
		}

		public class Factory : PlaceholderFactory<WaitingRoomView> { }
	}
}
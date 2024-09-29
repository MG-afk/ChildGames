using Dream.Core;
using Zenject;

namespace XMG.ChildGame.Dentist.WaitingRoom
{
	public sealed class WaitingRoomView : BaseView
	{
		private IInputProvider _inputProvider;
		private DentistSystem _dentistSystem;

		[Inject]
		public void Contructor(IInputProvider inputProvider, DentistSystem dentistSystem)
		{
			_inputProvider = inputProvider;
			_dentistSystem = dentistSystem;
		}

		protected override void Bind()
		{
			//_inputProvider.Clicked += Controller.ClickOnPerson;
			//Controller.ClickedOnPerson.AddListener(ClickOnPerson);
		}
		protected override void BeforeDestroy()
		{
			base.BeforeDestroy();
			//_inputProvider.Clicked -= Controller.ClickOnPerson;
			//Controller.ClickedOnPerson.RemoveListener(ClickOnPerson);
		}

		public void ClickOnPerson(WaitingPersonSubView person)
		{
			Destroy(gameObject);

			_dentistSystem.LoadPatient(person.Data);
		}

		public class Factory : PlaceholderFactory<WaitingRoomView> { }
	}
}
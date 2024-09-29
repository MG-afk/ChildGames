using Dream.Core;
using Dream.XMG;
using UnityEngine;
using Zenject;

namespace XMG.ChildGame.Dentist.WaitingRoom
{
	public class WaitingRoomPresenter : BasePresenter<WaitingRoomView>
	{
		private IInputProvider _inputProvider;
		private DentistSystem _dentistSystem;

		public BindableProperty<WaitingPersonSubView> ClickedOnPerson { get; } = new();

		[Inject]
		public void Contructor(IInputProvider inputProvider, DentistSystem dentistSystem)
		{
			_inputProvider = inputProvider;
			_dentistSystem = dentistSystem;

			_inputProvider.Clicked += ClickOnPerson;
			ClickedOnPerson.Bind(OnClickedOnPerson, false, this);
		}

		private void OnClickedOnPerson(WaitingPersonSubView waitingPerson)
		{
			Object.Destroy(View.gameObject);

			_dentistSystem.LoadPatient(waitingPerson.Data);
		}

		private void ClickOnPerson()
		{
			RaycasterSystem.RaycastFromMainCamera<WaitingPersonSubView>(out var person);

			if (person == null)
				return;

			ClickedOnPerson.Value = person;
		}

		protected override void OnDispose()
		{
			base.OnDispose();
			_inputProvider.Clicked -= ClickOnPerson;
		}
	}
}
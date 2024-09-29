using Dream.Core;

namespace XMG.ChildGame.Dentist.WaitingRoom
{
	public class WaitingRoomPresenter : BasePresenter<WaitingRoomView>
	{
		public BindableProperty<WaitingPersonSubView> ClickedOnPerson { get; } = new();

		protected override void OnDispose()
		{
			base.OnDispose();

		}

		public void ClickOnPerson()
		{
			//RaycasterSystem.RaycastFromMainCamera<WaitingPersonSubView>(out var person);

			//if (person == null)
			//	return;

			//ClickedOnPerson.Value = person;
		}
	}
}
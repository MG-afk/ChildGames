using Dream.Core;

namespace XMG.ChildGame.Dentist.WaitingRoom
{
	public sealed class WaitingRoomView : BaseView
	{
		public void ClickOnPerson(WaitingPersonSubView person)
		{
			Destroy(gameObject);

			//_dentistSystem.LoadPatient(person.Data);
		}
	}
}
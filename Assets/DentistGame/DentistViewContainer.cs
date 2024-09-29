using UnityEngine;
using XMG.ChildGame.Dentist.Tool;
using XMG.ChildGame.Dentist.WaitingRoom;
using XMG.ChildGame.DentistGame.Patient;

namespace XMG.ChildGame.Dentist
{
	[CreateAssetMenu(fileName = "DentistViewContainer", menuName = "XMG/Containers/DentistViewContainer")]
	public class DentistViewContainer : BaseViewContainer
	{
		[field: SerializeField]
		public PatientView PatientView { get; private set; }

		[field: SerializeField]
		public ToolSelectorView ToolSelectorView { get; private set; }

		[field: SerializeField]
		public WaitingRoomView WaitingRoomView { get; private set; }
	}
}
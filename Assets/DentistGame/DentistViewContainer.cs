using UnityEngine;

namespace XMG.ChildGame.Dentist
{
	[CreateAssetMenu(fileName = "DentistViewContainer", menuName = "XMG/Containers/DentistViewContainer")]
	public class DentistViewContainer : BaseViewContainer
	{
		[field: SerializeField]
		public GameObject PatientView { get; private set; }

		[field: SerializeField]
		public GameObject ToolSelectorView { get; private set; }

		[field: SerializeField]
		public GameObject WaitingRoomView { get; private set; }
	}
}
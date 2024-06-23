using UnityEngine;

namespace XMG.ChildGame.Dentist
{
	[CreateAssetMenu(fileName = "DentistViewContainer", menuName = "XMG/DentistViewContainer")]
	public class DentistViewContainer : BaseViewContainer
	{
		[field: SerializeField]
		public GameObject PatientView { get; private set; }

	}
}
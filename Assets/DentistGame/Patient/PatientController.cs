using Dream.Core;
using UnityEngine;

namespace XMG.ChildGame.DentistGame.Patient
{
	public class PatientController : MonoBehaviour
	{
		public BindableProperty<ToothSubView> ClickedOnTooth { get; } = new();

		public void Dispose()
		{
		}

		public void ClickOnTooth()
		{
			//RaycasterSystem.RaycastFromMainCamera<ToothSubView>(out var tooth);

			//if (tooth == null)
			//	return;

			//ClickedOnTooth.Value = tooth;
		}

	}
}

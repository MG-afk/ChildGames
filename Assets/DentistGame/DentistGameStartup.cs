using UnityEngine;
using XMG.ChildGame.DentistGame.Patient;

namespace XMG.ChildGame.Dentist
{
	public class DentistGameStartup : Zenject.IInitializable
	{
		private readonly PatientView.Factory _patientFactory;

		public DentistGameStartup(PatientView.Factory patientFactory)
		{
			_patientFactory = patientFactory;
		}

		public void Initialize()
		{
			_patientFactory.Create();
		}
	}
}
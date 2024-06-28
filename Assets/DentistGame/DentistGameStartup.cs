using System;
using XMG.ChildGame.DentistGame.Patient;
using Zenject;

namespace XMG.ChildGame.Dentist
{
	public class DentistGameStartup : IInitializable, IDisposable
	{
		private readonly PatientView.Factory _patientFactory;

		private PatientView _patientView;

		public DentistGameStartup(PatientView.Factory patientFactory)
		{
			_patientFactory = patientFactory;
		}

		public void Initialize()
		{
			_patientView = _patientFactory.Create();
		}

		public void Dispose()
		{
			UnityEngine.Object.Destroy(_patientView?.gameObject);
		}
	}
}
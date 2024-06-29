using System;
using XMG.ChildGame.DentistGame.Patient;
using Zenject;

namespace XMG.ChildGame.Dentist
{
	public class DentistGameStartup : IInitializable, IDisposable
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

		public void Dispose()
		{
		}
	}
}
using XMG.ChildGame.DentistGame.Patient;
using Zenject;

namespace XMG.ChildGame.Dentist
{
	public class DentistGameInstaller : Installer
	{
		private readonly DentistViewContainer _dentistViewContainer;

		public DentistGameInstaller(DentistViewContainer dentistViewContainer)
		{
			_dentistViewContainer = dentistViewContainer;
		}

		public override void InstallBindings()
		{
			Container.Bind<DentistSystem>().AsSingle();

			Container.Bind<IInitializable>()
				.To<DentistGameStartup>()
				.AsSingle();

			Container.BindFactory<PatientView, PatientView.Factory>()
				.FromComponentInNewPrefab(_dentistViewContainer.PatientView)
				.AsTransient();

			Container.Bind<PatientController>().AsTransient();
		}
	}
}

using UnityEngine;
using XMG.ChildGame.DentistGame.Patient;
using Zenject;

namespace XMG.ChildGame.Dentist
{
	[CreateAssetMenu(fileName = "DentistGameInstaller", menuName = "Installers/DentistGameInstaller")]
	public class DentistGameInstaller : ScriptableObjectInstaller<DentistGameInstaller>
	{
		[SerializeField]
		private DentistViewContainer _dentistViewContainer;

		public override void InstallBindings()
		{
			Container.Bind<DentistSystem>().AsSingle();

			Container.BindInterfacesAndSelfTo<DentistGameStartup>()
				.AsSingle();

			Container.BindFactory<PatientView, PatientView.Factory>()
				.FromComponentInNewPrefab(_dentistViewContainer.PatientView)
				.AsTransient();

			Container.Bind<PatientController>().AsTransient();
		}
	}
}

using UnityEngine;
using XMG.ChildGame.Dentist.Tool;
using XMG.ChildGame.Dentist.WaitingRoom;
using XMG.ChildGame.DentistGame.Patient;
using XMG.ChildGame.Navigation;
using Zenject;

namespace XMG.ChildGame.Dentist
{
	[CreateAssetMenu(fileName = "DentistGameInstaller", menuName = "Installers/DentistGameInstaller")]
	public class DentistGameInstaller : ScriptableObjectInstaller<DentistGameInstaller>
	{
		[SerializeField]
		private AppContainer _appContainer;

		[SerializeField]
		private DentistViewContainer _dentistViewContainer;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<DentistGameStartup>().AsSingle();

			Container.Bind<DentistSystem>().AsSingle();

			Container.BindView<PatientView, PatientView.Factory, PatientController>(_dentistViewContainer.PatientView);
			Container.BindView<ToolSelectorView, ToolSelectorView.Factory, ToolSelectorController>(_dentistViewContainer.ToolSelectorView);
			Container.BindView<WaitingRoomView, WaitingRoomView.Factory, WaitingRoomController>(_dentistViewContainer.WaitingRoomView);
			Container.BindView<NavigationView, NavigationView.Factory, NavigationController>(_appContainer.NavigationView);
		}
	}
}

using UnityEngine;
using XMG.ChildGame.Dentist.Tool;
using XMG.ChildGame.Dentist.WaitingRoom;
using XMG.ChildGame.DentistGame.Patient;

namespace XMG.ChildGame.Dentist
{
	public class DentistGameInstaller : BaseAppInstaller
	{
		[SerializeField]
		private DentistViewContainer _dentistViewContainer;

		public override void InstallBindings()
		{
			base.InstallBindings();
			Container.Bind<DentistSystem>().AsSingle();
			Container.BindInterfacesAndSelfTo<DentistGameStartup>().AsSingle();

			BindFactoryViewWithPresenter<PatientView, PatientPresneter>(Container, _dentistViewContainer.PatientView);
			BindFactoryViewWithPresenter<ToolSelectorView, ToolSelectorPresenter>(Container, _dentistViewContainer.ToolSelectorView);
			BindFactoryViewWithPresenter<WaitingRoomView, WaitingRoomPresenter>(Container, _dentistViewContainer.WaitingRoomView);
		}
	}
}

using UnityEngine;
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
		}
	}
}

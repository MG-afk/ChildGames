using UnityEngine;
using XMG.ChildGame.Navigation;
using Zenject;

namespace XMG.ChildGame
{
	[CreateAssetMenu(fileName = "AppInstaller", menuName = "XMG/AppInstaller")]
	public class AppInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private AppContainer _appContainer;

		public override void InstallBindings()
		{
			Container.Bind<InputControls>().AsSingle();
			Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle();
			Container.Bind<ResourcesSystem>().AsSingle();

			Container.BindView<NavigationView, NavigationView.Factory, NavigationController>(_appContainer.NavigationView);
		}
	}
}

using Dream.Core;
using Dream.Core.Context;
using UnityEngine;
using XMG.ChildGame.Navigation;
using Zenject;

namespace XMG.ChildGame
{
	public abstract class BaseAppInstaller : MonoInstaller
	{
		[SerializeField]
		private AppContainer _container;

		[SerializeField]
		private Transform _sceneContainer;

		[SerializeField]
		private Transform _canvasContainer;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle();
			Container.Bind<ResourcesSystem>().AsSingle();

			Container.BindInterfacesTo<PresenterStageManager>().AsSingle().WithArguments(_sceneContainer, _canvasContainer);
			Container.BindInterfacesTo<SpawnedContext>().AsSingle();

			BindFactoryViewWithPresenter<NavigationView, NavigationPresenter>(Container, _container.NavigationView);

			Container.Bind<CoroutineProvider>().FromNewComponentOnNewGameObject().AsSingle();
			Container.BindInterfacesTo<UpdateContext>().FromNewComponentOnNewGameObject().AsSingle();
		}

		public static void BindFactoryViewWithPresenter<TView, TPreseneter>(DiContainer container, TView view)
			where TView : MonoBehaviour, IView
			where TPreseneter : IPresenter
		{
			container.BindFactory<TView, ViewFactory<TView>>().FromComponentInNewPrefab(view).AsSingle();
			container.Bind<TPreseneter>().AsTransient();
		}
	}
}

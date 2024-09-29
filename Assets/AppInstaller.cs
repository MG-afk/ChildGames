using Dream.Core;
using Dream.Core.Context;
using UnityEngine;
using Zenject;

namespace XMG.ChildGame
{
	public class AppInstaller : MonoInstaller
	{
		[SerializeField]
		private ViewContainer _viewContainer;

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

			BindFactoryViewWithPresenter<GameSelectorView, GameSelectorPresenter>(_viewContainer.GameSelector);

			Container.Bind<CoroutineProvider>().FromNewComponentOnNewGameObject().AsSingle();
			Container.BindInterfacesTo<UpdateContext>().FromNewComponentOnNewGameObject().AsSingle();
		}

		public void BindFactoryViewWithPresenter<TView, TPreseneter>(TView view)
			where TView : MonoBehaviour, IView
			where TPreseneter : IPresenter
		{
			Container.BindFactory<TView, ViewFactory<TView>>().FromComponentInNewPrefab(view).AsSingle();
			Container.Bind<TPreseneter>().AsTransient();
		}
	}
}

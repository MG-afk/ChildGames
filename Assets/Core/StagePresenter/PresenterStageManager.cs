using Dream.Core.Context;
using UnityEngine;
using Zenject;

namespace Dream.Core
{
	public sealed class PresenterStageManager : IPresenterStageManager
	{
		private readonly Transform _sceneContainer;
		private readonly Transform _canvasContainer;
		private readonly DiContainer _diContainer;
		private readonly ISpawnedContext _context;

		private readonly DiContainer _subContainer;

		public PresenterStageManager(
			Transform sceneContainer,
			Transform canvasContainer,
			DiContainer diContainer,
			ISpawnedContext context)
		{
			_sceneContainer = sceneContainer;
			_canvasContainer = canvasContainer;
			_diContainer = diContainer;
			_context = context;

			_subContainer = _diContainer.CreateSubContainer();
		}

		public TPresenter CreatePresenter<TPresenter, TView, TModel>(TModel model)
			where TPresenter : IPresenter
			where TView : MonoBehaviour, IView
			where TModel : IModel
		{
			var id = new LifetimeId(new System.Guid());
			var factory = _subContainer.Resolve<ViewFactory<TView>>();
			var view = factory.Create();
			view.name = typeof(TPresenter).Name;
			view.transform.SetParent(_sceneContainer, false);

			_subContainer.Bind<TView>().FromInstance(view).AsCached().WhenInjectedInto<TPresenter>();
			_subContainer.Bind<TModel>().FromInstance(model).AsCached().WhenInjectedInto<TPresenter>();
			_subContainer.Bind<LifetimeId>().FromInstance(id).AsCached().WhenInjectedInto<TPresenter>();

			var presenter = _subContainer.Instantiate<TPresenter>();
			_context.Register(id, view.gameObject);

			_subContainer.Unbind<TView>();
			_subContainer.Unbind<TModel>();
			_subContainer.Unbind<LifetimeId>();

			return presenter;
		}

		public TPresenter CreatePresenter<TPresenter, TView>()
			where TPresenter : IPresenter
			where TView : MonoBehaviour, IView
		{
			var id = new LifetimeId(new System.Guid());
			var factory = _subContainer.Resolve<ViewFactory<TView>>();
			var view = factory.Create();
			view.name = typeof(TPresenter).Name;
			view.transform.SetParent(_sceneContainer, false);

			_subContainer.Bind<TView>().FromInstance(view).AsCached().WhenInjectedInto<TPresenter>();
			_subContainer.Bind<LifetimeId>().FromInstance(id).AsCached().WhenInjectedInto<TPresenter>();

			var presenter = _subContainer.Instantiate<TPresenter>();
			_context.Register(id, view.gameObject);

			_subContainer.Unbind<TView>();
			_subContainer.Unbind<LifetimeId>();

			return presenter;
		}

		public TPresenter CreatePanelPresenter<TPresenter, TPanel>(bool dontDestoryOnContextClean = false)
			where TPresenter : IPresenter
			where TPanel : MonoBehaviour, IView, IPanel
		{
			var id = new LifetimeId(new System.Guid());
			var factory = _subContainer.Resolve<ViewFactory<TPanel>>();
			var view = factory.Create();
			view.name = typeof(TPresenter).Name;
			view.transform.SetParent(_canvasContainer, false);

			_subContainer.Bind<TPanel>().FromInstance(view).AsCached().WhenInjectedInto<TPresenter>();
			_subContainer.Bind<LifetimeId>().FromInstance(id).AsCached().WhenInjectedInto<TPresenter>();

			var presenter = _subContainer.Instantiate<TPresenter>();

			if (!dontDestoryOnContextClean)
			{
				_context.Register(id, view.gameObject);
			}

			_subContainer.Unbind<TPanel>();
			_subContainer.Unbind<LifetimeId>();

			return presenter;
		}
	}
}

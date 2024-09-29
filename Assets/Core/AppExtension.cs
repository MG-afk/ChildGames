using UnityEngine;
using Zenject;

namespace Dream.Core
{
	public static class AppExtension
	{
		public static void BindFactoryViewWithPresenter<TView, TPreseneter>(this DiContainer container, TView view)
			where TView : MonoBehaviour, IView
			where TPreseneter : IPresenter
		{
			container.BindFactory<TView, ViewFactory<TView>>().FromComponentInNewPrefab(view).AsSingle();
			container.Bind<TPreseneter>().AsTransient();
		}
	}
}
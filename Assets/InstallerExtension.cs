using UnityEngine;
using Zenject;

namespace XMG.ChildGame
{
	public static class InstallerExtension
	{
		public static void BindView<TView, TFactory, TController>(this DiContainer self, GameObject view)
			where TView : BaseView<TController>
			where TController : BaseController
			where TFactory : PlaceholderFactory<TView>

		{
			self.BindFactory<TView, TFactory>()
				.FromComponentInNewPrefab(view)
				.AsTransient();

			self.Bind<TController>().AsTransient();
		}
	}
}
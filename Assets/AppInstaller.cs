using UnityEngine;
using XMG.Core;
using Zenject;

namespace XMG.ChildGame
{
	[CreateAssetMenu(fileName = "AppInstaller", menuName = "XMG/AppInstaller")]
	public class AppInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private AppViewContainer _appViewContainer;

		public override void InstallBindings()
		{
			InstallView();

			Container.Bind<IInitializable>()
				.To<AppStartup>()
				.AsSingle();
		}

		public void InstallView()
		{
			Container.BindFactory<GameSelectorView, GameSelectorView.Factory>()
				.FromComponentInNewPrefab(_appViewContainer.GameSelectorView)
				.AsTransient();

			Container.Bind<GameSelectorController>()
				.AsTransient();
		}
	}
}

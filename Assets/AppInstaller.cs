using UnityEngine;
using Zenject;

namespace XMG.ChildGame
{
	[CreateAssetMenu(fileName = "AppInstaller", menuName = "XMG/AppInstaller")]
	public class AppInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<InputControls>().AsSingle();
			Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle();
		}
	}
}

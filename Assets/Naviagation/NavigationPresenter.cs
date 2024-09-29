using Dream.Core;
using UnityEngine.SceneManagement;

namespace XMG.ChildGame.Navigation
{
	public class NavigationPresenter : BasePresenter<NavigationView>
	{
		private const string MainSceneName = "Main";

		public void BackToMainScene()
		{
			SceneManager.LoadSceneAsync(MainSceneName);
		}
	}
}
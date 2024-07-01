using UnityEngine.SceneManagement;

namespace XMG.ChildGame.Navigation
{
	public class NavigationController : BaseController
	{
		private const string MainSceneName = "Main";

		public void BackToMainScene()
		{
			SceneManager.LoadSceneAsync(MainSceneName);
		}
	}
}
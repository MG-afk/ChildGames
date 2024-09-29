using Dream.Core;
using UnityEngine.SceneManagement;
using Zenject;

namespace XMG.ChildGame.Navigation
{
	public class NavigationPresenter : BasePresenter<NavigationView>
	{
		private const string MainSceneName = "GameSelector";

		[Inject]
		public void Construct()
		{
			View.BackButton.onClick.AddListener(() => BackToMainScene());
		}

		protected override void OnDispose()
		{
			View.BackButton.onClick.RemoveAllListeners();
		}

		public void BackToMainScene()
		{
			SceneManager.LoadSceneAsync(MainSceneName);
		}
	}
}
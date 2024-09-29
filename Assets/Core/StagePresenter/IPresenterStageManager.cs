using UnityEngine;

namespace Dream.Core
{
	public interface IPresenterStageManager
	{
		TPresenter CreatePresenter<TPresenter, TView, TModel>(TModel model)
			where TPresenter : IPresenter
			where TView : MonoBehaviour, IView
			where TModel : IModel;

		TPresenter CreatePresenter<TPresenter, TView>()
			where TPresenter : IPresenter
			where TView : MonoBehaviour, IView;

		TPresenter CreatePanelPresenter<TPresenter, TPanel>(bool dontDestoryOnContextClean = false)
			where TPresenter : IPresenter
			where TPanel : MonoBehaviour, IView, IPanel;
	}
}

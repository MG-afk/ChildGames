using Dream.Core;
using System;
using XMG.ChildGame.Dentist.WaitingRoom;
using XMG.ChildGame.Navigation;
using Zenject;

namespace XMG.ChildGame.Dentist
{
	public class DentistGameStartup : IInitializable, IDisposable
	{
		private readonly IPresenterStageManager _presenterStageManager;

		public DentistGameStartup(IPresenterStageManager presenterStageManager)
		{
			_presenterStageManager = presenterStageManager;
		}

		public void Initialize()
		{
			_presenterStageManager.CreatePanelPresenter<NavigationPresenter, NavigationView>();
			_presenterStageManager.CreatePresenter<WaitingRoomPresenter, WaitingRoomView>();
		}

		public void Dispose()
		{
		}
	}
}
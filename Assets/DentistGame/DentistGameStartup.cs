using System;
using XMG.ChildGame.Dentist.WaitingRoom;
using XMG.ChildGame.Navigation;
using Zenject;

namespace XMG.ChildGame.Dentist
{
	public class DentistGameStartup : IInitializable, IDisposable
	{
		private readonly WaitingRoomView.Factory _waitingRoomFactory;
		private readonly NavigationView.Factory _navigationFactory;

		public DentistGameStartup(
			WaitingRoomView.Factory waitingRoomFactory,
			NavigationView.Factory navigationFactory)
		{
			_waitingRoomFactory = waitingRoomFactory;
			_navigationFactory = navigationFactory;
		}

		public void Initialize()
		{
			_navigationFactory.Create();
			_waitingRoomFactory.Create();
		}

		public void Dispose()
		{
		}
	}
}
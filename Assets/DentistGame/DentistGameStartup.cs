using System;
using XMG.ChildGame.Dentist.WaitingRoom;
using Zenject;

namespace XMG.ChildGame.Dentist
{
	public class DentistGameStartup : IInitializable, IDisposable
	{
		private readonly WaitingRoomView.Factory _waitingRoomFactory;

		public DentistGameStartup(WaitingRoomView.Factory waitingRoomFactory)
		{
			_waitingRoomFactory = waitingRoomFactory;
		}

		public void Initialize()
		{
			_waitingRoomFactory.Create();
		}

		public void Dispose()
		{
		}
	}
}
using System;

namespace Dream.Core
{
	public interface IUpdateContext
	{
		void Subscribe(Action update);
		void Unsubscribe(Action update);
	}
}
using System;

namespace Dream.Core
{
	public interface IView
	{
		event Action Destroyed;
	}
}
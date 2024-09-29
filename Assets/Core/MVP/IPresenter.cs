using System;

namespace Dream.Core
{
	public interface IPresenter : IDisposable
	{
		LifetimeId Id { get; }
	}
}
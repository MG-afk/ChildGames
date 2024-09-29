using UnityEngine;

namespace Dream.Core.Context
{
	public interface ISpawnedContext
	{
		void DestoryAll();
		void Register(LifetimeId id, GameObject gameObject);
		void RealiseAndDestory(LifetimeId id);
	}
}
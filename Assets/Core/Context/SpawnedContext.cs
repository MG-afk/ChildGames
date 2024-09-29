using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dream.Core.Context
{
	public sealed class SpawnedContext : ISpawnedContext
	{
		private readonly Dictionary<LifetimeId, GameObject> _loadedObjects = new();

		public void Register(LifetimeId id, GameObject gameObject)
		{
			_loadedObjects.Add(id, gameObject);
		}

		public void RealiseAndDestory(LifetimeId id)
		{
			if (_loadedObjects.TryGetValue(id, out var gameObject))
			{
				Object.Destroy(gameObject);
				_loadedObjects.Remove(id);
			}
		}

		public void DestoryAll()
		{
			var ids = _loadedObjects.Select(obj => obj.Key).ToArray();

			foreach (var id in ids)
			{
				if (id == null)
					continue;

				RealiseAndDestory(id);
			}

			_loadedObjects.Clear();
		}
	}
}
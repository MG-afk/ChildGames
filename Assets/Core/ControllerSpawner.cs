using Dream.Core.Context;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Dream.Core
{
	public sealed class ControllerSpawner : IControllerSpawner
	{
		//private readonly ControllerContainer _controllerContainer;
		private readonly DiContainer _diContainer;
		private readonly Transform _parent;
		private readonly ISpawnedContext _spawnedContext;

		private readonly Dictionary<Type, MonoBehaviour> _mapper;

		public ControllerSpawner(
			//ControllerContainer controllerContainer,
			DiContainer diContainer,
			ISpawnedContext spawnedContext)
		{
			//_controllerContainer = controllerContainer;
			_diContainer = diContainer;
			_spawnedContext = spawnedContext;

			_mapper = new Dictionary<Type, MonoBehaviour>
			{
				//{ typeof(SpawnPointController), _controllerContainer.SpawnPoint },
				//{ typeof(PortalController), _controllerContainer.Portal },
				//{ typeof(PreviewBuildingController), _controllerContainer.PreviewBuilding },
				//{ typeof(InventoryPanelElementController), _controllerContainer.InventoryPanelElement },
				//{ typeof(ExperienceController), _controllerContainer.Experience },
				//{ typeof(ItemController), _controllerContainer.Item },
				//{ typeof(CoinController), _controllerContainer.Coin },
				//{ typeof(ChestController), _controllerContainer.Chest},
				//{ typeof(DummyEnemyController), _controllerContainer.DummyEnemy},
			};

			_parent = new GameObject().transform;
			_parent.name = "Controllers";
		}

		public TController Spawn<TController>() where TController : MonoBehaviour
		{
			var id = new LifetimeId(Guid.NewGuid());
			var controllerObject = Object.Instantiate(_mapper[typeof(TController)]);

			_diContainer.Inject(controllerObject);
			_spawnedContext.Register(id, controllerObject.gameObject);
			controllerObject.transform.SetParent(_parent);

			return controllerObject.GetComponent<TController>();
		}
	}
}
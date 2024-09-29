using UnityEngine;

namespace Dream.Core
{
	public interface IControllerSpawner
	{
		TController Spawn<TController>() where TController : MonoBehaviour;
	}
}
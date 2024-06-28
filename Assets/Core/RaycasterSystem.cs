using UnityEngine;

namespace XMG.ChildGame
{
	public static class RaycasterSystem
	{
		public static bool RaycastFromMainCamera<T>(out T hitObject, float distance = Mathf.Infinity, int layerMask = Physics2D.DefaultRaycastLayers) where T : Component
		{
			hitObject = null;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray, distance, layerMask);

			if (hit.collider != null)
			{
				hitObject = hit.collider.GetComponent<T>();
				return hitObject != null;
			}

			return false;
		}

		public static T[] RaycastAllFromMainCamera<T>(float distance = Mathf.Infinity, int layerMask = Physics2D.DefaultRaycastLayers) where T : Component
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, distance, layerMask);

			var hitObjects = new System.Collections.Generic.List<T>();
			foreach (var hit in hits)
			{
				T component = hit.collider.GetComponent<T>();
				if (component != null)
				{
					hitObjects.Add(component);
				}
			}

			return hitObjects.ToArray();
		}
	}
}
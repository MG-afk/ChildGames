using System;
using UnityEngine;

namespace Dream.Core
{
	public sealed class UpdateContext : MonoBehaviour, IUpdateContext
	{
		private event Action Updated;

		public void Subscribe(Action update)
		{
			Updated += update;
		}

		public void Unsubscribe(Action update)
		{
			Updated -= update;
		}

		private void Update()
		{
			Updated?.Invoke();
		}
	}
}
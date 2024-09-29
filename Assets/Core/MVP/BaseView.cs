using System;
using UnityEngine;

namespace Dream.Core
{
	public abstract class BaseView : MonoBehaviour, IView
	{
		public event Action Destroyed;

		private void Start()
		{
			Bind();
		}

		protected virtual void Bind()
		{

		}

		protected virtual void BeforeDestroy()
		{

		}

		private void OnDestroy()
		{
			Destroyed?.Invoke();
			BeforeDestroy();
		}
	}
}
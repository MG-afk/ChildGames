using System;
using System.Collections.Generic;

namespace Dream.Core.Context
{
	public sealed class BindingContext : IBindingContext
	{
		private readonly List<Action> _observes = new();

		public void Register(Action disposable)
		{
			_observes.Add(disposable);
		}

		public void Realise()
		{
			foreach (var disposable in _observes)
			{
				disposable?.Invoke();
			}
		}
	}
}
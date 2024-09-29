using System;

namespace Dream.Core.Context
{
	public interface IBindingContext
	{
		void Register(Action disposable);
		void Realise();
	}
}
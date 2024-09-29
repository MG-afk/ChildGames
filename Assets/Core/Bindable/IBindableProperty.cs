using System;

namespace Dream.Core
{
	public interface IBindableProperty<TValue>
	{
		IBindableProperty<TValue> Bind(Action<TValue> callback, bool invokeOnBind = true);
		void Unbind(Action<TValue> callback);
	}
}
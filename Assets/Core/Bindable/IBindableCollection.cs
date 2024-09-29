using System;
using System.Collections.Generic;

namespace Dream.Core
{
	public interface IBindableCollection<TValue>
	{
		event Action<TValue> ItemRemoved;
		event Action<TValue, TValue> ItemChanged;
		event Action Cleared;

		IReadOnlyCollection<TValue> Value { get; }

		void Add(TValue item);
		bool Remove(TValue item);
		void Clear();

		IBindableCollection<TValue> OnAddItem(Action<TValue> callback);
		void UnbindOnAddItem(Action<TValue> callback);
	}
}
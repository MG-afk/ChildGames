using System;
using System.Collections.Generic;

namespace Dream.Core
{
	public sealed class BindableCollection<TValue> : IBindableCollection<TValue>
	{
		public event Action<TValue> ItemRemoved;
		public event Action<TValue, TValue> ItemChanged;
		public event Action Cleared;

		private readonly List<Action<TValue>> _itemAdded = new();
		private readonly List<TValue> _values;

		public IReadOnlyCollection<TValue> Value => _values.AsReadOnly();

		public BindableCollection()
		{
			_values = new();
		}

		public BindableCollection(IEnumerable<TValue> values)
		{
			_values = new(values);
		}

		public void Add(TValue item)
		{
			_values.Add(item);
			foreach (var itemAdded in _itemAdded)
			{
				itemAdded?.Invoke(item);
			}
		}

		public bool Remove(TValue item)
		{
			var removed = _values.Remove(item);
			if (removed)
			{
				ItemRemoved?.Invoke(item);
			}
			return removed;
		}

		public void Clear()
		{
			_values.Clear();
			Cleared?.Invoke();
		}

		public void Replace(TValue oldItem, TValue newItem)
		{
			var index = _values.IndexOf(oldItem);
			if (index != -1)
			{
				_values[index] = newItem;
				ItemChanged?.Invoke(oldItem, newItem);
			}
		}

		public bool Contains(TValue item)
		{
			return _values.Contains(item);
		}

		public int IndexOf(TValue item)
		{
			return _values.IndexOf(item);
		}

		public IBindableCollection<TValue> OnAddItem(Action<TValue> callback)
		{
			_itemAdded.Add(callback);
			return this;
		}

		public void UnbindOnAddItem(Action<TValue> callback)
		{
			if (!_itemAdded.Contains(callback))
				return;

			_itemAdded.Remove(callback);
		}

		public static implicit operator List<TValue>(BindableCollection<TValue> bindableCollection)
		{
			return bindableCollection._values;
		}

		public TValue this[int index]
		{
			get => _values[index];
			set
			{
				var oldItem = _values[index];
				_values[index] = value;
				ItemChanged?.Invoke(oldItem, value);
			}
		}
	}
}
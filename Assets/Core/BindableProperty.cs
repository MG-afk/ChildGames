using System;

namespace XMG.ChildGame
{
	public class BindableProperty<T>
	{
		private event Action<T> OnValueChanged;

		private T _value;

		public T Value
		{
			get => _value;
			set
			{
				var oldValue = _value;
				_value = value;

				if (Equals(_value, oldValue))
					return;

				OnValueChanged?.Invoke(_value);
			}
		}

		public BindableProperty(T value = default)
		{
			_value = value;
		}

		public void AddListener(Action<T> callback)
		{
			OnValueChanged += callback;
		}

		public void RemoveListener(Action<T> callback)
		{
			OnValueChanged -= callback;
		}

		public bool Equals(T? x, T? y)
		{
			return ReferenceEquals(x, y);
		}
	}
}

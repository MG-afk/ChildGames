using System;
using System.Collections.Generic;

namespace Dream.Core
{
	public class BindableEvent : IBindableEvent
	{
		private readonly List<Action> _callbacks = new();

		public IBindableEvent Bind(Action callback, bool invokeOnBind = true)
		{
			_callbacks.Add(callback);

			if (invokeOnBind)
			{
				Invoke();
			}

			return this;
		}

		public void Unbind(Action callback)
		{
			if (!_callbacks.Contains(callback))
				return;

			_callbacks.Remove(callback);
		}

		public void Invoke()
		{
			foreach (var onValueChanged in _callbacks)
			{
				onValueChanged?.Invoke();
			}
		}
	}

	public interface IBindableEvent
	{
		IBindableEvent Bind(Action callback, bool invokeOnBind = true);
		void Invoke();
		void Unbind(Action callback);
	}

	public class BindableProperty<TValue> : IBindableProperty<TValue>
	{
		private readonly List<Action<TValue>> _valueChangedActions = new();

		private TValue _value;

		public TValue Value { get => _value; set => SetValue(value); }

		public BindableProperty(TValue value = default)
		{
			_value = value;
		}

		private void SetValue(TValue value)
		{
			_value = value;

			foreach (var onValueChanged in _valueChangedActions)
			{
				onValueChanged?.Invoke(_value);
			}
		}

		public IBindableProperty<TValue> Bind(Action<TValue> callback, bool invokeOnBind = true)
		{
			_valueChangedActions.Add(callback);

			if (invokeOnBind)
			{
				foreach (var onValueChanged in _valueChangedActions)
				{
					onValueChanged?.Invoke(_value);
				}
			}

			return this;
		}

		public void Unbind(Action<TValue> callback)
		{
			if (!_valueChangedActions.Contains(callback))
				return;

			_valueChangedActions.Remove(callback);
		}

		public static implicit operator TValue(BindableProperty<TValue> property)
		{
			return property._value;
		}
	}
}
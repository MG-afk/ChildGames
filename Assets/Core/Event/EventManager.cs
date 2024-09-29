using System;
using System.Collections.Generic;

namespace Dream.Core.Event
{
	public class EventManager
	{
		private readonly Dictionary<Type, List<Action<object>>> _eventSubscribers = new();

		public void Subscribe<T>(Action<T> handler)
		{
			if (!_eventSubscribers.ContainsKey(typeof(T)))
			{
				_eventSubscribers[typeof(T)] = new List<Action<object>>();
			}

			_eventSubscribers[typeof(T)].Add(obj => handler((T)obj));
		}

		public void Unsubscribe<T>(Action<T> handler)
		{
			if (!_eventSubscribers.ContainsKey(typeof(T)))
				return;

			_eventSubscribers[typeof(T)].Remove(obj => handler((T)obj));

			if (_eventSubscribers[typeof(T)].Count != 0)
				return;

			_eventSubscribers.Remove(typeof(T));
		}

		public void Trigger<T>(T eventData)
		{
			if (!_eventSubscribers.ContainsKey(typeof(T)))
				return;

			foreach (var handler in _eventSubscribers[typeof(T)])
			{
				handler(eventData);
			}
		}
	}
}
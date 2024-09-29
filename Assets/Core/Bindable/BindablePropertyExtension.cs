using Dream.Core.Context;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dream.Core
{
	public static class BindablePropertyExtension
	{
		public static void BindAction(this Button self, UnityAction callback, IBindingContext bindingContext)
		{
			self.onClick.AddListener(callback);
			bindingContext.Register(() => self.onClick.RemoveListener(callback));
		}

		public static void Bind<TValue>(this IBindableProperty<TValue> self, Action<TValue> callback, IBindingContext bindingContext)
		{
			self.Bind(callback);
			bindingContext.Register(() => self.Unbind(callback));
		}

		public static void Bind<TValue>(this IBindableProperty<TValue> self, Action<TValue> callback, bool invokeOnObserve, IBindingContext bindingContext)
		{
			self.Bind(callback, invokeOnObserve);
			bindingContext.Register(() => self.Unbind(callback));
		}

		public static void OnAddItem<TValue>(this IBindableCollection<TValue> self, Action<TValue> callback, IBindingContext bindingContext)
		{
			self.OnAddItem(callback);
			bindingContext.Register(() => self.UnbindOnAddItem(callback));
		}

		public static void Bind(this IBindableEvent self, Action callback, IBindingContext bindingContext)
		{
			self.Bind(callback);
			bindingContext.Register(() => self.Unbind(callback));
		}

		public static void Bind(this IBindableEvent self, Action callback, bool invokeOnObserve, IBindingContext bindingContext)
		{
			self.Bind(callback, invokeOnObserve);
			bindingContext.Register(() => self.Unbind(callback));
		}
	}
}
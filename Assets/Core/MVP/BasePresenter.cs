using Dream.Core.Context;
using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

namespace Dream.Core
{
	public abstract class BasePresenter<TView> : IPresenter, IBindingContext
		where TView : MonoBehaviour, IView
	{
		private readonly BindingContext _context = new();

		protected TView View { get; private set; }
		public LifetimeId Id { get; private set; }

		[Inject, UsedImplicitly]
		private void Construt(TView view, LifetimeId id)
		{
			View = view;
			Id = id;

			View.Destroyed += Dispose;
		}

		protected virtual void OnDispose()
		{

		}

		public void Dispose()
		{
			OnDispose();
			View.Destroyed -= Dispose;
			((IBindingContext)this).Realise();
		}

		void IBindingContext.Realise()
		{
			_context.Realise();
		}

		void IBindingContext.Register(Action disposable)
		{
			_context.Register(disposable);
		}
	}
}
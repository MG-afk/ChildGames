using UnityEngine;
using Zenject;

namespace XMG.ChildGame
{
	public class BaseView<TController> : MonoBehaviour where TController : BaseController
	{
		public TController Controller { get; private set; }

		[Inject]
		public void Contructor(TController controller)
		{
			Controller = controller;

			if (Controller == null)
				throw new System.Exception($"Controller not constructed! { GetType().Name }");

		}

		private void Awake()
		{
			Bind();
		}

		public virtual void Bind()
		{

		}

		public virtual void BeforeDispose()
		{

		}

		public void OnDestroy()
		{
			BeforeDispose();
			Controller.Dispose();
		}
	}
}
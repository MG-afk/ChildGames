using DG.Tweening;
using Dream.Core;
using Dream.XMG;
using UnityEngine;
using Zenject;

namespace XMG.ChildGame.DentistGame.Patient
{
	public class PatientPresneter : BasePresenter<PatientView>
	{
		private IInputProvider _inputProvider;

		public BindableProperty<ToothSubView> ClickedOnTooth { get; } = new();

		[Inject]
		public void Contructor(IInputProvider inputProvider)
		{
			_inputProvider = inputProvider;

			_inputProvider.Clicked += ClickOnTooth;
			ClickedOnTooth.Bind(OnClickOnTooth, false, this);
		}

		protected override void OnDispose()
		{
			_inputProvider.Clicked -= ClickOnTooth;
		}

		private void OnClickOnTooth(ToothSubView tooth)
		{
			tooth.SpriteRenderer.DOColor(Color.yellow, 1f);
		}

		public void ClickOnTooth()
		{
			RaycasterSystem.RaycastFromMainCamera<ToothSubView>(out var tooth);

			if (tooth == null)
				return;

			ClickedOnTooth.Value = tooth;
		}

	}
}

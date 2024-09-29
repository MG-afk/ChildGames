using DG.Tweening;
using Dream.Core;
using UnityEngine;
using XMG.ChildGame.Dentist.WaitingRoom;
using Zenject;

namespace XMG.ChildGame.DentistGame.Patient
{
	public class PatientView : BaseView
	{
		private IInputProvider _inputProvider;

		[Inject]
		public void Contructor(IInputProvider inputProvider)
		{
			_inputProvider = inputProvider;
		}

		protected override void Bind()
		{
			//_inputProvider.Clicked += Controller.ClickOnTooth;
			//Controller.ClickedOnTooth.AddListener(ClickOnTooth);
		}

		protected override void BeforeDestroy()
		{
			//_inputProvider.Clicked -= Controller.ClickOnTooth;
			//Controller.ClickedOnTooth.RemoveListener(ClickOnTooth);
		}

		public void ClickOnTooth(ToothSubView tooth)
		{
			tooth.SpriteRenderer.DOColor(Color.yellow, 1f);
		}

		internal void Init(PatientStartData data)
		{
			//throw new NotImplementedException();
		}

		public sealed class Factory : PlaceholderFactory<PatientView> { }
	}
}

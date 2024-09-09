using DG.Tweening;
using UnityEngine;
using XMG.ChildGame.Dentist.WaitingRoom;
using Zenject;

namespace XMG.ChildGame.DentistGame.Patient
{
	public class PatientView : BaseView<PatientController>
	{
		private InputControls _input;

		[Inject]
		public void Contructor(InputControls input)
		{
			_input = input;
		}

		public override void Bind()
		{
			_input.Player.Click.performed += Controller.ClickOnTooth;
			Controller.ClickedOnTooth.AddListener(ClickOnTooth);
		}

		public override void BeforeDispose()
		{
			_input.Player.Click.performed -= Controller.ClickOnTooth;
			Controller.ClickedOnTooth.RemoveListener(ClickOnTooth);
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

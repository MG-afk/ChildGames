using DG.Tweening;
using UnityEngine;
using Zenject;

namespace XMG.ChildGame.DentistGame.Patient
{
	public class PatientView : BaseView<PatientController>
	{
		private Color _toothColor;

		[SerializeField]
		private SpriteRenderer[] _teeth;

		public override void Bind()
		{
			_toothColor = _teeth[0].color;

			
		}

		public void ClickOnTooth(SpriteRenderer toothSpriteRenderer, bool shouldGrow)
		{
			toothSpriteRenderer.DOColor(Color.yellow, 1f);
		}

		public class Factory : PlaceholderFactory<PatientView> { }
	}
}

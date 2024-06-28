using UnityEngine;

namespace XMG.ChildGame.DentistGame.Patient
{
	public class ToothSubView : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _spriteRenderer;

		public SpriteRenderer SpriteRenderer => _spriteRenderer;

#if UNITY_EDITOR
		private void Reset()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}
#endif
	}
}

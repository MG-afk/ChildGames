using UnityEngine;

namespace XMG.ChildGame.Dentist.Tool
{
	public sealed class ToolSubView : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _spriteRenderer;

		[SerializeField]
		private Collider2D _collider;

		public void Selected()
		{
			_collider.enabled = false;
		}
	}
}
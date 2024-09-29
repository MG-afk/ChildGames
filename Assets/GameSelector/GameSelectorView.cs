using Dream.Core;
using UnityEngine;
using UnityEngine.UI;
using IPanel = Dream.Core.IPanel;

namespace XMG.ChildGame
{
	public sealed class GameSelectorView : BaseView, IPanel
	{
		[field: SerializeField]
		public Button LeftButton { get; private set; }

		[field: SerializeField]
		public Image Image { get; private set; }

		[field: SerializeField]
		public Button RightButton { get; private set; }

		[field: SerializeField]
		public Button PlayButton { get; private set; }
	}
}

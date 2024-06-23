using System;
using UnityEngine;
using Zenject;

namespace XMG.ChildGame
{
	[Serializable]
	public class MiniGame
	{
		public string SceneId;
		public Installer Installer;
		public Sprite PreviewImage;
	}
}
using UnityEngine;
using Zenject;

namespace Dream.Core
{
	public class ViewFactory<TView> : PlaceholderFactory<TView> where TView : MonoBehaviour, IView
	{
	}
}
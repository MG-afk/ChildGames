using Zenject;

namespace XMG.ChildGame
{
	public sealed class InputProvider : IInitializable
	{
		[Inject]
		private readonly InputControls _inputActions;

		public void Initialize()
		{
			_inputActions.Enable();
			_inputActions.Player.Enable();
		}
	}
}
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace XMG.ChildGame
{
	public interface IInputProvider
	{
		event Action Clicked;
		event Action Unclicked;
		event Action PointerMoved;

		Vector2 PointerPosition { get; }
	}

	public sealed class InputProvider :
		IInputProvider,
		InputControls.IPlayerActions,
		IInitializable,
		IDisposable
	{
		public event Action Clicked;
		public event Action Unclicked;
		public event Action PointerMoved;

		private InputControls _inputActions;

		public Vector2 PointerPosition { get; private set; }

		public void Initialize()
		{
			_inputActions = new InputControls();
			_inputActions.Player.SetCallbacks(this);

			_inputActions.Enable();
			_inputActions.Player.Enable();
		}

		public void Dispose()
		{
			_inputActions.Disable();
			_inputActions.Player.Disable();
		}

		public void OnClick(InputAction.CallbackContext context)
		{
			if (context.performed)
				Clicked?.Invoke();

			if (context.canceled)
				Unclicked?.Invoke();
		}

		public void OnPointerPosition(InputAction.CallbackContext context)
		{
			PointerPosition = context.ReadValue<Vector2>();

			PointerMoved?.Invoke();
		}
	}
}

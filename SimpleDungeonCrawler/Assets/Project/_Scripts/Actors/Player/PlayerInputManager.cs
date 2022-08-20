// ######################################################################
// PlayerInputManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using Project.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Actors.Player.Input
{
	public class PlayerInputManager : SingletonMonoBehaviour<PlayerInputManager>
	{
		#region Delegate(s):
		public event Action OnInteractionEvent;
		public event Action OnDashInputEvent;
		public event Action OnPauseInputEvent;
		#endregion

		#region Internal State Field(s):
		private PlayerControl m_playerControl = null;
		#endregion

		#region Properties:
		public Vector2 MovementInput { get; private set; }
		public bool IsSprintInput { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected override void Awake()
		{
			base.Awake();
			m_playerControl = new PlayerControl();
		}

		private void OnEnable()
		{
			m_playerControl.Player.Move.performed += PlayerControl_MovementInputCallback;
			m_playerControl.Player.Interact.performed += PlayerControl_InteractInputCallback;
			m_playerControl.Player.Sprint.performed += PlayerControl_SprintInputCallback;
			m_playerControl.Player.Dash.performed += PlayerControl_DashInputCallback;
			m_playerControl.Player.Pause.performed += PlayerControl_PauseInputCallback;
			m_playerControl.Enable();
		}

		private void OnDisable()
		{
			m_playerControl.Disable();
			m_playerControl.Player.Move.performed -= PlayerControl_MovementInputCallback;
			m_playerControl.Player.Interact.performed -= PlayerControl_InteractInputCallback;
			m_playerControl.Player.Sprint.performed -= PlayerControl_SprintInputCallback;
			m_playerControl.Player.Dash.performed -= PlayerControl_DashInputCallback;
			m_playerControl.Player.Pause.performed -= PlayerControl_PauseInputCallback;
		}
        #endregion

        #region Callback(s):
        private void PlayerControl_MovementInputCallback(InputAction.CallbackContext _context) => 
			MovementInput = _context.ReadValue<Vector2>();

        private void PlayerControl_InteractInputCallback(InputAction.CallbackContext _context) => 
			OnInteractionEvent?.Invoke();

        private void PlayerControl_SprintInputCallback(InputAction.CallbackContext _context) => 
			IsSprintInput = _context.ReadValueAsButton();

        private void PlayerControl_DashInputCallback(InputAction.CallbackContext _context) => 
			OnDashInputEvent?.Invoke();

        private void PlayerControl_PauseInputCallback(InputAction.CallbackContext _context) => 
			OnPauseInputEvent?.Invoke();
        #endregion
    }
}
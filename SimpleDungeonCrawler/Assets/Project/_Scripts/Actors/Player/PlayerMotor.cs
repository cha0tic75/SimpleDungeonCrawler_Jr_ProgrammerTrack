// ######################################################################
// PlayerMotor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Actors.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerMotor : MonoBehaviour, IMovementDataProvider
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_moveSpeed =120f ;
		[SerializeField] private float m_sprintSpeedModifier = 1.4f;
		[SerializeField] private PlayerSprintComponent m_sprintComponent;
		#endregion

		#region Internal State Field(s):
		private Vector2 m_movementInput = Vector2.zero;
		private Rigidbody2D m_rigidbody;
		#endregion

		#region Properties:
		public Vector2 Velocity => m_rigidbody.velocity;
		private float CurrentMoveSpeed => m_moveSpeed * ((m_sprintComponent.IsSprinting) ? m_sprintSpeedModifier : 1f);
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => m_rigidbody = GetComponent<Rigidbody2D>();

        private void Start() => 
				GameManagement.GameManager.Instance.CameraTools.CameraFollow.SetTargetTransform(transform, true);

		private void FixedUpdate() =>			
				m_rigidbody.velocity = Actors.Player.Input.PlayerInputManager.Instance.MovementInput.normalized * CurrentMoveSpeed;
		#endregion
	}
}
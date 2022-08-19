// ######################################################################
// PlayerMotor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Player
{
	// [RequireComponent(typeof(Input.InputManager))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerMotor : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_moveSpeed;
		#endregion

		#region Internal State Field(s):
		private Vector2 m_movementInput = Vector2.zero;
		private Rigidbody2D m_rigidbody;
		#endregion

		#region Properties:
		private float CurrentMoveSpeed => m_moveSpeed;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => m_rigidbody = GetComponent<Rigidbody2D>();
		private void OnEnable() =>
			GetComponent<Input.InputManager>().OnMovementInputEvent += InputManager_OnMovementInputCallback;
		
		private void OnDisable() =>
			GetComponent<Input.InputManager>().OnMovementInputEvent -= InputManager_OnMovementInputCallback;

        private void Start() => 
				GameManagement.GameManager.Instance.CameraTools.CameraFollow.SetTargetTransform(transform, true);

		private void FixedUpdate() => 
			m_rigidbody.velocity = new Vector2(m_movementInput.x, m_movementInput.y) * Time.fixedDeltaTime * CurrentMoveSpeed;
		#endregion

		#region Callback(s):
        private void InputManager_OnMovementInputCallback(Vector2 _movementInput) => m_movementInput = _movementInput;
		#endregion
	}
}
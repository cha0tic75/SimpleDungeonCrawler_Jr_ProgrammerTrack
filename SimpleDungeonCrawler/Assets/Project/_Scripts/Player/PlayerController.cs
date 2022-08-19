// ######################################################################
// PlayerController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerController : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_moveSpeed;
		#endregion

		#region Internal State Field(s):
		private Vector2 m_movementInput = Vector2.zero;
		private Rigidbody2D m_rigidbody;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => m_rigidbody = GetComponent<Rigidbody2D>();
		private void Start() => 
				GameManagement.GameManager.Instance.CameraTools.CameraFollow.SetTargetTransform(transform, true);

		private void Update()
		{
			m_movementInput.x = Input.GetAxisRaw("Horizontal");
			m_movementInput.y = Input.GetAxisRaw("Vertical");
		}

		private void FixedUpdate()
		{
			m_rigidbody.velocity = new Vector2(m_movementInput.x, m_movementInput.y) * Time.fixedDeltaTime * m_moveSpeed;
		}
		#endregion
	}
}
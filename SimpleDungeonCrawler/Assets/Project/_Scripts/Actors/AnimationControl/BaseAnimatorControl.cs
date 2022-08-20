// ######################################################################
// BaseAnimatorControl - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Actors
{
    [RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(IMovementDataProvider))]
	public class BaseAnimatorControl : MonoBehaviour
	{
		#region Internal State Field(s):
		protected Animator m_animator;
		private IMovementDataProvider m_movementDataProvider;
		private static int s_movementSpeedFloatAnimParam = Animator.StringToHash("MovementSpeed");
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake()
		{
			m_animator = GetComponent<Animator>();
			m_movementDataProvider = GetComponent<IMovementDataProvider>();
		}

		private void Update() =>
			m_animator?.SetFloat(s_movementSpeedFloatAnimParam, m_movementDataProvider.Velocity.magnitude);
		#endregion
	}
}

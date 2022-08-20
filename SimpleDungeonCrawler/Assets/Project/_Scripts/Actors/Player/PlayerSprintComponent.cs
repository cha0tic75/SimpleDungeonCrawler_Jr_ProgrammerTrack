// ######################################################################
// PlayerSprintComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Actors.Player
{
	public class PlayerSprintComponent : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_sprintCost = 1f;
		[SerializeField] private Stats.StatComponent m_statComponent;
		#endregion

		#region Internal State Field(s):
		private bool m_sprintInput;
		#endregion

		#region Properties:
		public bool IsSprinting { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
        private void Update()
		{
			float sprintCostDelta = m_sprintCost * Time.deltaTime;
            IsSprinting = Actors.Player.Input.PlayerInputManager.Instance.IsSprintInput && m_statComponent.CurrentValue > sprintCostDelta;
			
			if (!IsSprinting) { return; }

			m_statComponent.Consume(sprintCostDelta, Actors.Stats.StatConsumeType.Use);
		}
		#endregion
	}
}
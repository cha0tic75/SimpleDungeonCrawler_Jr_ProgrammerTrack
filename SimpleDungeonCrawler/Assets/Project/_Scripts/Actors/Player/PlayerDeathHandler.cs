// ######################################################################
// PlayerDeathHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Actors.Player
{
    public class PlayerDeathHandler : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Stats.StatComponent m_healthStatComponent;
		[SerializeField] private List<Effects.BaseEffect_SO> m_deathEffects;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			if (m_healthStatComponent == null)
			{
				Debug.LogError("PlayerDeathHandler is missing a reference to the Health Stat Component");
				return;
			}

			m_healthStatComponent.OnTakeDamageEvent += HealthStatComponent_OnTakeDamageCallback;
		}

		private void OnDisable()
		{
			if (m_healthStatComponent != null)
			{
				m_healthStatComponent.OnTakeDamageEvent -= HealthStatComponent_OnTakeDamageCallback;
			}	
		}
        #endregion

		#region Internally Used Method(s):
        private void HandleDeath()
        {
            m_deathEffects.ForEach(de => de.PerformEffect(gameObject));
            GameManagement.GameManager.Instance.ChangeGameState(GameManagement.GameState.Death);
            gameObject.SetActive(false);
        }
		#endregion

		#region Callback(s):
        private void HealthStatComponent_OnTakeDamageCallback(float _damageAmount, Stats.StatComponent _statComponent)
        {
            if (_statComponent.CurrentValue <= 0f)
            {
                HandleDeath();
            }
        }
        #endregion
    }
}

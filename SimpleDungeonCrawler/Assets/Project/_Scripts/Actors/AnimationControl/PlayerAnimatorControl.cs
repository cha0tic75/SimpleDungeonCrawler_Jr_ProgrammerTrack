// ######################################################################
// PlayerAnimatorControl - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Actors
{
    public class PlayerAnimatorControl : BaseAnimatorControl
	{
		#region Internal State Field(s):
		private static int s_takeDamageTriggerAnimParam = Animator.StringToHash("TakeDamage");
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			Stats.IDamagable[] damagables = GetComponents<Stats.IDamagable>();
			foreach (var damagable in damagables)
			{
				damagable.OnTakeDamageEvent += StatComponent_OnTakeDamageCallback;
			}
		}

		private void OnDisable()
		{
			Stats.IDamagable[] damagables = GetComponents<Stats.IDamagable>();
			foreach (var damagable in damagables)
			{
				damagable.OnTakeDamageEvent -= StatComponent_OnTakeDamageCallback;
			}
		}
		#endregion

		#region Callback(s):
		private void StatComponent_OnTakeDamageCallback(float _amount, Stats.StatComponent _stat) => 
			m_animator.SetTrigger(s_takeDamageTriggerAnimParam);
		#endregion
	}
}

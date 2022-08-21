// ######################################################################
// OldBaseDamageDealerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Damage
{
    // TODO: Refactor this so it derives from BaseHandler
    public abstract class OldBaseDamageDealerHandler : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private bool m_hideOnExit = false;
		[SerializeField] protected MinMaxFloat m_damageRange;
		[SerializeField] protected List<Effects.BaseEffect_SO> m_damageEffects = new List<Effects.BaseEffect_SO>();
		#endregion

		#region Public API:
		public abstract void HandleOnEnterDamage(Actors.Stats.IDamagable _damagable);
		public virtual void HandleOnExitDamage(Actors.Stats.IDamagable _damagable)
		{
			if (m_hideOnExit) { gameObject.SetActive(false); }
		}
		#endregion
	}
}
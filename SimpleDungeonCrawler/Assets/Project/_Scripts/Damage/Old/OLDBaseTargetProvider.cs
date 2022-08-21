// ######################################################################
// OLDBaseTargetProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Damage
{
    public abstract class OLDBaseTargetProvider : MonoBehaviour
	{
		#region Delegate(s):
		public event Action<Actors.Stats.IDamagable> OnTargetableEnterEvent;
		public event Action<Actors.Stats.IDamagable> OnTargetableExitEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] protected List<Actors.Stats.StatType_SO> m_targetStatType;
		#endregion

		#region Internally Used Method(s):
		protected void HandleOnEnter(Collider2D _collider)
		{
			if (!TargetStatTypeCheck()) { return; }

			Actors.Stats.IDamagable[] damagables = _collider.GetComponents<Actors.Stats.IDamagable>();
			foreach (var damagable in damagables)
			{
				if (!m_targetStatType.Contains(damagable.StatType)) { continue; }
				OnTargetableEnterEvent?.Invoke(damagable);
			}
		}
		protected void HandleOnExit(Collider2D _collider)
		{
			if (!TargetStatTypeCheck()) { return; }

			Actors.Stats.IDamagable[] damagables = _collider.GetComponents<Actors.Stats.IDamagable>();
			foreach (var damagable in damagables)
			{
				if (!m_targetStatType.Contains(damagable.StatType)) { continue; }
				OnTargetableExitEvent?.Invoke(damagable);
			}
		}

		private bool TargetStatTypeCheck()
		{
			if (m_targetStatType == null || m_targetStatType.Count == 0) 
			{
				Debug.Log($"{transform.name} is missing at least one reference to a DamageStatType");
				return false; 
			}

			return true;
		}
		#endregion
	}
}
// ######################################################################
// OldDamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Damage
{
    public class OldDamageDealer : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private OLDBaseTargetProvider m_damagableProvider;
		[SerializeField] private List<OldBaseDamageDealerHandler> m_damageDealerHandlers = new List<OldBaseDamageDealerHandler>();
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			if (m_damagableProvider == null) {  m_damagableProvider = GetComponent<OLDBaseTargetProvider>(); }
			if (m_damagableProvider == null)
			{
				Debug.LogError($"{transform.name} is missing a damagable provider!");
				return;
			}

			m_damagableProvider.OnTargetableEnterEvent += DamagableProvider_OnDamagableEnterCallback;
			m_damagableProvider.OnTargetableExitEvent += DamagableProvider_OnDamagableExitCallback;

			if (m_damageDealerHandlers.Count == 0) 
			{
				GetComponents<OldBaseDamageDealerHandler>(results: m_damageDealerHandlers);
			}
		}

		private void OnDisable()
		{
			if (m_damagableProvider == null) { return; }

			m_damagableProvider.OnTargetableEnterEvent -= DamagableProvider_OnDamagableEnterCallback;
			m_damagableProvider.OnTargetableExitEvent -= DamagableProvider_OnDamagableExitCallback;
		}
        #endregion

        #region Callback(s):
        private void DamagableProvider_OnDamagableEnterCallback(Actors.Stats.IDamagable _damagable) => 
			m_damageDealerHandlers.ForEach(ddh => ddh.HandleOnEnterDamage(_damagable));

        private void DamagableProvider_OnDamagableExitCallback(Actors.Stats.IDamagable _damagable) =>
			m_damageDealerHandlers.ForEach(ddh => ddh.HandleOnExitDamage(_damagable));
		#endregion
	}
}
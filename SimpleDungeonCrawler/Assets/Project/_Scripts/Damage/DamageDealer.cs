// ######################################################################
// DamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using System.Linq;
using Project.Actors.Stats;
using Project.Targeting;
using UnityEngine;

namespace Project.Damage
{

    [RequireComponent(typeof(Targeting.BaseTargetProvider<Actors.Stats.IDamagable>))]
    public class DamageDealer : MonoBehaviour
	{
        #region Inspector Assigned Field(s):
        [SerializeField] private List<BaseDamageDealerHandler> m_damageDealerHandlers;
        #endregion

        #region Internal State Field(s):
        private Targeting.BaseTargetProvider<Actors.Stats.IDamagable> m_targetProvider;
        #endregion

        #region MonoBehaviour(s):
        private void Awake()
        {
            m_targetProvider = GetComponent<Targeting.BaseTargetProvider<Actors.Stats.IDamagable>>();
            if (m_damageDealerHandlers == null || m_damageDealerHandlers.Count == 0)
            {
                m_damageDealerHandlers = GetComponents<BaseDamageDealerHandler>().ToList();
            }
        }
        private void OnEnable()
        {
            m_targetProvider.OnTargetedEvent += TargetProvider_OnTargetedCallback;
        }

        private void OnDisable()
        {
            if (m_targetProvider == null) { return; }
            
            m_targetProvider.OnTargetedEvent -= TargetProvider_OnTargetedCallback;
        }
        #endregion

        #region Callback(s):
        private void TargetProvider_OnTargetedCallback(IDamagable[] _damagables, TargetAcquisitionType _acquisitionType)
        {
            List<Actors.Stats.IDamagable> damagables = _damagables.ToList();
            m_damageDealerHandlers.ForEach(dh => dh.HandleDamage(damagables, _acquisitionType));
        }
        #endregion
    }
}
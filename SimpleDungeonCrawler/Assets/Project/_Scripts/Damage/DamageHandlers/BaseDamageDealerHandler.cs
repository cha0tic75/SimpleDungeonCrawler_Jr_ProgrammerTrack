// ######################################################################
// DamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;
using Project.Targeting;
using Project.Actors.Stats;

namespace Project.Damage
{
    public abstract class BaseDamageDealerHandler : MonoBehaviour
    {
        #region Inspector Assigned Field(s):
        [SerializeField] protected Actors.Stats.StatType_SO m_statType;
        [SerializeField] private TargetAcquisitionType m_acquisitionType;
        [SerializeField] protected MinMaxFloat m_damageRange = new MinMaxFloat(0f, 1f);
        [SerializeField] protected List<Effects.BaseEffect_SO> m_damageEffects;
        #endregion

        #region Public API:
        public void HandleDamage(List<Actors.Stats.IDamagable> _damagables, TargetAcquisitionType _acquisitionType)
        {
            if (!m_acquisitionType.HasFlag(_acquisitionType)) { return; }
            
            List<Actors.Stats.IDamagable> damagables = _damagables.FindAll(d => d.StatType == m_statType);
            if (damagables.Count > 0)
            {
                DealDamage(damagables, _acquisitionType);
            }
        }
        #endregion

        #region Internally Used Method(s):
        protected abstract void DealDamage(List<IDamagable> _damagables, TargetAcquisitionType _acquisitionType);
        #endregion
    }
}
// ######################################################################
// BaseDamageDealerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using Project.Actors.Stats;
using UnityEngine;

namespace Project.Damage
{
    public abstract class BaseDamageDealerHandler : MonoBehaviour
    {
        #region Inspector Assigned Field(s):
        [SerializeField] protected Actors.Stats.StatType_SO m_statType;
        [SerializeField] private CollisionAcquisitionType m_acquisitionType;
        [SerializeField] protected MinMaxFloat m_damageRange = new MinMaxFloat(0f, 1f);
        [SerializeField] protected List<Effects.BaseEffect_SO> m_damageEffects;
        #endregion

        #region Public API:
        public void HandleDamage(IDamagable _damagable, CollisionAcquisitionType _acquisitionType)
        {
            if (!m_acquisitionType.HasFlag(_acquisitionType) || _damagable.StatType != m_statType) { return; }

            DealDamage(_damagable, _acquisitionType);
        }
        #endregion

        #region Internally Used Method(s):
        protected abstract void DealDamage(IDamagable _damagable, CollisionAcquisitionType _acquisitionType);
        #endregion
    }
}
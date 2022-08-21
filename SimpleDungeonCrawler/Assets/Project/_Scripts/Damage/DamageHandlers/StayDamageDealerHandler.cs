// ######################################################################
// StayDamageDealerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Project.Actors.Stats;
using UnityEngine;

namespace Project.Damage
{
    public class StayDamageDealerHandler : BaseDamageDealerHandler
    {
        #region Inspector Assigned Field(s):
        [SerializeField] private float m_damageFrequency = 0.5f;
        #endregion

        #region Internal State Field(s):
        private Coroutine m_damageCoroutine = null;
        private List<IDamagable> m_currentDamagables = new List<IDamagable>();
        #endregion
 
        #region Internally Used Method(s):
        protected override void DealDamage(List<IDamagable> _damagables, Targeting.TargetAcquisitionType _acquisitionType)
        {
            switch(_acquisitionType)
            {
                case Targeting.TargetAcquisitionType.OnEnter:
                    HandleOnEnter(_damagables);
                    break;
                
                case Targeting.TargetAcquisitionType.OnExit:
                    HandleOnExit(_damagables);
                    break;
                
                default:
                    break;
            }
        }

        private void HandleOnEnter(List<IDamagable> _damagables)
        {
            foreach (var damagable in _damagables)
            {
                if (!m_currentDamagables.Contains(damagable))
                {
                    m_currentDamagables.Add(damagable);
                }
            }

            if (m_currentDamagables.Count > 0 && m_damageCoroutine == null)
            {
                m_damageCoroutine = StartCoroutine(DealDamageOverTimeCoroutine());
            }

        }

        private void HandleOnExit(List<IDamagable> _damagables)
        {
            _damagables.ForEach(d => m_currentDamagables.Remove(d));

            if (_damagables.Count == 0)
            {
                HelperMethods.StopCoroutineIfRunning(ref m_damageCoroutine, this);
            }
        }
        #endregion

        #region Coroutine(s):
        private IEnumerator DealDamageOverTimeCoroutine()
        {
            while (true)
            {
                List<IDamagable> currentDamagables = m_currentDamagables.ToList();
                foreach (var damagable in currentDamagables)
                {
                    damagable.Consume(m_damageRange.GetRandomValueInRange(), Actors.Stats.StatConsumeType.Damage);
                    yield return null;
                }

                yield return HelperMethods.CustomWFS(m_damageFrequency);
            }
        }
        #endregion
    }
}
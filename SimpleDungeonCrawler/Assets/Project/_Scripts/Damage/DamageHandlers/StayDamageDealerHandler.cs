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

        #region MonoBehaviour Callback Method(s):
        private void OnDisable()
        {
            HelperMethods.StopCoroutineIfRunning(ref m_damageCoroutine, this);
        }
        #endregion
 
        #region Internally Used Method(s):
        protected override void DealDamage(IDamagable _damagable, CollisionAcquisitionType _acquisitionType)
        {
            switch(_acquisitionType)
            {
                case CollisionAcquisitionType.OnEnter:
                    HandleOnEnter(_damagable);
                    break;
                
                case CollisionAcquisitionType.OnExit:
                    HandleOnExit(_damagable);
                    break;
                
                default:
                    break;
            }
        }

        private void HandleOnEnter(IDamagable _damagable)
        {
            if (!m_currentDamagables.Contains(_damagable))
            {
                m_currentDamagables.Add(_damagable);
            }

            if (m_currentDamagables.Count > 0 && m_damageCoroutine == null)
            {
                m_damageCoroutine = StartCoroutine(DealDamageOverTimeCoroutine());
            }
        }

        private void HandleOnExit(IDamagable _damagable)
        {
            m_currentDamagables.Remove(_damagable);

            if (m_currentDamagables.Count == 0)
            {
                HelperMethods.StopCoroutineIfRunning(ref m_damageCoroutine, this);
            }
        }
        #endregion

        #region Coroutine(s):
        private IEnumerator DealDamageOverTimeCoroutine()
        {
            while (m_currentDamagables.Count > 0)
            {
                List<IDamagable> currentDamagables = m_currentDamagables.ToList();
                foreach (var damagable in currentDamagables)
                {
                    float rndDamage = m_damageRange.GetRandomValueInRange();
                    if (rndDamage > 0f)
                    {
                        damagable.Consume(rndDamage, Actors.Stats.StatConsumeType.Damage);
                    }

                    yield return null;
                }

                yield return HelperMethods.CustomWFS(m_damageFrequency);
            }
            m_damageCoroutine = null;
        }
        #endregion
    }
}
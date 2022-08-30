// ######################################################################
// DamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using System.Linq;
using Project.Actors.Stats;
using UnityEngine;

namespace Project.Damage
{
    public class DamageDealer : MonoBehaviour
    {
        #region Inspector Assigned Field(s):
        [SerializeField] private BaseColliderNotifier m_baseColliderNotifier;
        [SerializeField] private List<BaseDamageDealerHandler> m_damageDealerHandlers;
        #endregion

        #region Internal State Field(s):
        #endregion

        #region MonoBehaviour(s):
        private void Awake()
        {
            if (m_damageDealerHandlers == null || m_damageDealerHandlers.Count == 0)
            {
                m_damageDealerHandlers = GetComponents<BaseDamageDealerHandler>().ToList();
            }
        }
        private void OnEnable()
        {
            m_baseColliderNotifier.OnEnterEvent += ColliderNotifier_OnEnterCallback;
            m_baseColliderNotifier.OnExitEvent += ColliderNotifier_OnExitCallback;
        }

        private void OnDisable()
        {
            if (m_baseColliderNotifier == null) { return; }
            
            m_baseColliderNotifier.OnEnterEvent -= ColliderNotifier_OnEnterCallback;
            m_baseColliderNotifier.OnExitEvent -= ColliderNotifier_OnExitCallback;
        }
        #endregion

        #region Callback(s):
        private void ColliderNotifier_OnEnterCallback(Collider2D _collider)
        {
            if (_collider.TryGetComponent<IDamagable>(out var damagable))
            {
                m_damageDealerHandlers.ForEach(dh => dh.HandleDamage(damagable, CollisionAcquisitionType.OnEnter));
            }
        }

        private void ColliderNotifier_OnExitCallback(Collider2D _collider)
        {
            if (_collider.TryGetComponent<IDamagable>(out var damagable))
            {
                m_damageDealerHandlers.ForEach(dh => dh.HandleDamage(damagable, CollisionAcquisitionType.OnExit));
            }
        }
        #endregion
    } 
}
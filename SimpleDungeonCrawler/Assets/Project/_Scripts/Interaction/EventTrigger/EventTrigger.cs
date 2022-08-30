// ######################################################################
// EventTrigger - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Interaction
{
    public class EventTrigger : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private CollisionAcquisitionType m_acquisitionType;
		[SerializeField] private BaseColliderNotifier m_colliderNotifier;
		[SerializeField] private List<BaseEventTriggerHandler> m_eventTriggerHandlers;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			if (m_acquisitionType.HasFlag(CollisionAcquisitionType.OnEnter))
			{
				m_colliderNotifier.OnEnterEvent += CollisionNotifier_OnEnterCallback;
			}
			if (m_acquisitionType.HasFlag(CollisionAcquisitionType.OnExit))
			{
				m_colliderNotifier.OnExitEvent += CollisionNotifier_OnExitCallback;
			}
		}

		private void OnDisable()
		{
			if (m_acquisitionType.HasFlag(CollisionAcquisitionType.OnEnter))
			{
				m_colliderNotifier.OnEnterEvent -= CollisionNotifier_OnEnterCallback;
			}
			if (m_acquisitionType.HasFlag(CollisionAcquisitionType.OnExit))
			{
				m_colliderNotifier.OnExitEvent -= CollisionNotifier_OnExitCallback;
			}
		}
		#endregion

		#region Callback(s):
        private void CollisionNotifier_OnEnterCallback(Collider2D _collider)
        {
			if (_collider.TryGetComponent<Actors.Player.PlayerMotor>(out var playerMotor))
			{
				m_eventTriggerHandlers.ForEach(eth => eth.HandleEventTrigger(CollisionAcquisitionType.OnEnter));
			}
        }

        private void CollisionNotifier_OnExitCallback(Collider2D _collider)
        {
 			if (_collider.TryGetComponent<Actors.Player.PlayerMotor>(out var playerMotor))
			{
				m_eventTriggerHandlers.ForEach(eth => eth.HandleEventTrigger(CollisionAcquisitionType.OnExit));
			}
        }
        #endregion
    }
}

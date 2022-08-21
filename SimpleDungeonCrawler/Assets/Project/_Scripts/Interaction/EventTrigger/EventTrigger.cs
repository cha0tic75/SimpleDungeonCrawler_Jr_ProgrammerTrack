// ######################################################################
// EventTrigger - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using Project.Actors.Player;
using Project.Targeting;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Interaction
{
    [RequireComponent(typeof(Targeting.BaseTargetProvider<Actors.Player.PlayerMotor>))]
	public class EventTrigger : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private TargetAcquisitionType m_acquisitionType;
		[SerializeField] private List<EventTriggerHandler> m_eventTriggerHandlers;
		#endregion

		#region Internal State Field(s):
		private Targeting.BaseTargetProvider<Actors.Player.PlayerMotor> m_eventTriggerTargetProvider;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => 
				m_eventTriggerTargetProvider = GetComponent<Targeting.BaseTargetProvider<Actors.Player.PlayerMotor>>();

		private void OnEnable() => 
				m_eventTriggerTargetProvider.OnTargetedEvent += EventTriggerTargetProvider_OnTargetedCallback;

		private void OnDisable()
		{
			if (m_eventTriggerTargetProvider == null) { return; }
			m_eventTriggerTargetProvider.OnTargetedEvent += EventTriggerTargetProvider_OnTargetedCallback;
		}
		#endregion

		#region Callback(s):
        private void EventTriggerTargetProvider_OnTargetedCallback(PlayerMotor[] _playerMotors, TargetAcquisitionType _targetAcquisitionType)
		{
			if (_playerMotors == null || _playerMotors.Length == 0) { return; }
			if (_targetAcquisitionType != m_acquisitionType) { return; }

			foreach (var eventTriggerHandler in m_eventTriggerHandlers)
			{
				eventTriggerHandler.Handle();
			}
		} 
		#endregion
	}
}

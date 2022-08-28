// ######################################################################
// UnityEventTriggerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Interaction
{
    public class UnityEventTriggerHandler : BaseEventTriggerHandler
    {
        #region Inspector Assigned Field(s):
        [SerializeField] private UnityEngine.Events.UnityEvent m_event;
        #endregion

        #region  Public API:
        public override void Handle() => m_event?.Invoke();
        #endregion
    }
}
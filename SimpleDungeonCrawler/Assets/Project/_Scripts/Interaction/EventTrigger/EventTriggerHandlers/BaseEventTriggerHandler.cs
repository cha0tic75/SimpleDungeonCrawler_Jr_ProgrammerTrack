// ######################################################################
// BaseEventTriggerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Interaction
{
    public abstract class BaseEventTriggerHandler : MonoBehaviour
    {
        #region Inspector Assigned Field(s):
        [SerializeField] private CollisionAcquisitionType m_acquisitionType;
        #endregion

        #region Public API:
        public void HandleEventTrigger(CollisionAcquisitionType _acquisitionType)
        {
            if (!m_acquisitionType.HasFlag(_acquisitionType)) { return; }
            Handle();
        }
        public abstract void Handle();
        #endregion
    }
}

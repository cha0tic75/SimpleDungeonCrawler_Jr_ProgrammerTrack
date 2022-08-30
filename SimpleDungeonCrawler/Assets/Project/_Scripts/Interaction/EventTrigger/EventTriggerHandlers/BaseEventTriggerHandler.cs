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
        [SerializeField] protected CollisionAcquisitionType m_acquisitionType;
        #endregion

        #region Public API:
        public virtual void HandleEventTrigger(CollisionAcquisitionType _acquisitionType)
        {
            if (!m_acquisitionType.HasFlag(_acquisitionType)) { return; }

            Perform();
        }

        public abstract void Perform();
        #endregion
    }
}

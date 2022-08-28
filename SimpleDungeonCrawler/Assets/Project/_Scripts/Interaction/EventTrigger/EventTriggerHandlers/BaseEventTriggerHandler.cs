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
        #region Public API:
        public abstract void Handle();
        #endregion
    }
}

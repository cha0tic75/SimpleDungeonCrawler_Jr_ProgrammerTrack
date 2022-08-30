// ######################################################################
// TriggerTargetProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Targeting
{
    public class TriggerTargetProvider<T> : BaseTargetProvider<T>
    {
        #region MonoBehaviour Callback Method(s):
        private void OnTriggerEnter2D(Collider2D _collider)
        {
            T[] objArray = _collider.GetComponents<T>();
            if (objArray.Length > 0) { InvokeOnTargetEvent(objArray, TargetAcquisitionType.OnEnter); }
        }

        private void OnTriggerExit2D(Collider2D _collider)
        {
            T[] objArray = _collider.GetComponents<T>();
            if (objArray.Length > 0) { InvokeOnTargetEvent(objArray, TargetAcquisitionType.OnExit); }
        }
        #endregion
    }
}
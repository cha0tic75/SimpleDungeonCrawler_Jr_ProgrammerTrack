// ######################################################################
// ColliderTargetProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Targeting
{
    public class ColliderTargetProvider<T> : BaseTargetProvider<T>
    {
        #region MonoBehaviour Callback Method(s):
        private void OnCollisionEnter2D(Collision2D _collision)
        {
            T[] objArray = _collision.collider.GetComponents<T>();
            if (objArray.Length > 0) { InvokeOnTargetEvent(objArray, TargetAcquisitionType.OnEnter); }
        }

        private void OnCollisionExit2D(Collision2D _collision)
        {
            T[] objArray = _collision.collider.GetComponents<T>();
            if (objArray.Length > 0) { InvokeOnTargetEvent(objArray, TargetAcquisitionType.OnExit); }
        }
        #endregion
    }
}
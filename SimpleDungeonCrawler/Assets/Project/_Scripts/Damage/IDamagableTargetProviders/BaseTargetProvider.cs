// ######################################################################
// DamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Damage
{
    public abstract class BaseTargetProvider<T> : MonoBehaviour, IColliderTargetProvider<T[]>
    {
        #region Delegate(s):
        public event Action<T[], TargetAcquisitionType> OnTargetUpdatedEvent;
        #endregion

        #region Internally Used Method(s):
        protected void InvokeOnTargetUpdatedEvent(T[] _t, TargetAcquisitionType _acquisitionType) => 
                OnTargetUpdatedEvent?.Invoke(_t, _acquisitionType);
        #endregion
    }
}
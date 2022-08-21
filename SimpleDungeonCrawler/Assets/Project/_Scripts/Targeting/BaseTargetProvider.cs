// ######################################################################
// BaseTargetProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Targeting
{
    [System.Flags]
    public enum TargetAcquisitionType
    {
        None = 0,
        OnEnter = 1, 
        OnExit = 2,
        All = ~1,
    }

    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseTargetProvider<T> : MonoBehaviour
    {
        #region Delegate(s):
        public event Action<T[], TargetAcquisitionType> OnTargetedEvent;
        #endregion

        #region Internally Used Method(s):
        protected void InvokeOnTargetEvent(T[] _objArray, TargetAcquisitionType _targetAcquisitionType) => 
            OnTargetedEvent?.Invoke(_objArray, _targetAcquisitionType);
        #endregion
    }
}
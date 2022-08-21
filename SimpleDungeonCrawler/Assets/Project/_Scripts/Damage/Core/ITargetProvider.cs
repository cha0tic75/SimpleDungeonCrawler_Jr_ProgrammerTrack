// ######################################################################
// ITargetProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;

namespace Project.Damage
{
    public enum TargetAcquisitionType { OnEnter, OnExit }
    public interface ITargetProvider
    {

    }
    public interface IColliderTargetProvider<T> : ITargetProvider
    {
        #region Delegate(s):
        event Action<T, TargetAcquisitionType> OnTargetUpdatedEvent;
        #endregion
    }
}
// ######################################################################
// DamageTriggerTargetProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Damage
{
    [RequireComponent(typeof(Collider2D))]
    public class DamageTriggerTargetProvider : BaseTargetProvider<Actors.Stats.IDamagable>
    {
        #region MonoBehaviour Callback Method(s):
        private void OnTriggerEnter2D(Collider2D _collider) 
        {
            Actors.Stats.IDamagable[] damagables =  _collider.GetComponents<Actors.Stats.IDamagable>();
            if (damagables != null && damagables.Length > 0)
            {
                InvokeOnTargetUpdatedEvent(damagables, TargetAcquisitionType.OnEnter);
            }
        }

        private void OnTriggerExit2D(Collider2D _collider) 
        {
            Actors.Stats.IDamagable[] damagables =  _collider.GetComponents<Actors.Stats.IDamagable>();
            if (damagables != null && damagables.Length > 0)
            {
                InvokeOnTargetUpdatedEvent(damagables, TargetAcquisitionType.OnExit);
            }
        }
        #endregion
    }
}
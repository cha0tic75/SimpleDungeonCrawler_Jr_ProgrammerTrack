// ######################################################################
// DamageCollisionTargetProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Damage
{
    [RequireComponent(typeof(Collider2D))]
    public class DamageCollisionTargetProvider : BaseTargetProvider<Actors.Stats.IDamagable>
    {

        #region MonoBehaviour Callback Method(s):
        private void OnCollisionEnter2D(Collision2D _collision) 
        {
            Actors.Stats.IDamagable[] damagables =  _collision.collider.GetComponents<Actors.Stats.IDamagable>();
            if (damagables != null && damagables.Length > 0)
            {
                InvokeOnTargetUpdatedEvent(damagables, TargetAcquisitionType.OnEnter);
            }
        }

        private void OnCollisionExit2D(Collision2D _collision) 
        {
            Actors.Stats.IDamagable[] damagables =  _collision.collider.GetComponents<Actors.Stats.IDamagable>();
            if (damagables != null && damagables.Length > 0)
            {
                InvokeOnTargetUpdatedEvent(damagables, TargetAcquisitionType.OnExit);
            }
        }
        #endregion
    }
}
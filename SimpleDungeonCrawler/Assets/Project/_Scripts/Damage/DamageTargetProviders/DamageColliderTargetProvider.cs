// ######################################################################
// DamageColliderTargetProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Actors.Stats;

namespace Project.Damage
{
    public class DamageColliderTargetProvider : Targeting.ColliderTargetProvider<IDamagable>
    {
        #region MonoBehaviour Callback Method(s):
        protected virtual void Awake() => GetComponent<UnityEngine.Collider2D>().isTrigger = false;
        #endregion
    }
}
// ######################################################################
// EventTriggerTargetProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project.Interaction
{
    public class EventTriggerTargetProvider : Targeting.TriggerTargetProvider<Actors.Player.PlayerMotor>
    {
        #region MonoBehaviour Callback Method(s):
        protected virtual void Awake() => GetComponent<UnityEngine.Collider2D>().isTrigger = true;
        #endregion
    }
}

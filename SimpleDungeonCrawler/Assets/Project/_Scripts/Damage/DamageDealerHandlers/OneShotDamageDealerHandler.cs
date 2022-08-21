// ######################################################################
// OneShotDamageDealerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project.Damage
{
    public class OneShotDamageDealerHandler : BaseDamageDealerHandler
    {
        #region Internally Used Method(s):
        protected override void HandleDamage(Actors.Stats.IDamagable _damagableDataProvider)
        {
            _damagableDataProvider.Consume(DamageRange.GetRandomValueInRange(), Actors.Stats.StatConsumeType.Damage);
        }
        #endregion
    }
}
// ######################################################################
// OneShotDamageDealerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Actors.Stats;

namespace Project.Damage
{
    public class OneShotDamageDealerHandler : BaseDamageDealerHandler
    {
        #region Internally Used Method(s):
        protected override void DealDamage(IDamagable _damagable, CollisionAcquisitionType _acquisitionType)
        {
            float rndDamage = m_damageRange.GetRandomValueInRange();

            if (rndDamage > 0f)
            {
                _damagable.Consume(rndDamage, Actors.Stats.StatConsumeType.Damage);
            }
        }
        #endregion
    }
}
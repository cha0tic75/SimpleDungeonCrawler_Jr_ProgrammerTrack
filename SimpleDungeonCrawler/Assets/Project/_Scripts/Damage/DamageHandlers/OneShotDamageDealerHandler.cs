// ######################################################################
// OneShotDamageDealerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;
using Project.Actors.Stats;

namespace Project.Damage
{
    public class OneShotDamageDealerHandler : BaseDamageDealerHandler
    {
        #region Internally Used Method(s):
        protected override void DealDamage(List<IDamagable> _damagables, Targeting.TargetAcquisitionType _acquisitionType)
        {
            _damagables.ForEach(d => d.Consume(m_damageRange.GetRandomValueInRange(), Actors.Stats.StatConsumeType.Damage));
        }
        #endregion
    }
}
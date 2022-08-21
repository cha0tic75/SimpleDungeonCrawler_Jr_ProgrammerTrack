// ######################################################################
// BaseDamageDealerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Damage
{
    public abstract class BaseDamageDealerHandler : BaseHandler
    {
        #region Inspector Assigned Field(s):
        [field: SerializeField] public TargetAcquisitionType AcquisitionType { get; private set; }
        [field: SerializeField] public List<Actors.Stats.StatType_SO> StatTypes { get; private set; }
        [field: SerializeField] public MinMaxFloat DamageRange { get; private set; }
        #endregion

        #region Public API:
        public override void Handle(IHandlerDataProvider _Ihandle)
        {
            Actors.Stats.IDamagable damagableDataProvider = (_Ihandle as Actors.Stats.IDamagable);
            if (damagableDataProvider != null &&  StatTypes.Contains(damagableDataProvider.StatType))
            {
                HandleDamage(damagableDataProvider);
            }
        }
        #endregion

        #region Internally Used Method(s):
        protected abstract void HandleDamage(Actors.Stats.IDamagable _damagableDataProvider);
        #endregion
    }

    public class StayDamageDealerHandler : BaseDamageDealerHandler
    {
        #region Internally Used Method(s):
        protected override void HandleDamage(Actors.Stats.IDamagable _damagableDataProvider)
        {
            
        }
        #endregion
    }
}
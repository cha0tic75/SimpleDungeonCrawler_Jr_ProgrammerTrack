// ######################################################################
// IDamagable - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Actors.Stats
{
    public interface IDamagable
	{
		event Action<float, StatComponent> OnTakeDamageEvent;
		StatType_SO StatType { get; }
		GameObject GO { get; }

		void Consume(float _damageAmount, StatConsumeType _consumeType);
	}
}

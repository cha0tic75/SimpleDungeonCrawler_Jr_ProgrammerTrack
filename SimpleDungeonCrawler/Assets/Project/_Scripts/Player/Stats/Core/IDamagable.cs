// ######################################################################
// IDamagable - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Player.Stats
{
    public interface IDamagable
	{
		StatType_SO StatType { get; }
		GameObject GO { get; }

		void Consume(float _damageAmount, StatConsumeType _consumeType);
	}
}

// ######################################################################
// IMovementDataProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Actors
{
    public interface IMovementDataProvider
	{
		Vector2 Velocity { get; }
	}
}

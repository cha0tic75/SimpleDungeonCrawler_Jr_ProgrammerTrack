// ######################################################################
// BaseEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Effects
{
    public abstract class BaseEffect_SO : Base_SO
	{	
		#region Public API:
		public abstract void PerformEffect(GameObject _gameObject);
		#endregion
	}
}

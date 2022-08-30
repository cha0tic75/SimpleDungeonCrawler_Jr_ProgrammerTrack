// ######################################################################
// TriggerNotifier - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    public class TriggerNotifier : BaseColliderNotifier
	{
		#region MonoBehaviour Callback Method(s):
		private void Start() { } // This is just here to expose the enable/disable toggle in the inspector
		private void OnTriggerEnter2D(Collider2D _collider) 
		{
			if (!HasFlags(CollisionAcquisitionType.OnEnter)) { return; }
			HandleOnEnter(_collider);
		}

		private void OnTriggerExit2D(Collider2D _collider) 
		{
			if (!HasFlags(CollisionAcquisitionType.OnExit)) { return; }
			HandleOnExit(_collider);
		}
		#endregion
	}
}

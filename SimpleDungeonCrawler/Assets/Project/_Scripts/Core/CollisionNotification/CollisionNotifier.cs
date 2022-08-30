// ######################################################################
// CollisionNotifier - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    public class CollisionNotifier : BaseColliderNotifier
	{
		#region MonoBehaviour Callback Method(s):
		private void Start() { } // This is just here to expose the enable/disable toggle in the inspector
		private void OnCollisionEnter2D(Collision2D _collision) 
		{
			if (!HasFlags(CollisionAcquisitionType.OnEnter)) { return; }
			HandleOnEnter(_collision.collider);
		}

		private void OnCollisionExit2D(Collision2D _collision) 
		{
			if (!HasFlags(CollisionAcquisitionType.OnExit)) { return; }
			HandleOnExit(_collision.collider);
		}
		#endregion
	}
}

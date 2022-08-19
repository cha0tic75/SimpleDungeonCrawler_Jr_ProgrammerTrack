// ######################################################################
// CameraTools - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.CameraSystem
{
    public class CameraTools : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public SimpleCameraFollow CameraFollow { get; private set; }
		[field: SerializeField] public CameraShaker CameraShaker { get; private set; }
		[field: SerializeField] public CameraZoom CameraZoom { get; private set; }
		#endregion
	}
}
// ######################################################################
// CameraTools_New - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.CameraSystem
{
    public class CameraTools_New : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public Camera MainCamera { get; private set; }
		[field: SerializeField] public Transform FollowTransform { get; private set; }
		[field: SerializeField] public Transform ShakeTransform { get; private set; }
		[field: SerializeField] public SimpleCameraShaker CameraShaker { get; private set; }
		[field: SerializeField] public SimpleCameraFollow_New CameraFollow { get; private set; }
		[field: SerializeField] public SimpleCameraZoom CameraZoom { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
			CameraShaker = new SimpleCameraShaker(ShakeTransform, this);
			CameraFollow = new SimpleCameraFollow_New(FollowTransform);
			CameraZoom = new SimpleCameraZoom(MainCamera, this);
		}

		private void Update() => CameraFollow.Tick();
		#endregion
	}
}

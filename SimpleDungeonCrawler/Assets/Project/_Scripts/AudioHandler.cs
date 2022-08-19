// ######################################################################
// AudioHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.AudioSystem
{
	public class AudioHandler : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public AudioSource BgAudioSource { get; private set; }
		[field: SerializeField] public AudioSource AmbientAudioSource { get; private set; }
		[field: SerializeField] public AudioSource FXAudioSource { get; private set; }
		#endregion
	}
}
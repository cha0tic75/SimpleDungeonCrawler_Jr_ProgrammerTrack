// ######################################################################
// AudioSourceType_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.AudioSystem
{
    [CreateAssetMenu(menuName = "SO/Audio/Audio SourceType")]
	public class AudioSourceType_SO : Base_SO
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField, Range(0f, 1f)] public float DefaultVolume { get; private set; } = 1f;
		[field: SerializeField] public string MixerParam { get; private set; }
		#endregion
	}
}
// ######################################################################
// PlayOneShotAudioEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Effects
{
    [CreateAssetMenu(menuName = "SO/Effects/Play One-Shot Audio Effect", fileName = "New One-Shot Audio Effect")]
	public class PlayOneShotAudioEffect_SO : BaseEffect_SO
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public AudioClip AudioClip { get; private set; }
		[field: SerializeField] public AudioSystem.AudioSourceType_SO AudioSourceType { get; private set; }
		[field: SerializeField, Range(0f, 1f)] public float Volume { get; private set; }
		#endregion

		#region Public API:
		public override void PerformEffect(GameObject _gameObject)
		{
			if (AudioClip == null) { return; }
			GameManagement.GameManager.Instance.AudioHandler.PlayOneShotAudio(AudioSourceType, AudioClip, Volume);
		}
		#endregion
	}
}

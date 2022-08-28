// ######################################################################
// AudioHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.AudioSystem
{
    public class AudioHandler : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private BackgroundAudioSystem m_backgroundAudioSystem;
		[field: SerializeField] public List<AudioSourceData> m_audioSourceDatas = new List<AudioSourceData>();
		#endregion

		#region Internal State Field(s):
		private Dictionary<AudioSourceType_SO, AudioSourceData> m_audioSourceDataDictionary;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() =>  BuildAudioSourceDataDictionary();

        private void Start() => m_audioSourceDatas.ForEach(asd => asd.LoadVolumeLevel());
		private void OnApplicationQuit() => m_audioSourceDatas.ForEach(asd => asd.SaveVolumeLevel());
		#endregion

		#region Public API:
		public AudioSource GetAudioSource(AudioSourceType_SO _audioSourceType) => m_audioSourceDataDictionary[_audioSourceType].Source;
		public void PlayOneShotAudio(AudioSourceType_SO _audioSourceType, AudioClip _audioClip, float _volume)
			=> GetAudioSource(_audioSourceType).PlayOneShot(_audioClip, _volume);

		public void Play(AudioClip _audioClip) => m_backgroundAudioSystem.CrossFade(_audioClip);
		#endregion


		#region Internally Used Method(s):
       private void BuildAudioSourceDataDictionary()
        {
            m_audioSourceDataDictionary = new Dictionary<AudioSourceType_SO, AudioSourceData>();
            foreach (var audioSourceData in m_audioSourceDatas)
            {
				AudioSourceType_SO AudioSourceDataType = audioSourceData.AudioSourceType;
				if (m_audioSourceDataDictionary.ContainsKey(AudioSourceDataType))
				{
					Debug.LogWarning($"AudioSourceDatas contains a duplicate key {AudioSourceDataType.Name}");
					continue;
				}
				m_audioSourceDataDictionary.Add(AudioSourceDataType, audioSourceData);
            }
        }
		#endregion

		#region Support Class(es):
		[System.Serializable]
		public class AudioSourceData
		{
			#region Inspector Assigned Field(s):
			[field: SerializeField] public AudioSource Source { get; private set; }
			[field: SerializeField] public AudioSourceType_SO AudioSourceType { get; private set; }
			#endregion

			#region Public API:
			public void LoadVolumeLevel()
			{
				float volume = PlayerPrefs.GetFloat(AudioSourceType.ToString());
				Source.volume = (volume > 0f) ? volume : AudioSourceType.DefaultVolume;
			}
			public void SaveVolumeLevel()
			{
				PlayerPrefs.SetFloat(AudioSourceType.ToString(), Source.volume);
			}
			#endregion
		}

		[System.Serializable]
		public class BackgroundAudioSystem
		{
			#region Inspector Assigned Field(s):
			[SerializeField] private AudioSource m_audioSource1;
			[SerializeField] private AudioSource m_audioSource2;
			[SerializeField] private float m_duration = 0.35f;
			#endregion

			#region Internal State field(s):
			private AudioSource m_activeAudioSource;
			#endregion

			#region Public API:
			public void CrossFade(AudioClip _audioClip)
			{
				if (_audioClip == null) { return; }

				if (m_activeAudioSource == null)
				{
					m_activeAudioSource = m_audioSource1;
					m_activeAudioSource.clip = _audioClip;
					m_activeAudioSource.volume = 1;
					m_activeAudioSource.Play();
					return;
				}

				AudioSource ToSource = GetInactiveAudioSource();
				ToSource.clip = _audioClip;
				ToSource.Play();
				GameManagement.GameManager.Instance.StartCoroutine(CrossFadeCoroutine(m_activeAudioSource, ToSource, m_duration));
			}
			#endregion

			#region Internally Used Method(s):
			private AudioSource GetInactiveAudioSource() => 
				(m_activeAudioSource == m_audioSource1) ? m_audioSource2 : m_audioSource1;
			#endregion

			#region Coroutine(s):
			private IEnumerator CrossFadeCoroutine(AudioSource _fromSource, AudioSource _toSource, float _duration)
			{
				float elapsedTime = 0f;
				while (elapsedTime < _duration)
				{
					float t = elapsedTime / _duration;
					_fromSource.volume = Mathf.Lerp(1f, 0f, t);
					_toSource.volume = Mathf.Lerp(0f, 1f, t);
					elapsedTime += Time.deltaTime;
					yield return null;
				}
				_fromSource.volume = 0f;
				_toSource.volume = 1f;
				m_activeAudioSource = _toSource;
			}
			#endregion
		}
		#endregion
	}
}
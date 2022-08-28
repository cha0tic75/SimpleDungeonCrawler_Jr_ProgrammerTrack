// ######################################################################
// AudioHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.AudioSystem
{
    public class AudioHandler : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
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
		#endregion
	}
}
// ######################################################################
// VolumeSettingsSliderUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.UI
{
	[RequireComponent(typeof(SettingsSliderUI))]
    public class VolumeSettingsSliderUI : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public AudioSystem.AudioSourceType_SO AudioSourceType { get; private set; }
		#endregion

		#region Internal STate Field(s):
		private SettingsSliderUI m_settingsSliderUI;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => m_settingsSliderUI = GetComponent<SettingsSliderUI>();
		private void Start() => SetCurrentValues();
        #endregion

        #region Public API
        public void OnValueChanged(float _value)
		{
			GameManagement.GameManager.Instance.AudioHandler.GetAudioSource(AudioSourceType).volume = _value;
			FormatValue(_value);
		}
		#endregion

		#region Internally Used Method(s):
        private void SetCurrentValues()
        {
            float currentVolume = GameManagement.GameManager.Instance.AudioHandler.GetAudioSource(AudioSourceType).volume;
            m_settingsSliderUI.Slider.value = currentVolume;
            m_settingsSliderUI.CaptionTMP.text = m_settingsSliderUI.Caption;
            FormatValue(currentVolume);
        }
		private void FormatValue(float _value)
		{
			float displayValue = 10 * _value;
			m_settingsSliderUI.ValueTMP.text = displayValue.ToString("F1");
		}
		#endregion
	}

}

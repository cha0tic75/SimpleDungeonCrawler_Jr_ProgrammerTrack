// ######################################################################
// VolumeSettingsSliderUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.UI
{
	[RequireComponent(typeof(SettingsSliderUI))]
    public abstract class VolumeSettingsSliderUI : MonoBehaviour
	{
		#region Properties:
		protected abstract AudioSource AudioSource { get; }
		#endregion

		#region Internal STate Field(s):
		private SettingsSliderUI m_settingsSliderUI;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
			m_settingsSliderUI = GetComponent<SettingsSliderUI>();
			m_settingsSliderUI.Slider.value = AudioSource.volume;
			m_settingsSliderUI.CaptionTMP.text = m_settingsSliderUI.Caption;	
		}
		#endregion

		#region Public API
		public void OnValueChanged(float _value) => AudioSource.volume = _value;
		#endregion
	}

}

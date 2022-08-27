// ######################################################################
// FXVolumeSettingsSliderUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.UI
{
    public class FXVolumeSettingsSliderUI : VolumeSettingsSliderUI
	{
		#region Properties:
		protected override AudioSource AudioSource => GameManagement.GameManager.Instance.AudioHandler.FXAudioSource;
		#endregion
	}

}

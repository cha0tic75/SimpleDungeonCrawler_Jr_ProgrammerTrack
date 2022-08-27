// ######################################################################
// SettingsSliderUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.UI
{
    public class SettingsSliderUI : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public string Caption { get; private set; }
		[field: SerializeField] public TMPro.TextMeshProUGUI CaptionTMP { get; private set; }
		[field: SerializeField] public TMPro.TextMeshProUGUI ValueTMP { get; private set; }
		[field: SerializeField] public UnityEngine.UI.Slider Slider { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
#if UNITY_EDITOR
		private void OnValidate() 
		{
			if (CaptionTMP != null) { CaptionTMP.SetText(Caption); }
		}
#endif
		#endregion
	}
}

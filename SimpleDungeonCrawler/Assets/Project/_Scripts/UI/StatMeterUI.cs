// ######################################################################
// CreditsPanelUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.UI
{
    public class StatMeterUI : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public Actors.Stats.StatType_SO StatType { get; private set; } 
		[SerializeField] private UnityEngine.UI.Image m_fillImage;
		#endregion

		#region Public API(s):
        public void UpdateMeter(Actors.Stats.StatComponent _statComponent) => 
            	m_fillImage.fillAmount = _statComponent.Percent;
		#endregion
	}
}
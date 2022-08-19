// ######################################################################
// MainMenuUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.UI
{
	public class MainMenuUI : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private GameObject m_menuPanel;
		[SerializeField] private GameObject m_infoPanel;
		[SerializeField] private Effects.PlayOneShotAudioEffect_SO m_clickAudioEffect;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable() => SetMenuVisibilityState(true);
		#endregion

		#region Public API:
		public void OnButtonClicked() => m_clickAudioEffect.PerformEffect(null);
		public void OnPlayButtonClicked() => 
			GameManagement.GameManager.Instance.ChangeGameState(GameManagement.GameState.GamePlay);

		public void OnInfoButtonClicked() => SetMenuVisibilityState(false);
		public void OnBackButtonClicked() => SetMenuVisibilityState(true);
		public void OnExitButtonClicked()
		{
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
		}
		#endregion

		#region Internally Used Method(s):
		private void SetMenuVisibilityState(bool _state)
		{
			m_menuPanel.SetActive(_state);
			m_infoPanel.SetActive(!_state);
		}
		#endregion
	}
}
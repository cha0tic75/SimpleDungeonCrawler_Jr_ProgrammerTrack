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
		[SerializeField] private GameObject m_settingsPanel;
		[SerializeField] private Effects.PlayOneShotAudioEffect_SO m_clickAudioEffect;
		[SerializeField] private AudioClip m_mainMenuAudioClip;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable() => ShowPanel(MenuPanel.MainMenu);
		private void Start() => GameManagement.GameManager.Instance.AudioHandler.Play(m_mainMenuAudioClip);
		#endregion

		#region Public API - Button Callback(s):
		public void OnButtonClicked() => m_clickAudioEffect.PerformEffect(null);
		public void OnPlayButtonClicked() => 
			GameManagement.GameManager.Instance.ChangeGameState(GameManagement.GameState.GamePlay);

		public void OnInfoButtonClicked() => ShowPanel(MenuPanel.Info);
		public void OnSettingsButtonClicked() => ShowPanel(MenuPanel.Settings);
		public void OnBackButtonClicked() => ShowPanel(MenuPanel.MainMenu);
		public void OnExitButtonClicked()
		{
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
		}
		#endregion

		#region Public API - Settings Callback(s):
		#endregion

		#region Internally Used Method(s):
		private void ShowPanel(MenuPanel _panel)
		{
			m_infoPanel.SetActive(_panel == MenuPanel.Info);
			m_settingsPanel.SetActive(_panel == MenuPanel.Settings);
			m_menuPanel.SetActive(_panel == MenuPanel.MainMenu);
		}
		#endregion

		public enum MenuPanel
		{
			MainMenu, 
			Settings, 
			Info, 
		}
	}
}
// ######################################################################
// GameManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;
using Project.Utility;

namespace Project.GameManagement
{
    public class GameManager : PersistentSinglonMonoBehaviour<GameManager>
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private GameState m_defaultGameState = GameState.MainMenu;
		[field: SerializeField] public CameraSystem.CameraTools CameraTools { get; private set; }
		[field: SerializeField] public AudioSystem.AudioHandler AudioHandler { get; private set; }
		[field: SerializeField] public UI.FadePanelUI FadePanel { get; private set; }
		[SerializeField] private GameObject m_pausePanel;
		[SerializeField] private GameObject m_deathPanel;
		[SerializeField] private GameObject m_winPanel;
		#endregion

		#region Internal State Field(s):
		private Dictionary<GameState, BaseGameStateBehaviour> m_gameStateBehaviourDictionary;
		#endregion
		
		#region Properties:
		public GameState CurrentGameState { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected override void Awake()
		{
			base.Awake();
			CreateGameStateBehaviourDictionary();
		}
		private void Start() => ChangeGameState(m_defaultGameState);
		#endregion
		
		#region Public API:
		public void ChangeGameState(GameState _newGameState)
		{
			if (_newGameState == CurrentGameState) { return; }

			CurrentGameState = _newGameState;

			m_gameStateBehaviourDictionary[CurrentGameState].Perform();
		}
		#endregion

		#region Internally Used Method(s):
		private void CreateGameStateBehaviourDictionary()
		{
			m_gameStateBehaviourDictionary = new Dictionary<GameState, BaseGameStateBehaviour>()
			{
				{ GameState.MainMenu, new BasicLoadSceneGameStateBehaviour(SceneName.MainMenu, HideAllPopupPanels) }, 
				{ GameState.GamePlay, new BasicLoadSceneGameStateBehaviour(SceneName.GameLevel, HideAllPopupPanels) }, 
				{ GameState.Death, new CoroutineLoadSceneGameStateBehaviour(SceneName.MainMenu, m_deathPanel) }, 
				{ GameState.Win, new CoroutineLoadSceneGameStateBehaviour(SceneName.Credits, m_winPanel) },
			};

			void HideAllPopupPanels()
			{
				m_pausePanel.SetActive(false);
				m_deathPanel.SetActive(false);
				m_winPanel.SetActive(false);
			}
		}
		#endregion
	}
}
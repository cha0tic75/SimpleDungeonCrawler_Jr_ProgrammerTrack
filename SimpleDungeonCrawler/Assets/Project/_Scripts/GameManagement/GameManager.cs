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
		[field: SerializeField, ReadOnly] public GameState CurrentGameState { get; private set; } = GameState.Unset;
		// [field: SerializeField] public CameraSystem.CameraTools CameraTools { get; private set; }
		[field: SerializeField] public CameraSystem.CameraTools_New CameraTools { get; private set; }
		[field: SerializeField] public AudioSystem.AudioHandler AudioHandler { get; private set; }
		[field: SerializeField] public Effects.FadePanel FadePanel { get; private set; }
		[field: SerializeField] public DialogueSystem.DialogueManager DialogManager { get; private set; }
		[field: SerializeField] public ObjectPooling.PrefabObjectPooler PrefabObjectPooler { get; private set; }
		[SerializeField] private GameObject m_pausePanel;
		#endregion

		#region Internal State Field(s):
		private Dictionary<GameState, BaseGameStateBehaviour> m_gameStateBehaviourDictionary;
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
				{ GameState.MainMenu, new BasicLoadSceneGameStateBehaviour(SceneName.MainMenu, HidePausePanel) }, 
				{ GameState.GamePlay, new BasicLoadSceneGameStateBehaviour(SceneName.GameLevel, HidePausePanel) }, 
				{ GameState.ReloadCurrentLevel, new BasicLoadSceneGameStateBehaviour(SceneName.GameLevel, HidePausePanel, SwitchCurrentStateToGamePlay) }, 
				{ GameState.loadNextLevel, new BasicLoadSceneGameStateBehaviour(SceneName.GameLevel, ChangeToNextLevel, SwitchCurrentStateToGamePlay) },
			};

			void ChangeToNextLevel()
			{
				LevelManager.Instance.UpdateLevelToNext();
				HidePausePanel();
			}
			void SwitchCurrentStateToGamePlay() => CurrentGameState = GameState.GamePlay;
			void HidePausePanel() => m_pausePanel.SetActive(false);
		}
		#endregion
	}
}
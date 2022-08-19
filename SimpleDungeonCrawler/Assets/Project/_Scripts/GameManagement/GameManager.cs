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
		[field: SerializeField] public CameraSystem.CameraTools CameraTools { get; private set; }
		[field: SerializeField] public AudioSystem.AudioHandler AudioHandler { get; private set; }
		#endregion

		#region Internal State Field(s):
		private Dictionary<GameState, BaseGameStateBehaviour> m_gameStateBehaviourDictionary;
		#endregion
		
		#region Properties:
		public GameState CurrentGameState { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() => CreateGameStateBehaviourDictionary();
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

			};

			ChangeGameState(GameState.MainMenu);
		}
		#endregion
	}
}
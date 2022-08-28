// ######################################################################
// LevelManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

using Project.Utility;

namespace Project.GameManagement
{
    public class LevelManager : SingletonMonoBehaviour<LevelManager>
	{
		#region Constant(s):
		public const int GAME_LEVEL_SCENE_INDEX_OFFSET = 3;
		#endregion

		#region Inspector Assigned Field(s):
		[field: SerializeField] public GameLevelName CurrentGameLevel { get; private set; }
		[Header("Spawn Point(s):")]
		[SerializeField] private Vector3 m_defaultSpawnPoint = Vector3.zero;
		[field: SerializeField, ReadOnly] public Vector3 CurrentSpawnPosition { get; private set; }
		#endregion

		#region Public API:
		public void SetLevelSectionCheckpoint(Vector3 _spawnPositiin) => CurrentSpawnPosition = _spawnPositiin;
		public void LoadCurrentLevel()
		{ 
			UnityEngine.SceneManagement.SceneManager.LoadScene((int)CurrentGameLevel + GAME_LEVEL_SCENE_INDEX_OFFSET);
			SetLevelSectionCheckpoint(m_defaultSpawnPoint);
		}
		public void LoadNextLevel()
		{
			CurrentGameLevel = CurrentGameLevel + 1;
			LoadCurrentLevel();
		}
		#endregion
	}
}
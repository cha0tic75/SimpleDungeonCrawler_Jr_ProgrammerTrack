// ######################################################################
// GameStateChangeEventTriggerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Interaction
{
    public class GameStateChangeEventTriggerHandler : BaseEventTriggerHandler
    {
        #region 
        [SerializeField] private GameManagement.GameState m_newGameState;
        #endregion
    
        #region Public API:
        public override void Handle()
        {
            GameManagement.GameManager.Instance.ChangeGameState(m_newGameState);
        }
        #endregion
    }
}

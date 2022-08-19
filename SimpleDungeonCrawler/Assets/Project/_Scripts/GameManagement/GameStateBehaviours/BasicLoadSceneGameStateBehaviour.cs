// ######################################################################
// BasicLoadSceneGameStateBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;

namespace Project.GameManagement
{
    public class BasicLoadSceneGameStateBehaviour : SceneTransitionGameStateBehaviour
    {
        #region Internal State Field(s):
        private readonly Action m_beforeLoadSceneAction;
		private readonly Action m_afterLoadSceneAction;
        private readonly SceneName m_sceneName;
        #endregion

        #region Constructor(s):
        public BasicLoadSceneGameStateBehaviour(SceneName _sceneName, Action _beforeLoadSceneAction = null, Action _afterLoadSceneAction = null)
        {
            m_sceneName = _sceneName;
            m_beforeLoadSceneAction = _beforeLoadSceneAction;
			m_afterLoadSceneAction = _afterLoadSceneAction;
        }
        #endregion

        #region Public API:
        public override void Perform()
        {
			GameManager.Instance.FadePanel.AlphaOverride(1f);
            m_beforeLoadSceneAction?.Invoke();
			
			LoadScene(m_sceneName);
			m_afterLoadSceneAction?.Invoke();
			GameManager.Instance.FadePanel.FadeIn();
        }
        #endregion
    }
}
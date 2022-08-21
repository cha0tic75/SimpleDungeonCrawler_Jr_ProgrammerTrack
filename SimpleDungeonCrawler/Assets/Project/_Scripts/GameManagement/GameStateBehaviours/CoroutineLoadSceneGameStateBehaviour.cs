// ######################################################################
// CoroutineLoadSceneGameStateBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;

namespace Project.GameManagement
{
    public class CoroutineLoadSceneGameStateBehaviour : SceneTransitionGameStateBehaviour
    {
		#region Constant(s):
		private const float DELAY_BEFORE_FADE_TO_MAIN_MENU = 2f;
		#endregion

        #region Internal State Field(s):
        private readonly SceneName m_sceneName;
        private readonly UnityEngine.GameObject m_displayPanel;
        #endregion

        #region Constructor(s):
        public CoroutineLoadSceneGameStateBehaviour(SceneName _sceneName, UnityEngine.GameObject _displayPane)
        {
            m_sceneName = _sceneName;
            m_displayPanel = _displayPane;
        }
        #endregion

        #region Public API:
        public override void Perform() => GameManager.Instance.StartCoroutine(PerformCoroutine());
        #endregion

        #region Coroutine(s):
		private IEnumerator PerformCoroutine()
		{
			m_displayPanel.SetActive(true);
			yield return HelperMethods.CustomWFS(DELAY_BEFORE_FADE_TO_MAIN_MENU);
			
			yield return GameManager.Instance.FadePanel.FadeOutCoroutine(2f);
			
			yield return LoadSceneAfterTime(m_sceneName, 1f);
			m_displayPanel.SetActive(false);
			yield return GameManager.Instance.FadePanel.FadeInCoroutine(2f);
		}
        #endregion
    }
}
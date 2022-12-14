// ######################################################################
// SceneTransitionGameStateBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine.SceneManagement;

namespace Project.GameManagement
{
    public abstract class SceneTransitionGameStateBehaviour : BaseGameStateBehaviour
    {
        #region Internally Used Method(s):
        protected void LoadScene(SceneName _sceneName) => SceneManager.LoadScene((int)_sceneName);
        #endregion

        #region Coroutine(s):
		protected IEnumerator LoadSceneAfterTime(SceneName _sceneName, float _waitTime)
		{
			yield return HelperMethods.CustomWFS(_waitTime);
			LoadScene(_sceneName);
		}
        #endregion
    }
}
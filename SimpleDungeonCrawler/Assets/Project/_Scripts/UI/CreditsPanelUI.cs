// ######################################################################
// CreditsPanelUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project.UI
{
    public class CreditsPanelUI : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_loadWaitTime = 2f;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() => StartCoroutine(LoadMainMenuAfterTimeCoroutine());
		#endregion

		#region Coroutine(s):
		private IEnumerator LoadMainMenuAfterTimeCoroutine()
		{
			yield return HelperMethods.CustomWFS(m_loadWaitTime);
			yield return GameManagement.GameManager.Instance.FadePanel.FadeOutCoroutine(2f);
			GameManagement.GameManager.Instance.ChangeGameState(GameManagement.GameState.MainMenu);
		}
		#endregion
	}
}
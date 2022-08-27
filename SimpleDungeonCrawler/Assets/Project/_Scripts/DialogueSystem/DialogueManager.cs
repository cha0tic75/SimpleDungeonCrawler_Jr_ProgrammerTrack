// ######################################################################
// DialogueManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Integrate a means for the player to skip the "typewriter" effect, by pressing interact, to see entire dialogue.

namespace Project.DialogueSystem
{
    public class DialogueManager : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private CanvasGroup m_dialogueCanvasGroup;
		[SerializeField] private TMPro.TextMeshProUGUI m_textTMP;
		[SerializeField] private float m_defaultDelayBetweenDialogues = 0.6f;
		[SerializeField] private float m_defaultDelayBetweenCharacters = 0.001f;
		#endregion

		#region Internal State Field(s):
		private Queue<Dialogue> m_dialogueQueue = new Queue<Dialogue>();
		private Coroutine m_displayDialogueQueueCoroutine = null;
		private bool m_hasInteractionInput;
		#endregion

		#region MonoBehaviour Callback Method(s):
        private void OnDisable() => HideDialogueBox();
		#endregion
		
		#region Public API:
		public void ShowDialogue(Dialogue _dialogue)
		{
			m_dialogueQueue.Enqueue(_dialogue);
			if (m_displayDialogueQueueCoroutine != null) { return; }

			m_displayDialogueQueueCoroutine = StartCoroutine(DisplayDialogueQueueCoroutine());
		}
		public void ShowDialogue(string _dialogueText) => ShowDialogue(new Dialogue(_dialogueText));
		#endregion

		#region Internally Used Method(s):
		private void HideDialogueBox()
		{
			HelperMethods.StopCoroutineIfRunning(ref m_displayDialogueQueueCoroutine, this);
			m_dialogueQueue.Clear();
			m_dialogueCanvasGroup.alpha = 0f;
		}
		#endregion

		#region Callback(s):
		#endregion

		#region Coroutine(s):
		private IEnumerator DisplayDialogueQueueCoroutine()
		{
			m_textTMP.text = "";
			yield return HelperMethods.LerpCanvasGroupAlpha(0f, 1f, 0.2f, m_dialogueCanvasGroup);
			while (m_dialogueQueue.Count > 0)
			{
				Dialogue nextDialogue = m_dialogueQueue.Dequeue();
				yield return DisplayNextDialogueCoroutine(nextDialogue);
				yield return HelperMethods.CustomWFS(m_defaultDelayBetweenDialogues);
			}
			
			yield return HelperMethods.LerpCanvasGroupAlpha(1f, 0f, 0.2f, m_dialogueCanvasGroup);
			m_displayDialogueQueueCoroutine = null;
		}

		private IEnumerator DisplayNextDialogueCoroutine(Dialogue _dialogue)
		{
			int index = 0;
			string dialogText = _dialogue.DialogText;
			while(index < dialogText.Length)
			{
				m_textTMP.text = dialogText.Substring(0, index);
				index++;
				yield return HelperMethods.CustomWFS(m_defaultDelayBetweenCharacters);
			}
			m_textTMP.text = dialogText;
		}
		#endregion
	}
}

// ######################################################################
// LoadInDialogueDisplayer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.DialogueSystem
{
	public class LoadInDialogueDisplayer : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_waitTime = 1f;
		[SerializeField] private List<string> m_dialogues;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() => Invoke("DisplayDialogue", m_waitTime);
		#endregion

		#region Internally Used Method(s):
		private void DisplayDialogue()
		{
			m_dialogues.ForEach(d => GameManagement.GameManager.Instance.DialogManager.ShowDialogue(d));
			Destroy(this);
		} 
		#endregion
	}
}

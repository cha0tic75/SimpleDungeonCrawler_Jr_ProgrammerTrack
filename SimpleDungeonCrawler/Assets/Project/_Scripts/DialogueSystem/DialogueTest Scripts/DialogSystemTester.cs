// ######################################################################
// DialogSystemTester - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.DialogueSystem
{
    public class DialogSystemTester : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private List<string> m_dialogStrings = new List<string>();
		#endregion

		#region Internally Used Method(s):
		public void DoTest()
		{
			m_dialogStrings.ForEach(ds => GameManagement.GameManager.Instance.DialogManager.ShowDialogue(ds));
		}
		#endregion
	}
}

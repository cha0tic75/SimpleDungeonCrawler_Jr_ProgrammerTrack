// ######################################################################
// Dialogue - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.DialogueSystem
{
    [System.Serializable]
	public class Dialogue
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public string DialogText { get; private set; }
		#endregion

		#region Constructor(s):
		public Dialogue() { }
		public Dialogue(string _dialogText) => DialogText = _dialogText;
		#endregion
	}
}

// ######################################################################
// LevelLoader - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.GameManagement
{
	public class LevelLoader : MonoBehaviour
	{
		#region MonoBehaviour Callback Method(s):
		private void Start() => LevelManager.Instance.LoadCurrentLevel();
		#endregion
	}
}
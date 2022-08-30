// ######################################################################
// DamageText - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Damage
{
	public class DamageText : ObjectPooling.PoolableEntity
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private List<string> m_damageTextStrings = new List<string>();
		[SerializeField] private TMPro.TextMeshPro m_textMesh;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable() => m_textMesh.text = m_damageTextStrings[UnityEngine.Random.Range(0, m_damageTextStrings.Count)];
		#endregion
	}
}
// ######################################################################
// DamageText - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Damage
{
	public class DamageText : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_lifetime = 0.5f;
		[SerializeField] private List<string> m_damageTextStrings = new List<string>();
		[SerializeField] private TMPro.TextMeshPro m_textMesh;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private IEnumerator Start()
		{
			m_textMesh.text = m_damageTextStrings[UnityEngine.Random.Range(0, m_damageTextStrings.Count)];
			yield return HelperMethods.CustomWFS(m_lifetime);
			Destroy(gameObject); // TODO: This should be object Pool
		}
		#endregion
	}
}
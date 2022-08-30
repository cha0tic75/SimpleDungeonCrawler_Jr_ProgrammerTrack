// ######################################################################
// ArenaTimerEventTriggerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Interaction
{
    public class ArenaTimerEventTriggerHandler : BaseEventTriggerHandler
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_timeDelay = 5f;
		[SerializeField] private GameObject m_keyPrefab;
		[SerializeField] private List<Transform> m_dropPoints;
		#endregion

		#region Public API:
		public override void Perform() => StartCoroutine(TimerCoroutine());
		#endregion

		#region Coroutine(s):
		private IEnumerator TimerCoroutine()
		{
			yield return HelperMethods.CustomWFS(m_timeDelay);

			Transform rndTransform = m_dropPoints[UnityEngine.Random.Range(0, m_dropPoints.Count)];

			Instantiate(m_keyPrefab, rndTransform.position, Quaternion.identity);

			Destroy(gameObject);
		}
		#endregion
	}
}

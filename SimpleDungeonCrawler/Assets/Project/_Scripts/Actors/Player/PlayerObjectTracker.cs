// ######################################################################
// PlayerObjectTracker - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Actors.Player
{
	public class PlayerObjectTracker : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField, ReadOnly] private List<Interaction.Interactable> m_itemsSeen = new List<Interaction.Interactable>();
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable() => m_itemsSeen.Clear();
		private void OnTriggerEnter2D(Collider2D _collider)
		{
			if (_collider.TryGetComponent<Interaction.Interactable>(out var interactable))
			{
				if (!m_itemsSeen.Contains(interactable))
				{
					m_itemsSeen.Add(interactable);
				}
			}
		}
		#endregion
	}
}

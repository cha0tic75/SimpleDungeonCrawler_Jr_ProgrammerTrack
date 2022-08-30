// ######################################################################
// PlayerInteractor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Actors.Player
{
    [RequireComponent(typeof(PlayerMotor))]
	public class PlayerInteractor : TransformMonoBehaviour, Interaction.IInteractorDataProvider
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_interactRadius;
        [SerializeField] private LayerMask m_interactLayerMask;
#if UNITY_EDITOR
		[SerializeField] private bool m_showGizmos;
#endif
		#endregion

		#region Internal State Field(s):
		private PlayerInventory m_playerInventory = null;
        #endregion

        #region MonoBehaviour Callback Method(s):
        private void OnEnable() =>
			Input.PlayerInputManager.Instance.OnInteractionEvent += Controller_OnInteractionCallback;
		private void OnDisable()
		{
			if (Input.PlayerInputManager.Instance == null) { return; }
			Input.PlayerInputManager.Instance.OnInteractionEvent -= Controller_OnInteractionCallback;
		}
        
#if UNITY_EDITOR
		private void OnDrawGizmosSelected() 
		{
			if (!m_showGizmos) { return; }
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, m_interactRadius);	
		}
#endif
		#endregion

        #region Internally Used Method(s):
        private void Controller_OnInteractionCallback()
        {
 			List<Collider2D> interactColliders = (Physics2D.OverlapCircleAll(Transform.position, m_interactRadius, m_interactLayerMask)).ToList();

			if (interactColliders != null && interactColliders.Count > 0)
			{
				interactColliders.Sort(SortColliderByDistance);

				if (interactColliders[0].TryGetComponent<Interaction.Interactable>(out var interactable))
				{
					if (interactable.enabled == true)
					{
						interactable.Interact(this);
						return;
					}
				}	
			}

			// No interactable found. lets assume player wants to drop current Item:
			if (m_playerInventory == null) { m_playerInventory = GetComponent<PlayerInventory>(); }

			m_playerInventory.AttemptToDropCurrent();

			int SortColliderByDistance(Collider2D _a, Collider2D _b)
			{
				float distA = (Transform.position -_a.transform.position).sqrMagnitude;
				float distB = (Transform.position - _b.transform.position).sqrMagnitude;

				if (distA == distB) { return 0; }
				return (distA < distB) ? -1 : 1;
			}
        }
		#endregion
	}
}

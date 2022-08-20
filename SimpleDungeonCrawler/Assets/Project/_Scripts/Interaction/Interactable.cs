// ######################################################################
// Interactable - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Interaction
{
    public class Interactable : TransformMonoBehaviour, IInteractable
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private List<BaseInteractionHandler> m_interactionHandlers;
		[SerializeField] private List<Effects.BaseEffect_SO> m_interactionEffects;
		#endregion

		#region Inspector Assigned Field(s):
		protected override void Awake()
		{
			base.Awake();
			if (m_interactionHandlers == null || m_interactionHandlers.Count == 0)
			{
				GetComponents<BaseInteractionHandler>(results: m_interactionHandlers);
			}
		}
		private void Start() { } // This is just here to expose enable/disable toggle in the inspector
		#endregion

		#region Public API:
		public void Interact(IInteractorDataProvider _interactor)
		{
			m_interactionEffects.ForEach(ie => ie.PerformEffect(_interactor.Transform.gameObject));

			for (int i = 0; i < m_interactionHandlers.Count; i++)
			{
				BaseInteractionHandler interactionHandler = m_interactionHandlers[i];
				if (interactionHandler != null && interactionHandler.enabled == true)
				{
					interactionHandler.Handle(_interactor);
				}
			}
		}
        #endregion
    }
}
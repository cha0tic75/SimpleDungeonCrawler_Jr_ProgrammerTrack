// ######################################################################
// DoorInteractionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Interaction
{
    [RequireComponent(typeof(Animator))]
    public class DoorInteractionHandler : BaseInteractionHandler
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public Items.Item_SO RequireditemSO { get; private set; }
		[SerializeField] private SpriteRenderer m_spriteRenderer;
		#endregion
		
		#region Internal State Field(s):		
		private Animator m_animator;
		private static int s_isOpenedBoolAnimParam = Animator.StringToHash("IsOpened");
		#endregion

		#region MonoBehaviour Callback Method(s):
#if UNITY_EDITOR
		private void OnValidate() => SetSpriteRendererColor();
#endif
		private void Start()
		{
			if (RequireditemSO == null) 
			{
				Debug.LogError($"There is no Item associated with {transform.name}"); 
				return; 
			}
			m_animator = GetComponent<Animator>();

			SetSpriteRendererColor();
		} 
		#endregion

		#region Public API:
		public override void HandleInteraction(IInteractorDataProvider _interactor)
		{
			if (_interactor.Transform.TryGetComponent<Actors.Player.PlayerInventory>(out var inventory))
			{
                if (!inventory.HasItem) { return; }

				if (inventory.CurrentItem.ItemSO == RequireditemSO)
				{
					Destroy(inventory.CurrentItem.gameObject);
					SetExitState(true);
				}
			}
		}
        public void SetExitState(bool _state)
		{
			m_animator.SetBool(s_isOpenedBoolAnimParam, _state);
		}
		#endregion

        #region Internally Used Method(s):

		private void SetSpriteRendererColor()
		{
			if (RequireditemSO == null || m_spriteRenderer == null) { return; }
			m_spriteRenderer.color = RequireditemSO.ItemVisuals.Color;
		}
		#endregion
	}
}
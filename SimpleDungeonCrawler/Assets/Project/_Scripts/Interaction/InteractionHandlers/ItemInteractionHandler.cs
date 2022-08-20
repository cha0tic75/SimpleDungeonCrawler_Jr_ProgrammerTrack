// ######################################################################
// ItemInteractionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################
using UnityEngine;

namespace Project.Interaction
{
    public class ItemInteractionHandler : BaseInteractionHandler
    {
        #region Inspector Assigned Field(s):
        [field: SerializeField] public Items.Item_SO ItemSO { get; private set; }
        [SerializeField] private SpriteRenderer m_spriteRenderer;
        #endregion

        #region MonoBehaviour Callback Method(s):
#if UNITY_EDITOR
        private void OnValidate() => SetSpriteRendererColor();
#endif
        private void Start() => SetSpriteRendererColor();
        #endregion

        #region Public API:
        protected override void HandleInteraction(IInteractorDataProvider _interactor)
        {
            if (_interactor.Transform.TryGetComponent<Actors.Player.PlayerInventory>(out var inventory))
            {
                inventory.AddItem(this);
            }
        }
        #endregion

        #region Internally Used Method(s):
        private void SetSpriteRendererColor()
        {
            if (ItemSO == null) { return; }
            if (m_spriteRenderer == null) { m_spriteRenderer = GetComponentInChildren<SpriteRenderer>(); }

            m_spriteRenderer.color = ItemSO.ItemVisuals.Color;	
        }
        #endregion
    }
}
// ######################################################################
// ItemInteractionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Project.Interaction
{
    public class ItemInteractionHandler : BaseInteractionHandler
    {
        #region Inspector Assigned Field(s):
        [field: SerializeField] public Items.Item_SO ItemSO { get; private set; }
        [SerializeField] private SpriteRenderer m_spriteRenderer;
        [SerializeField] private Light2D m_light;
        #endregion

        #region MonoBehaviour Callback Method(s):
#if UNITY_EDITOR
        private void OnValidate() => SetSpriteRendererColor();
#endif
        private void Start() => SetSpriteRendererColor();
        #endregion

        #region Public API:
        public override void HandleInteraction(IInteractorDataProvider _interactor)
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

            Color ItemColor = ItemSO.ItemVisuals.Color;

            m_spriteRenderer.color = ItemColor;
            Color lightColor = new Color(ItemColor.r, ItemColor.g, ItemColor.b, 0.4f);
            m_light.color = lightColor;
        }
        #endregion
    }
}
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
    }
}
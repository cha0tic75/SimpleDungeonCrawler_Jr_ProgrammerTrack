// ######################################################################
// DialogueEventTriggerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Interaction
{
    public class HasItemConditionalDialogueEventTriggerHandler : ConditionalDialogueEventTriggerHandler
    {
        #region Inspector Assigned Field(s):
        [SerializeField] private Items.Item_SO m_requiredItem;
        #endregion

        #region Internal State Field(s):
        private static Actors.Player.PlayerInventory s_playerInventory = null;
        #endregion

        #region Internally Used Method(s):
        protected override bool Evaluate()
        {
            if (s_playerInventory == null) { s_playerInventory = FindObjectOfType<Actors.Player.PlayerInventory>(); }

            return  (s_playerInventory.CurrentItem != null) ? s_playerInventory.CurrentItem.ItemSO == m_requiredItem : false;
        }
        #endregion
    }
}

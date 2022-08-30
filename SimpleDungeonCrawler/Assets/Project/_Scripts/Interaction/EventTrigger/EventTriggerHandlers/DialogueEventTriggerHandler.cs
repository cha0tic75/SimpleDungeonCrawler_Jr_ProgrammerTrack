// ######################################################################
// DialogueEventTriggerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Interaction
{
    public class DialogueEventTriggerHandler : BaseEventTriggerHandler
    {
        #region Inspector Assigned Field(s):
        [SerializeField] private List<string> m_dialogTexts = new List<string>();
        [SerializeField] private bool m_destroyOnFirstUse = false;
        #endregion

        #region Public API:
        public override void Handle()
        {
            m_dialogTexts.ForEach(dt => GameManagement.GameManager.Instance.DialogManager.ShowDialogue(dt));
            if (m_destroyOnFirstUse)
            {
                Destroy(gameObject);
            }
        }
        #endregion
    }
}

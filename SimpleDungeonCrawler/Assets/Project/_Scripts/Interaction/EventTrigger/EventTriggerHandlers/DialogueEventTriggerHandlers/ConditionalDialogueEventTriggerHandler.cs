// ######################################################################
// ConditionalDialogueEventTriggerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Interaction
{
    public abstract class ConditionalDialogueEventTriggerHandler : DialogueEventTriggerHandler
    {
        #region Inspector Assigned Field(s):
        [SerializeField] private List<string> m_falseConditionDialogues = new List<string>();
        #endregion

        #region Public API:
        public override void Perform()
        {
            if (!Evaluate())
            {
                ShowDialogues(m_falseConditionDialogues);
                return;
            }
    
            base.Perform();
        }
        #endregion

        #region Internally Used Method(s):
        protected abstract bool Evaluate();
        #endregion
    }
}

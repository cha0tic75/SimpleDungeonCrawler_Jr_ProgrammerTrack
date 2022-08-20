// ######################################################################
// BaseInteractionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project.Interaction
{
    public abstract class BaseInteractionHandler : BaseHandler
    {
        #region Public API:
        public override void Handle(IHandlerDataProvider _Ihandle)
        {
            IInteractorDataProvider interactDataProvider = (_Ihandle as IInteractorDataProvider);
            HandleInteraction(interactDataProvider);
        }
		#endregion

		#region Internally Used Method(s):
		protected abstract void HandleInteraction(IInteractorDataProvider _interactDataProvider);
		#endregion
    }
}
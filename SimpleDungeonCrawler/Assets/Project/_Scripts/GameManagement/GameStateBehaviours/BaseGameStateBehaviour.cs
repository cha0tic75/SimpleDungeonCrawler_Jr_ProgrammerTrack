// ######################################################################
// BaseGameStateBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project.GameManagement
{
    public abstract class BaseGameStateBehaviour
	{
		#region Constructor(s):
		public BaseGameStateBehaviour() { }
		#endregion

        #region Public API:
        public abstract void Perform();
        #endregion
	}
}
// ######################################################################
// BaseHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    public abstract class BaseHandler : MonoBehaviour
	{		
		#region Public API:
		public abstract void Handle(IHandlerDataProvider _Ihandle);
		#endregion
	}
}

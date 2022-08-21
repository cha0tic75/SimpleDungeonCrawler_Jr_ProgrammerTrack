// ######################################################################
// TeleportInteractionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Interaction
{
    public class TeleportInteractionHandler : BaseInteractionHandler, ITransformProvider
	{
        #region Inspector Assigned Field(s):
        [SerializeField] private Vector3 m_teleportOffset;
#if UNITY_EDITOR
        [SerializeField] private bool m_showGizmos;
#endif
        #endregion

        #region Properties:
        public Transform Transform { get; private set; }
        private Vector3 TeleportLocation => Transform.position + m_teleportOffset;
        #endregion

        #region MonoBehaviour Callback Method(s):
#if UNITY_EDITOR    
        private void OnDrawGizmosSelected() 
        {
            if (!m_showGizmos) { return; }
            if (Transform == null) { Transform = transform; }
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(TeleportLocation, 0.2f);
        }
#endif

        private void Awake() => Transform = transform;
        #endregion

		#region Public API:
		public  override void HandleInteraction(IInteractorDataProvider _interactDataProvider)
		{
			if (_interactDataProvider.Transform != null)
            {
                _interactDataProvider.Transform.position = TeleportLocation;
            }
		}
		#endregion
	}
}
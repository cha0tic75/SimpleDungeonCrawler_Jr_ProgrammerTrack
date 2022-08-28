// ######################################################################
// LevelSection - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Environment
{
	[RequireComponent(typeof(Collider2D))]
	public class LevelSection : TransformMonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private bool m_showGizmos = true;
		[SerializeField] private Vector3 m_spawnPointOffset;
		#endregion

        #region Properties:
        private Vector3 SpawnPoint => Transform.position + m_spawnPointOffset;
        #endregion

		#region MonoBehaviour Callback Method(s):
#if UNITY_EDITOR    
        private void OnDrawGizmosSelected() 
        {
            if (!m_showGizmos) { return; }
            if (Transform == null) { Transform = transform; }
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(SpawnPoint, 0.2f);
        }
#endif
		private void OnTriggerEnter2D(Collider2D _collider)
		{
			GameManagement.LevelManager.Instance.SetLevelSectionCheckpoint(SpawnPoint);
		}
		#endregion
	}
}
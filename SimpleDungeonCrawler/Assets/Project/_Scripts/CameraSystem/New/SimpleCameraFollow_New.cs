// ######################################################################
// SimpleCameraFollow_New - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.CameraSystem
{
    [System.Serializable]
    public class SimpleCameraFollow_New
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Transform m_targetTransform;
		[SerializeField] private float m_smoothness = 10f;
		#endregion

		#region Internal State Field(s):
		private readonly Transform m_transform;
		#endregion

		#region Properties:
		private Vector3 DesiredPosition => (m_targetTransform != null) ?
				new Vector3(m_targetTransform.position.x, m_targetTransform.position.y, m_transform.position.z) :
				m_transform.position;
		#endregion

		#region Constructor(s):
		public SimpleCameraFollow_New() { }
		public SimpleCameraFollow_New(Transform _transform)
		{
			m_transform = _transform;
		}
		#endregion

		#region Public API:
		public void Tick()
		{
			if (m_targetTransform == null) { return; }

			m_transform.position = Vector3.Lerp(m_transform.position, DesiredPosition, m_smoothness * Time.deltaTime);
		}

		public void SetTargetTransform(Transform _targetTransform, bool _snapToTarget = false)
		{
			m_targetTransform = _targetTransform;

			if (_snapToTarget){ m_transform.position = DesiredPosition; }
		}
		#endregion
	}
}

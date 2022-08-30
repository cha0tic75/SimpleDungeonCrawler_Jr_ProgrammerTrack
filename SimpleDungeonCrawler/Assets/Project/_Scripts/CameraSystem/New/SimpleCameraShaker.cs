// ######################################################################
// SimpleCameraShaker - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project.CameraSystem
{
    [System.Serializable]
    public class SimpleCameraShaker
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_defaultDuration = 0.1f;
		[SerializeField] private float m_defaultMagnitude = 0.1f;
        [SerializeField] private float m_axisRange = 0.25f;
		#endregion

		#region Properties:
		private readonly Transform m_transform;
		private readonly MonoBehaviour m_coroutineRunner;
		#endregion

		#region Constructor(s):
		public SimpleCameraShaker() { }
		public SimpleCameraShaker(Transform _transform, MonoBehaviour _coroutineRunner)
		{
			m_transform = _transform;
			m_coroutineRunner = _coroutineRunner;
		}
		public SimpleCameraShaker(Transform _transform, MonoBehaviour _coroutineRunner, float _defaultDuration, float _defaultMagnitude, float _axisRange) : this(_transform, _coroutineRunner)
		{
			m_defaultDuration = _defaultDuration;
			m_defaultMagnitude = _defaultMagnitude;
			m_axisRange = _axisRange;
		}
		#endregion

		#region Public API:
		public void Shake(float _duration = 0f, float _magnitude = 0f)
		{
			float duration = (_duration > 0f) ? _duration : m_defaultDuration;
			float magnitude = (_magnitude > 0f) ? _magnitude : m_defaultMagnitude;

			m_coroutineRunner.StartCoroutine(ShakeCoroutine(duration, magnitude));
		}
        #endregion

        #region Coroutine(s):
        private IEnumerator ShakeCoroutine(float _duration, float _magnitude)
		{
			float elapsedTime = 0f;

			while (elapsedTime < _duration)
			{
				float xOffset = Random.Range(-m_axisRange, m_axisRange); // * _magnitude;
				float yOffset = Random.Range(-m_axisRange, m_axisRange); // * _magnitude;
				m_transform.localPosition = new Vector3(xOffset, yOffset, m_transform.position.z) * _magnitude;

				elapsedTime += Time.deltaTime;
				yield return null;			
			}

			m_transform.localPosition = Vector3.zero;
		}
		#endregion
	}
}

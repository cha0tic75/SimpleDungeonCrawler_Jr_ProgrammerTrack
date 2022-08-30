// ######################################################################
// SimpleCameraZoom - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project.CameraSystem
{
    [System.Serializable]
    public class SimpleCameraZoom
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_defaultDuration = 0.1f;
        [SerializeField] private float m_defaultZoomValue = 1.92f;
		[SerializeField] private float m_defaultDelayBetween = 0.15f;
		#endregion

        #region Internal State Field(s):
        private readonly Camera m_mainCamera;
		private readonly MonoBehaviour m_coroutineRunner;
        private float m_defaultOrthoValue;
        #endregion

		#region Constructor(s):
		public SimpleCameraZoom() { }
		public SimpleCameraZoom(Camera _camera, MonoBehaviour _coroutineRunner)
		{
			m_mainCamera = _camera;
			m_coroutineRunner = _coroutineRunner;
			m_defaultOrthoValue = m_mainCamera.orthographicSize;
		}
		#endregion

		#region Public API:
		public void ZoomInOut(float _zoomValue = 0, float _duration = 0f, float _delayBetween = 0f)
		{
            float zoomValue = (_zoomValue > 0f) ? _zoomValue : m_defaultZoomValue;
			float duration = (_duration > 0f) ? _duration : m_defaultDuration;
			float delayBetween = (_delayBetween > 0f) ? _delayBetween : m_defaultDelayBetween;

			m_coroutineRunner.StartCoroutine(ZoomInOutCoroutine(zoomValue, duration, delayBetween));
		}
        #endregion

        #region Coroutine(s):
        private IEnumerator ZoomInOutCoroutine(float _endValue, float _duration, float _delayBetween)
		{
			m_mainCamera.orthographicSize = m_defaultOrthoValue; 
			yield return LerpOrthoSizeToCoroutine(m_defaultOrthoValue, _endValue, _duration * 0.5f);

			if (_delayBetween > 0f)
			{
				yield return HelperMethods.CustomWFS(_delayBetween);
			}

			yield return LerpOrthoSizeToCoroutine(_endValue, m_defaultOrthoValue, _duration * 0.5f);
		}

		private IEnumerator LerpOrthoSizeToCoroutine(float _startValue, float _endValue, float _duration)
		{
            m_mainCamera.orthographicSize = _startValue;
			float elapsedTime = 0;
			while (elapsedTime < _duration)
			{
				float value = Mathf.Lerp(_startValue, _endValue, elapsedTime / _duration);
                m_mainCamera.orthographicSize = value;
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			m_mainCamera.orthographicSize = _endValue;
		}
		#endregion
	}
}

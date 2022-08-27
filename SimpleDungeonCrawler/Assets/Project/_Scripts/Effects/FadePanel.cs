// ######################################################################
// FadePanel - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project.Effects
{
	public class FadePanel : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_defaultDuration = 0.5f;
		[SerializeField] private float m_defaultDelayBetween = 0.25f;
		[SerializeField] private CanvasGroup m_canvasGroup;
		#endregion

		#region Internal State Field(s):
		private Coroutine m_currentFadeCoroutine = null;
		#endregion
		
		#region Public API:
		public void AlphaOverride(float _alpha) => m_canvasGroup.alpha = _alpha;
		public void FadeOut(float _duration = 0f)
		{
			StopCoroutineIfRunning();

			m_currentFadeCoroutine = StartCoroutine(HelperMethods.LerpCanvasGroupAlpha(0f, 1f, (_duration > 0f) ? _duration : m_defaultDuration, m_canvasGroup));
		}

		public IEnumerator FadeOutCoroutine(float _duration = 0f)
		{
			StopCoroutineIfRunning();

			yield return StartCoroutine(HelperMethods.LerpCanvasGroupAlpha(0f, 1f, (_duration > 0f) ? _duration : m_defaultDuration, m_canvasGroup));
		}

		public void FadeIn(float _duration = 0f)
		{
			StopCoroutineIfRunning();

			m_currentFadeCoroutine = StartCoroutine(HelperMethods.LerpCanvasGroupAlpha(1f, 0f, (_duration > 0f) ? _duration : m_defaultDuration, m_canvasGroup));
		}

		public IEnumerator FadeInCoroutine(float _duration = 0f)
		{
			StopCoroutineIfRunning();

			yield return StartCoroutine(HelperMethods.LerpCanvasGroupAlpha(1f, 0f, (_duration > 0f) ? _duration : m_defaultDuration, m_canvasGroup));
		}


		public void FadeInOut(float _duration = 0f, float _delayBetween = 0f)
		{
			StopCoroutineIfRunning();

			float duration = (_duration > 0f) ? _duration : m_defaultDuration;
			float delayBetween = (_delayBetween > 0f) ? _delayBetween : m_defaultDelayBetween;

			m_currentFadeCoroutine = StartCoroutine(FadeInOutCoroutine(duration, delayBetween));
		}
		#endregion

		#region Internally Used Method(s):
		private void StopCoroutineIfRunning() => HelperMethods.StopCoroutineIfRunning(ref m_currentFadeCoroutine, this);
		#endregion

		#region Coroutine(s):
		private IEnumerator FadeInOutCoroutine(float _duration, float _delayBetween)
		{
			yield return HelperMethods.LerpCanvasGroupAlpha(0f, 1f, _duration * 0.5f, m_canvasGroup);

			if (_delayBetween > 0f)
			{
				yield return HelperMethods.CustomWFS(_delayBetween);
			}

			yield return HelperMethods.LerpCanvasGroupAlpha(1f, 0f, _duration * 0.5f, m_canvasGroup);
		}
		#endregion
	}
}
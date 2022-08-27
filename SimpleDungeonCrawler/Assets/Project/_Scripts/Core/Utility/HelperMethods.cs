// ######################################################################
// HelperMethods - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project
{
	public static class HelperMethods
	{
		#region Internal State Field(s):
		
		#endregion

		#region Public API:
		public static IEnumerator CustomWFS(float _delayTime)
		{
			float timer = 0;
			while (timer < _delayTime)
			{
				timer += Time.deltaTime;
				yield return null;
			}
		}
		public static IEnumerator LerpCanvasGroupAlpha(float _start, float _end, float _duration, CanvasGroup _canvasGroup)
		{
			_canvasGroup.alpha = _start;
			float elapsedTime = 0f;
			while (elapsedTime < _duration)
			{
				_canvasGroup.alpha = Mathf.Lerp(_start, _end, elapsedTime / _duration);
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			_canvasGroup.alpha = _end;
		}

		public static void StopCoroutineIfRunning(ref Coroutine _coroutine, MonoBehaviour _monoBehaviour)
		{
			if (_coroutine == null || _monoBehaviour == null) { return; }
			
			_monoBehaviour.StopCoroutine(_coroutine);
			_coroutine = null;
		}
		#endregion
	}
}
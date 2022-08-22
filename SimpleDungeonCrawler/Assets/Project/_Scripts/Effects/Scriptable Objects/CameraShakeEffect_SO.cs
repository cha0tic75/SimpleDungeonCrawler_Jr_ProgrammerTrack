// ######################################################################
// CameraShakeEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Effects
{
    [CreateAssetMenu(menuName = "SO/Effects/Camera Shake Effect", fileName = "New Camera Shake Effect")]
	public class CameraShakeEffect_SO : BaseEffect_SO
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_shakeDuration = 0.1f;
		[SerializeField] private float m_shakeMagnitude = 0.1f;
		#endregion

		#region Public API:
		public override void PerformEffect(GameObject _gameObject) => 
                GameManagement.GameManager.Instance.CameraTools.CameraShaker.Shake(m_shakeDuration, m_shakeMagnitude);
		#endregion
	}
}

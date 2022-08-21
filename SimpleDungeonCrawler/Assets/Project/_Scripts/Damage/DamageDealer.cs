// ######################################################################
// DamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using Project.Actors.Stats;
using UnityEngine;

namespace Project.Damage
{
    public class DamageDealer : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private List<BaseDamageDealerHandler> m_damageHandlers;
		#endregion

		#region Internal State Field(s):
		private Dictionary<TargetAcquisitionType, List<BaseDamageDealerHandler>> m_damageHandlersDict;
		private BaseTargetProvider<Actors.Stats.IDamagable> m_targetProvider;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => BuildDamageHandlersDict();
		private void OnEnable()
		{
			if (m_targetProvider == null)
			{
				m_targetProvider = GetComponent<BaseTargetProvider<Actors.Stats.IDamagable>>();
			}
			m_targetProvider.OnTargetUpdatedEvent += TargetProvider_OnTargetUpdatedCallback;
		}

		private void OnDisable() => 
			m_targetProvider.OnTargetUpdatedEvent -= TargetProvider_OnTargetUpdatedCallback;

        #endregion

		#region Internally Used Method(s):
		private void BuildDamageHandlersDict()
		{
			m_damageHandlersDict = new Dictionary<TargetAcquisitionType, List<BaseDamageDealerHandler>>();
			
			foreach (var damageHandler in m_damageHandlers)
			{
				TargetAcquisitionType acquisitionType = damageHandler.AcquisitionType;
				if (!m_damageHandlersDict.ContainsKey(acquisitionType))
				{
					m_damageHandlersDict.Add(acquisitionType, new List<BaseDamageDealerHandler>());
				}

				m_damageHandlersDict[acquisitionType].Add(damageHandler);
			}
		}
		#endregion

		#region Callback(s):
        private void TargetProvider_OnTargetUpdatedCallback(IDamagable[] _damagable, TargetAcquisitionType _acquisitionType)
        {
			if (!m_damageHandlersDict.ContainsKey(_acquisitionType)) { return; }
			
			foreach (var damageHandler in m_damageHandlersDict[_acquisitionType])
			{
				foreach (var damagable in _damagable)
				{
					damageHandler.Handle(damagable);
				}
			}
        }
		#endregion
    }
}
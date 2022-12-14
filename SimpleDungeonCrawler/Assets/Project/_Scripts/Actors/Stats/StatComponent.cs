// ######################################################################
// StatComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Actors.Stats
{
    public class StatComponent : MonoBehaviour, IDamagable, IHealable
	{
		#region Delegate(s):
		public event Action<float, StatComponent> OnTakeDamageEvent;
		public event Action<float, StatComponent> OnValueChangedEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[field: SerializeField] public StatType_SO StatType { get; private set; }
#if UNITY_EDITOR
		[field: SerializeField, ReadOnly] 
#endif
		public float CurrentValue { get; protected set; }
		[field: SerializeField] public MinMaxFloat ValueRange { get; private set; } = new MinMaxFloat(0f, 10f);
        [SerializeField] private UI.StatMeterUI m_statMeter;

		[SerializeField] private List<Effects.BaseEffect_SO> m_damageEffects = new List<Effects.BaseEffect_SO>();
        #endregion

		#region Properties:
		public float Percent => CurrentValue / (float)ValueRange.Max;
		public Transform Transform => transform;
		#endregion

        #region MonoBehaviour Callback Method(s):
        private void Start()
        {
            CurrentValue = ValueRange.Max;

            if (m_statMeter == null)
            {
                List<UI.StatMeterUI> statMeters = FindObjectsOfType<UI.StatMeterUI>().ToList();
                m_statMeter = statMeters.Find(sm => sm.StatType == StatType);
            }
        }
        #endregion

        #region Public API:
        public virtual void Consume(float _consumeAmount, StatConsumeType _consumeType)
		{
			AlterCurrentValue(-_consumeAmount);
			if (_consumeType == StatConsumeType.Damage)
			{
				m_damageEffects.ForEach(de => de.PerformEffect(gameObject));
				OnTakeDamageEvent?.Invoke(_consumeAmount, this);
			}
		}

        public virtual void Apply(float _applyAmount) => AlterCurrentValue(_applyAmount);
        #endregion

		#region Internally Used Method(s):
		protected void AlterCurrentValue(float _value)
		{
			CurrentValue = Mathf.Clamp(CurrentValue + _value, 0, ValueRange.Max);
            m_statMeter?.UpdateMeter(this);
			OnValueChangedEvent?.Invoke(_value, this);
		}
		#endregion
	}
}

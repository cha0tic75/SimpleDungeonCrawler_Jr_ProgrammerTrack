// ######################################################################
// BaseColliderNotifier - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    [System.Flags]
	public enum CollisionAcquisitionType
	{
		None = 0,
		OnEnter = 1, 
		OnExit = 2, 
		All = ~0
	}
	[RequireComponent(typeof(Collider2D))]
	public abstract class BaseColliderNotifier : MonoBehaviour
	{
		#region Delegate(s):
		public event Action<Collider2D> OnEnterEvent;
		public event Action<Collider2D> OnExitEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] protected CollisionAcquisitionType m_collisionAcquisitionType;
		#endregion

		#region Internally Used Method(s):
		protected bool HasFlags(CollisionAcquisitionType _collisionAcquisitionType) => 
					m_collisionAcquisitionType.HasFlag(_collisionAcquisitionType);
		#endregion
		
		#region Public API:
		protected virtual void HandleOnEnter(Collider2D _collider) => OnEnterEvent?.Invoke(_collider);

		protected virtual void HandleOnExit(Collider2D _collider) => OnExitEvent?.Invoke(_collider);
		#endregion
	}
}

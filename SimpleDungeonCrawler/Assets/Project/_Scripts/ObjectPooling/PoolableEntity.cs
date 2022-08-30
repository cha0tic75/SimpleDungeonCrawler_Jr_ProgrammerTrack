// ######################################################################
// PoolableEntity - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.ObjectPooling
{
    public abstract class PoolableEntity : MonoBehaviour
	{
		public virtual void ReturnToObjectPool()
		{
			GameManagement.GameManager.Instance.PrefabObjectPooler.CheckIn(this);
		}
	}
}

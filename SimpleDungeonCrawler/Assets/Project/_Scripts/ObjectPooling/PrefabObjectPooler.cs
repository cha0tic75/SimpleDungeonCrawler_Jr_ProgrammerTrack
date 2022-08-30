// ######################################################################
// PrefabObjectPooler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.ObjectPooling
{
	public class PrefabObjectPooler : TransformMonoBehaviour
	{
		#region Properties:
		private Dictionary<Effects.SpawnPoolableEntityEffect_SO, List<PoolableEntity>> m_objectPool = new Dictionary<Effects.SpawnPoolableEntityEffect_SO, List<PoolableEntity>>();
		#endregion

		#region Public API:
		public void CheckIn(PoolableEntity _obj) => _obj.gameObject.SetActive(false);
		public PoolableEntity Checkout(Effects.SpawnPoolableEntityEffect_SO _prefabEffect_so)
		{
			PoolableEntity obj = FindFreeItem(_prefabEffect_so);
			obj.gameObject.SetActive(true);

			return obj;
		}
		#endregion

		#region Internally Used Method(s):
		private PoolableEntity FindFreeItem(Effects.SpawnPoolableEntityEffect_SO _prefabEffect_so)
		{
			if (!m_objectPool.ContainsKey(_prefabEffect_so))
			{
				m_objectPool.Add(_prefabEffect_so, new List<PoolableEntity>());
			}

			List<PoolableEntity> candidates = m_objectPool[_prefabEffect_so].FindAll( item => item.gameObject.activeSelf == false);


			return (candidates.Count > 0) ? candidates[0] : CreateNewItem(_prefabEffect_so);
		}

		private PoolableEntity CreateNewItem(Effects.SpawnPoolableEntityEffect_SO _prefabEffect_so)
		{
			if (!m_objectPool.ContainsKey(_prefabEffect_so))
			{
				m_objectPool.Add(_prefabEffect_so, new List<PoolableEntity>());
			}

			PoolableEntity newItem = Instantiate(_prefabEffect_so.Prefab, Vector3.zero, Quaternion.identity, Transform);
			m_objectPool[_prefabEffect_so].Add(newItem);
			return newItem;
		}
		#endregion
	}
}

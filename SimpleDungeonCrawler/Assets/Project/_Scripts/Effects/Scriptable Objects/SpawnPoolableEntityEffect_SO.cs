// ######################################################################
// SpawnPoolableEntityEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Effects
{
    [CreateAssetMenu(menuName = "SO/Effects/Spawn Prefab Effect", fileName = "New Spawn Prefab Effect")]
	public class SpawnPoolableEntityEffect_SO : BaseEffect_SO
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public ObjectPooling.PoolableEntity Prefab { get; private set; }
		#endregion

		#region Public API:
		public override void PerformEffect(GameObject _gameObject)
		{
			ObjectPooling.PoolableEntity go = GameManagement.GameManager.Instance.PrefabObjectPooler.Checkout(this);
			go.transform.position = _gameObject.transform.position;
		}
		#endregion
	}
}

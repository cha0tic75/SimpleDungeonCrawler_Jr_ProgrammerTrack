// ######################################################################
// PlayerInventory - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project.Actors.Player
{
    public class PlayerInventory : TransformMonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField, ReadOnly] public Interaction.ItemInteractionHandler CurrentItem { get; private set;} = null;
		#endregion

		#region Properties:
		public bool HasItem => CurrentItem != null;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() { } // This is just here to expose the enable/disable toggle in inspector
		#endregion

		#region Public API:
		public void AddItem(Interaction.ItemInteractionHandler _item)
		{
			if (CurrentItem != null) { RemoveItem(CurrentItem); }

			CurrentItem = _item;
			CurrentItem.transform.parent = Transform;
			CurrentItem.transform.localPosition = Vector3.zero;
			CurrentItem.gameObject.layer = LayerMask.NameToLayer("Default");
		}

		public void RemoveItem(Interaction.ItemInteractionHandler _item) => 
			StartCoroutine(DropItemCoroutine(_item));

		public void AttemptToDropCurrent()
		{
			if (CurrentItem == null) { return; }
			
			RemoveItem(CurrentItem);
		}
		#endregion

		#region Coroutine(s):
		private IEnumerator DropItemCoroutine(Interaction.ItemInteractionHandler _item)
		{
			_item.transform.parent = null;
			CurrentItem = null;
			yield return HelperMethods.CustomWFS(0.2f);
			_item.gameObject.layer = LayerMask.NameToLayer("Interactable");
		}
		#endregion
	}
}

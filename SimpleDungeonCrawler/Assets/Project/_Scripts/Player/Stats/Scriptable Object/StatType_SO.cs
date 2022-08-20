// ######################################################################
// StatType_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Player.Stats
{
	[CreateAssetMenu(menuName = "SO/Stats/New Stat Type", fileName = "New STat Type")]
	public class StatType_SO : ScriptableObject
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public string Name { get; private set; }
		#endregion
	}
}

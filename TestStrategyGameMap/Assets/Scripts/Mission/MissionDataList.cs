using UnityEngine;

namespace MissionSystem
{
	[CreateAssetMenu(fileName = "MissionDataList", menuName = "Config" + "/Mission/List", order = 52)]
	public sealed class MissionDataList : ScriptableObject
	{
		[field: SerializeField] public MissionData[] Missions { get; private set; }
	}
}
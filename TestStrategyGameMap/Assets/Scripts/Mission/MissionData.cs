using System.Collections.Generic;
using Map;
using Units;
using UnityEngine;

namespace MissionSystem
{
	[CreateAssetMenu(fileName = "MissionData", menuName = "Config" + "/Mission/Data", order = 51)]
	public sealed class MissionData : ScriptableObject
	{
		[field: SerializeField] public int Number { get; private set; }
		[field: SerializeField] public string Name { get; private set; }
		[field: SerializeField] public string Annotation { get; private set; }
		[field: SerializeField] public string MissionContext { get; private set; }
		[field: SerializeField] public Coordinate Coordinates { get; private set; }
		[field: SerializeField] public MissionState Status { get; private set; }
		[field: SerializeField] public List<Bird> PlayerUnits { get; private set; }
		[field: SerializeField] public List<Bird> EnemyUnits { get; private set; }
	}
}
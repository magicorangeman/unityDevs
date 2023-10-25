using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gameplay;
using Parameters;
using Units;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

namespace MissionSystem
{
	[CreateAssetMenu(fileName = "MissionData", menuName = "Config" + "/Mission/Data", order = 51)]
	public sealed class MissionData : ScriptableObject
	{
		[field: SerializeField] public string Number { get; private set; }
		[field: SerializeField] public string Name { get; private set; }
		[field: SerializeField] public string Annotation { get; private set; }
		
		[field: SerializeField] public string MissionContext { get; private set; }
		[field: SerializeField] public Coordinate Coordinates { get; private set; }
		[field: SerializeField] public MissionState Status { get; private set; }
		[field: SerializeField] public List<BirdCardData> PlayerUnits { get; private set; }
		[field: SerializeField] public List<BirdCardData> EnemyUnits { get; private set; }
		[field: SerializeField] public bool IsDouble { get; private set; }
		[field: SerializeField] public MissionData AssociatedMission { get; private set; }
		[field: SerializeField] public Bounty Bounty { get; private set; }
		
		[field: SerializeField] public MissionData[] UnlockingMission { get; private set; }
		
		[field: SerializeField] public MissionData[] BlockingMission { get; private set; }
	}
}
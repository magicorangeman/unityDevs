using MissionSystem;
using Units;
using UnityEngine;

namespace Player
{
	[CreateAssetMenu(fileName = "NewGameData", menuName = "Config" + "/Game/Data", order = 51)]
	public class ProgressData : ScriptableObject
	{
		[field: SerializeField] public BirdCardData[] AvailableBirds { get; private set; }
		[field: SerializeField] public MissionData[] MissionsList { get; private set; }
		[field: SerializeField] public int Points { get; private set; }
	}
}
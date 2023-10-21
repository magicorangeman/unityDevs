using Units;
using UnityEngine;

namespace Player
{
	[CreateAssetMenu(fileName = "NewGameData", menuName = "Config" + "/Game/Data", order = 51)]
	public class NewGameData : ScriptableObject
	{
		[field: SerializeField] public BirdCardData[] AvailableBirds { get; private set; }
		[field: SerializeField] public int Points { get; private set; }
	}
}
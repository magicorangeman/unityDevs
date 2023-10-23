using UnityEngine;

namespace Units
{
	[CreateAssetMenu(fileName = "BirdCardData", menuName = "Config" + "/Bird/Data", order = 51)]
	public class BirdCardData : ScriptableObject
	{
		[field: SerializeField] public string birdName;
		[field: SerializeField] public Texture iconTexture;
		[field: SerializeField] public int points;
	}
}
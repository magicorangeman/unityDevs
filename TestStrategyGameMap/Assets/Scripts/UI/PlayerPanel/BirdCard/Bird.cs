using UnityEngine;

namespace Units
{
	public class Bird : MonoBehaviour
	{
		public string Name { get; private set; }
		public int Points{ get; private set; }

		public void Initialize(BirdCardData data)
		{
			Name = data.birdName;
			Points = data.points;
		}

		public void GainPoints(int points)
		{
			Points += points;
		}
	}
}
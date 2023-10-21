using UnityEngine;

namespace Map
{
	public class Coordinate<T> {
		[SerializeField]
		public T x, y;
	}

	[System.Serializable]
	public class Coordinate : Coordinate<float> { }
}
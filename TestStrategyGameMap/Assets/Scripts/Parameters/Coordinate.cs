using UnityEngine;

namespace Parameters
{
	public class Coordinate<T> {
		[SerializeField]
		public T x, y;
	}

	[System.Serializable]
	public class Coordinate : Coordinate<float> { }
}
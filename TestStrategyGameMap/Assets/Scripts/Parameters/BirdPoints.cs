using System;
using Units;
using UnityEngine;

namespace Parameters
{
	[Serializable]
	public class BirdPoints
	{
		[field: SerializeField] public BirdCardData Bird { get; private set; }
		[field: SerializeField] public int Points { get; private set; }
	}
}
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace MissionSystem
{
	public class Mission : MonoBehaviour
	{
		public MissionState Status { get; private set; }
		public Bounty Bounty { get; private set; }
		public List<BirdCardData> PlayerUnits { get; private set; } = new();
		public List<BirdCardData> EnemyUnits { get; private set; } = new();

		public bool IsDouble { get; private set; }
		
		public void Initialize(MissionData data)
		{
			Status = data.Status;

			Bounty = data.Bounty;
			
			foreach (var unit in data.PlayerUnits)
			{
				PlayerUnits.Add(unit);
			}
			
			foreach (var unit in data.EnemyUnits)
			{
				EnemyUnits.Add(unit);
			}
		}
	}
}
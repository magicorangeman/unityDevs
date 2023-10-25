using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay;
using Parameters;
using Units;
using UnityEngine;

namespace MissionSystem
{
	public class Mission : MonoBehaviour
	{
		public string Number { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public string MissionContext { get; private set; }
		public Coordinate Coordinates { get; private set; }
		public MissionState Status { get; private set; }
		private Bounty Bounty { get; set; }
		public List<Bird> PlayerUnits { get; } = new();
		public List<Bird> EnemyUnits { get; } = new();
		private bool IsDouble { get; set; }
		private Mission AssociatedMission { get; set; }

		public event Action<Bounty, Bird> OnGainBounty;

		public void Initialize(MissionData data)
		{
			Number = data.Number;
			Name = data.Name;
			Description = data.Annotation;
			MissionContext = data.MissionContext;
			Coordinates = data.Coordinates;
			Status = data.Status;
			Bounty = data.Bounty;
			IsDouble = data.IsDouble;
			
			if (IsDouble && Installer.Missions.TryGetValue(data.AssociatedMission.Number, out var mission))
			{
				AssociatedMission = mission;
				AssociatedMission.AssociatedMission = this;
			}

			foreach (var bird in data.PlayerUnits.Select(unit => Installer.Birds[unit.birdName]))
			{
				PlayerUnits.Add(bird);
			}
			
			foreach (var bird in data.EnemyUnits.Select(unit => Installer.Birds[unit.birdName]))
			{
				EnemyUnits.Add(bird);
			}
		}

		public void EarnBounty(Bird bird)
		{
			Status = MissionState.COMPLETE;
			if (IsDouble && AssociatedMission != null)
			{
				AssociatedMission.Status = MissionState.COMPLETE;
			}

			foreach (var missionData in Installer.MissionData[this].UnlockingMission)
			{
				var mission = Installer.Missions[missionData.Number];
				mission.Status = MissionState.ACTIVE;
			}
			
			foreach (var missionData in Installer.MissionData[this].BlockingMission)
			{
				var mission = Installer.Missions[missionData.Number];
				mission.Status = MissionState.BLOCKED;
			}
			
			OnGainBounty?.Invoke(Bounty, bird);
		}
	}
}
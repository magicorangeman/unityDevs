using System;
using System.Collections.Generic;
using Gameplay;
using MissionSystem;
using Player;
using Units;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
	[SerializeField] private ProgressData _progressData;

	public List<Bird> AvailableUnits { get; } = new();
	public List<Mission> AvailableMissions { get; } = new();

	public event Action OnMissionComplete; 

	public void Initialize()
	{
		foreach (var birdData in _progressData.AvailableBirds)
		{
			var bird = Installer.Birds[birdData.birdName];
			AvailableUnits.Add(bird);
		}

		foreach (var missionData in _progressData.MissionsList)
		{
			var mission = Installer.Missions[missionData.Number];
			mission.OnGainBounty += GetBounty;
			AvailableMissions.Add(mission);
		}
	}

	private void GetBounty(Bounty bounty, Bird awardedBird)
	{
		awardedBird.GainPoints(bounty.AwardPoints);
		
		foreach (var birdData in bounty.newUnits)
		{
			AvailableUnits.Add(Installer.Birds[birdData.birdName]);
		}

		foreach (var birdPoint in bounty.birdPoints)
		{
			var bird = Installer.Birds[birdPoint.Bird.birdName];
			if (birdPoint.Points < 0)
			{
				bird.GainPoints(birdPoint.Points);
			}
			else
			{
				if (AvailableUnits.Contains(bird))
				{
					bird.GainPoints(birdPoint.Points);
				}
			}
		}

		UpdateMissionProgress();
	}

	private void UpdateMissionProgress()
	{
		OnMissionComplete?.Invoke();
	}
}
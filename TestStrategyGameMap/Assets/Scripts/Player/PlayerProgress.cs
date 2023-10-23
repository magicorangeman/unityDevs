using System.Collections.Generic;
using System.Linq;
using Gameplay;
using MissionSystem;
using Player;
using Units;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
	[SerializeField] private ProgressData _progressData;

	public List<Bird> AvailableUnits { get; private set; } = new();
	public List<Mission> AvailableMissions { get; private set; } = new();
	public int Points { get; private set; }
	
	public void Initialize()
	{
		foreach (var birdData in _progressData.AvailableBirds)
		{
			AvailableUnits.Add(Installer.Birds[birdData.birdName]);
		}

		foreach (var missionData in _progressData.MissionsList)
		{
			AvailableMissions.Add(Installer.Missions[missionData.Number]);
		}

		Points = _progressData.Points;
	}
}
using System.Collections.Generic;
using MissionSystem;
using Player;
using Units;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
	[SerializeField] private NewGameData _newGameData;
	public int GlobalPoints;
	public List<BirdCardData> AvailableUnits;
	public List<ViewMission> MissionsCompleted;
	
	public void Initialize()
	{
		foreach (var bird in _newGameData.AvailableBirds)
		{
			AvailableUnits.Add(bird);
		}

		GlobalPoints = _newGameData.Points;
	}
}

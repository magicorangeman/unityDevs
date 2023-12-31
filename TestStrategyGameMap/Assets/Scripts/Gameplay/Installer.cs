﻿using System.Collections.Generic;
using MissionSystem;
using Units;
using UnityEngine;

namespace Gameplay
{
	public class Installer : MonoBehaviour
	{
		[SerializeField] private MissionData[] _missionList;
		[SerializeField] private BirdCardData[] _birdDeck;

		public static Dictionary<Mission, MissionData> MissionData { get; private set; } = new();
		public static Dictionary<Bird, BirdCardData> BirdData { get; private set; } = new();
		
		public static Dictionary<string, Mission> Missions { get; private set; } = new();
		public static Dictionary<string, Bird> Birds { get; private set; } = new();

		public void Initialize()
		{
			foreach (var birdData in _birdDeck)
			{
				var bird = gameObject.AddComponent<Bird>();
				bird.Initialize(birdData);
				Birds[birdData.birdName] = bird;
				BirdData[bird] = birdData;
			}
			
			foreach (var missionData in _missionList)
			{
				var mission = gameObject.AddComponent<Mission>();
				Missions[missionData.Number] = mission;
				MissionData[mission] = missionData;
				mission.Initialize(missionData);
			}
		}
	}
}
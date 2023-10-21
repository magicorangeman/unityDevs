using System;
using System.Collections.Generic;
using MissionSystem;
using UnityEngine;

namespace Map
{
	public class MapGenerator : MonoBehaviour
	{
		[SerializeField] private MissionDataList _missionDataList;
		[SerializeField] private GameObject _missionPrefab;

		private List<ViewMission> _missions = new();

		public event Action<ViewMission> OnSelectMission;
		public event Action<ViewMission> OnStartMission;

		private void Awake()
		{
			GenerateMap();
		}

		public void GenerateMap()
		{
			foreach (var data in _missionDataList.Missions)
			{
				var missionObject = ViewMissionOnMap(data);
				var mission = missionObject.GetComponent<ViewMission>();
			
				mission.Initialize(data);
				mission.parent = transform;
				_missions.Add(mission);
			
				mission.ViewButtonClicked += InvokeWhenSelect;
				mission.StartButtonClicked += InvokeWhenStart;
			}
		}

		private GameObject ViewMissionOnMap(MissionData data)
		{
			var position = new Vector2(data.Coordinates.x, data.Coordinates.y);
			return Instantiate(_missionPrefab, position, Quaternion.identity, transform);
		}
		
		private void InvokeWhenSelect(ViewMission mission) => OnSelectMission?.Invoke(mission);
		private void InvokeWhenStart(ViewMission mission) => OnStartMission?.Invoke(mission);
	}
}

using System;
using System.Collections.Generic;
using Gameplay;
using MissionSystem;
using UnityEngine;

namespace UI
{
	public class UIMap : MonoBehaviour
	{
		[SerializeField] private GameObject _missionPrefab;

		private List<ViewMission> _missions = new();

		public event Action<ViewMission> OnSelectMission;
		public event Action<ViewMissionDetails> OnStartMission;

		public void GenerateMap(List<Mission> missions)
		{
			foreach (var mission in missions)
			{
				var missionObject = ViewMissionOnMap(mission);
				var missionButton = missionObject.GetComponent<ViewMission>();
				missionButton.Initialize(mission);
				_missions.Add(missionButton);
			
				missionButton.ViewButtonClicked += InvokeWhenSelect;
				missionButton.StartButtonClicked += InvokeWhenStart;
			}
		}

		private GameObject ViewMissionOnMap(Mission mission)
		{
			var data = Installer.MissionData[mission];
			var position = new Vector2(data.Coordinates.x, data.Coordinates.y);
			return Instantiate(_missionPrefab, position, Quaternion.identity, transform);
		}
		
		private void InvokeWhenSelect(ViewMission mission) => OnSelectMission?.Invoke(mission);
		private void InvokeWhenStart(ViewMissionDetails details) => OnStartMission?.Invoke(details);
	}
}

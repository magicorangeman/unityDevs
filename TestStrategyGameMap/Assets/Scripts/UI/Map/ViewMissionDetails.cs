using System;
using MissionSystem;
using TMPro;
using UnityEngine;

namespace UI
{
	public class ViewMissionDetails : MonoBehaviour
	{
		[SerializeField] private TMP_Text _name;
		[SerializeField] private TMP_Text _description;
		[SerializeField] private GameObject _missionScreenPrefab;
		
		public ViewMissionScreen MissionScreen { get; private set; }
		private Mission _mission;
		private GameObject _missionScreenObject;
		
		public event Action<ViewMissionDetails> OnStartButtonClicked;

		public void Initialize(Mission mission)
		{
			_name.text = mission.Name;
			_description.text = mission.Description;
			_mission = mission;
		}
		
		public void StartMission()
		{
			OnStartButtonClicked?.Invoke(this);
		}

		public void ViewMissionScreen()
		{
			_missionScreenObject = Instantiate(_missionScreenPrefab, default, default, transform.parent.parent);
			MissionScreen = _missionScreenObject.GetComponent<ViewMissionScreen>();
			MissionScreen.Initialize(_mission);
		}
		
		public void HideMissionScreen()
		{
			Destroy(_missionScreenObject);
			_missionScreenObject = null;
		}
	}
}
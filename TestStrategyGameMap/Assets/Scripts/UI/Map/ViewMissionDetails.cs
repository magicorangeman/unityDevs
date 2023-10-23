using System;
using Gameplay;
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

		private Mission _mission;
		private GameObject _missionScreen;
		
		public event Action<ViewMissionDetails> OnStartButtonClicked;
		public event Action OnEndMission;

		public void Initialize(Mission mission)
		{
			var data = Installer.MissionData[mission];
			_name.text = data.Name;
			_description.text = data.Annotation;
			_mission = mission;
		}
		
		public void StartMission()
		{
			OnStartButtonClicked?.Invoke(this);
		}

		public void ViewMissionScreen()
		{
			_missionScreen = Instantiate(_missionScreenPrefab, default, default, transform.parent.parent);
			var missionScreen = _missionScreen.GetComponent<ViewMissionScreen>();
			missionScreen.Initialize(_mission);
			missionScreen.OnEndMission += InvokeWhenEnd;
		}
		
		public void HideMissionScreen()
		{
			_missionScreen.GetComponent<ViewMissionScreen>().OnEndMission -= InvokeWhenEnd;
			Destroy(_missionScreen);
			_missionScreen = null;
		}

		private void InvokeWhenEnd() => OnEndMission?.Invoke();
	}
}
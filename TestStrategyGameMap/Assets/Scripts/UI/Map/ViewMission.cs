using System;
using Gameplay;
using TMPro;
using UI;
using UnityEngine;

namespace MissionSystem
{
	public class ViewMission : MonoBehaviour
	{
		[SerializeField] private TMP_Text _numberText;
		[SerializeField] private GameObject _missionDetailsPrefab;

		private Mission _mission;
		
		public event Action<ViewMission> ViewButtonClicked;
		
		public event Action<ViewMissionDetails> StartButtonClicked;

		private GameObject _details;

		public void Initialize(Mission mission)
		{
			var data = Installer.MissionData[mission];
			_mission = mission;
			_numberText.text = data.Number.ToString();
		}

		public void ClickButton()
		{
			ViewButtonClicked?.Invoke(this);
		}

		public void ViewMissionDetails()
		{
			_details = Instantiate(_missionDetailsPrefab, _missionDetailsPrefab.transform.position, default, transform);
			
			var missionDetails = _details.GetComponent<ViewMissionDetails>();
			missionDetails.Initialize(_mission);
			
			missionDetails.OnStartButtonClicked += InvokeWhenStart;
		}

		public void HideMissionDetails()
		{
			_details.GetComponent<ViewMissionDetails>().OnStartButtonClicked -= InvokeWhenStart;
			Destroy(_details);
			_details = null;
		}

		private void InvokeWhenStart(ViewMissionDetails details) => StartButtonClicked?.Invoke(details);
	}
}

using MissionSystem;
using UnityEngine;

namespace UI
{
	public class UIMissionManager : MonoBehaviour
	{
		[SerializeField] private UIMap _uiMap;
		[SerializeField] private UICardSelector _cardSelector;

		private bool _isViewMissionDetailsOn;
		
		private ViewMission _activeView;
		private ViewMissionDetails _activeMission;
		
		private void Awake()
		{
			_uiMap.OnSelectMission += ViewMissionDetails;
			_uiMap.OnStartMission += StartMission;
		}

		private void ViewMissionDetails(ViewMission mission)
		{
			if (_activeView == mission)
			{
				mission.HideMissionDetails();
				_isViewMissionDetailsOn = false;
				_activeView = null;
				return;
			}

			if (_isViewMissionDetailsOn)
			{
				_activeView.HideMissionDetails();
			}
			
			mission.ViewMissionDetails();
			_activeView = mission;
			_isViewMissionDetailsOn = true;
		}

		private void StartMission(ViewMissionDetails details)
		{
			if (_cardSelector.SelectedCard == null)
			{
				return;
			}

			_activeMission = details;
			details.ViewMissionScreen();
			details.OnEndMission += EndMission;
		}

		private void EndMission()
		{
			_activeMission.OnEndMission -= EndMission;
			_activeMission.HideMissionScreen();
			_activeView.HideMissionDetails();
		}
	}
}
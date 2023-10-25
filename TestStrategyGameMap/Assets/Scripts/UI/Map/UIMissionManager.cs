using System.Linq;
using MissionSystem;
using UnityEngine;

namespace UI
{
	public class UIMissionManager : MonoBehaviour
	{
		[SerializeField] private UIMap _uiMap;
		[SerializeField] private UICardSelector _cardSelector;

		private ViewMission _activeView;

		public void GetViewMissionList()
		{
			foreach (var viewMission in _uiMap.ViewMissions.Where(x=> x.Mission.Status != MissionState.BLOCKED))
			{
				viewMission.ViewButtonClicked += ViewMissionDetails;
			}
		}

		private void ViewMissionDetails(ViewMission viewMission)
		{
			if (_activeView == viewMission)
			{
				_activeView.Details.OnStartButtonClicked -= StartMission;
				viewMission.HideDetails();
				_activeView = null;
				
				return;
			}

			if (_activeView != null)
			{
				_activeView.HideDetails();
			}
			
			viewMission.ViewDetails();
			_activeView = viewMission;
			_activeView.Details.OnStartButtonClicked += StartMission;
		}

		private void StartMission(ViewMissionDetails details)
		{
			if (_cardSelector.SelectedCard == null)
			{
				return;
			}

			if (!_activeView.Mission.PlayerUnits.Contains(_cardSelector.SelectedCard.Bird))
			{
				return;
			}
			
			details.ViewMissionScreen();
			details.OnStartButtonClicked -= StartMission;
			_activeView.Details.MissionScreen.OnEndMission += EndMission;
		}

		private void EndMission(ViewMissionScreen screen)
		{
			screen.OnEndMission -= EndMission;
			_activeView.Details.HideMissionScreen();
			_activeView.HideDetails();
			_activeView.Mission.EarnBounty(_cardSelector.SelectedCard.Bird);
			_activeView = null;
		}
	}
}
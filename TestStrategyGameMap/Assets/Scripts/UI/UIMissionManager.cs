using Map;
using MissionSystem;
using UnityEngine;

namespace UI
{
	public class UIMissionManager : MonoBehaviour
	{
		[SerializeField] private MapGenerator _generator;

		private bool _isViewMissionDetailsOn;
		private ViewMission _activeView;
		
		private void Awake()
		{
			_generator.OnSelectMission += ViewMissionDetails;
			_generator.OnStartMission += StartMission;
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

		private void StartMission(ViewMission mission)
		{
			
		}
	}
}
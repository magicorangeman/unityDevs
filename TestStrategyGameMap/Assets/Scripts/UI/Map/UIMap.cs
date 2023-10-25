using System.Collections.Generic;
using System.Linq;
using MissionSystem;
using UnityEngine;

namespace UI
{
	public class UIMap : MonoBehaviour
	{
		[SerializeField] private GameObject _missionPrefab;

		private List<GameObject> _viewMissionsObjects = new();
		public List<ViewMission> ViewMissions { get; private set; } = new();

		public void GenerateMap(List<Mission> missions)
		{
			foreach (var viewMissionsObject in _viewMissionsObjects)
			{
				Destroy(viewMissionsObject);
			}
			
			_viewMissionsObjects.Clear();
			
			foreach (var mission in missions.Where(x => x.Status != MissionState.HIDDEN))
			{
				var missionObject = ViewMissionOnMap(mission);
				var viewMission = missionObject.GetComponent<ViewMission>();
				viewMission.View(mission);
				ViewMissions.Add(viewMission);
				_viewMissionsObjects.Add(missionObject);
			}
		}

		private GameObject ViewMissionOnMap(Mission mission)
		{
			var position = new Vector2(mission.Coordinates.x, mission.Coordinates.y);
			return Instantiate(_missionPrefab, position, default, transform);
		}
	}
}

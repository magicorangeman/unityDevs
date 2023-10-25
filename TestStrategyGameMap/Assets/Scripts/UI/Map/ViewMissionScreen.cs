using System;
using System.Linq;
using MissionSystem;
using TMPro;
using UnityEngine;

namespace UI
{
	public class ViewMissionScreen : MonoBehaviour
	{
		[SerializeField] private TMP_Text _missionName;
		[SerializeField] private TMP_Text _missionContext;
		[SerializeField] private TMP_Text _playerUnits;
		[SerializeField] private TMP_Text _enemyUnits;
		
		public event Action<ViewMissionScreen> OnEndMission;

		public void Initialize(Mission mission)
		{
			_missionName.text = mission.Name;
			_missionContext.text = mission.MissionContext;
			_playerUnits.text = string.Join("\n", mission.PlayerUnits.Select(x => x.Name));
			_enemyUnits.text = string.Join("\n", mission.EnemyUnits.Select(x => x.Name));
		}

		public void EndMission()
		{
			OnEndMission?.Invoke(this);
		}
	}
}
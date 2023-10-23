using System;
using System.Linq;
using Gameplay;
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

		public event Action OnEndMission;

		public void Initialize(Mission mission)
		{
			var data = Installer.MissionData[mission];
			_missionName.text = data.Name;
			_missionContext.text = data.MissionContext;
			_playerUnits.text = string.Join("\n", data.PlayerUnits.Select(x => x.birdName));
			_enemyUnits.text = string.Join("\n", data.EnemyUnits.Select(x => x.birdName));
		}

		public void EndMission()
		{
			OnEndMission?.Invoke();
		}
	}
}
using System;
using MissionSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
	public class ViewMissionDetails : MonoBehaviour
	{
		[SerializeField] private TMP_Text _name;
		[SerializeField] private TMP_Text _description;
		
		public event Action OnStartButtonClicked;

		public void Initialize(ViewMission mission)
		{
			_name.text = mission.Name;
			_description.text = mission.Annotation;
		}
		
		public void StartMission()
		{
			OnStartButtonClicked?.Invoke();
		}
	}
}
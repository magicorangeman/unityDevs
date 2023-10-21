using System;
using TMPro;
using UI;
using UnityEngine;

namespace MissionSystem
{
	public class ViewMission : MonoBehaviour
	{
		[NonSerialized] public Transform parent;
		[SerializeField] private TMP_Text _numberText;
		[SerializeField] private GameObject _missionDetailsPrefab;

		public event Action<ViewMission> ViewButtonClicked;
		
		public event Action<ViewMission> StartButtonClicked;

		private int Number { get; set; }
		public string Name { get; private set; }
		public string Annotation {get; private set;}

		private GameObject _details;

		public void Initialize(MissionData missionData)
		{
			Number = missionData.Number;
			Name = missionData.Name;
			Annotation = missionData.Annotation;
			_numberText.text = Number.ToString();
		}

		public void ClickButton()
		{
			ViewButtonClicked?.Invoke(this);
		}

		public void ViewMissionDetails()
		{
			_details = Instantiate(_missionDetailsPrefab, _missionDetailsPrefab.transform.position, Quaternion.identity, parent);
			
			var missionDetails = _details.GetComponent<ViewMissionDetails>();
			missionDetails.Initialize(this);
			
			missionDetails.OnStartButtonClicked += InvokeWhenStart;
		}

		public void HideMissionDetails()
		{
			Destroy(_details);
			_details = null;
		}

		private void InvokeWhenStart() => StartButtonClicked?.Invoke(this);
	}
}

using System;
using TMPro;
using UI;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace MissionSystem
{
	public class ViewMission : MonoBehaviour
	{
		[SerializeField] private TMP_Text _numberText;
		[SerializeField] private Button _button;
		[SerializeField] private GameObject _missionDetailsPrefab;

		public Mission Mission { get; private set; }
		public ViewMissionDetails Details { get; private set; }
		
		public event Action<ViewMission> ViewButtonClicked;

		private GameObject _detailsObject;
		
		public void View(Mission mission)
		{
			Mission = mission;
			_numberText.text = mission.Number;
			SetStatusButton(mission.Status);
		}

		public void ClickButton()
		{
			ViewButtonClicked?.Invoke(this);
		}

		public void ViewDetails()
		{
			_detailsObject = Instantiate(_missionDetailsPrefab, _missionDetailsPrefab.transform.position, default, transform);
			Details = _detailsObject.GetComponent<ViewMissionDetails>();
			Details.Initialize(Mission);
		}

		public void HideDetails()
		{
			Destroy(_detailsObject);
			_detailsObject = null;
		}

		private void SetStatusButton(MissionState state)
		{
			switch (state)
			{
				case MissionState.BLOCKED:
					_button.image.color = Color.red;
					break;
				case MissionState.ACTIVE:
					_button.image.color = Color.green;
					break;
				case MissionState.COMPLETE:
					_button.enabled = false;
					break;
				case MissionState.HIDDEN:
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(state), state, null);
			}
		}
	}
}

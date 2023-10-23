using System;
using System.Collections.Generic;
using Gameplay;
using MissionSystem;
using Units;
using UnityEngine;

namespace UI
{
	public class UIController : MonoBehaviour
	{
		[SerializeField] private UIMap _uiMap;
		[SerializeField] private UIPlayerPanel _panel;

		private BirdCard _selectedCard;
		private ViewMission _selectedMission;

		public void Initialize(PlayerProgress progress)
		{
			_uiMap.GenerateMap(progress.AvailableMissions);
			_panel.ViewAvailableUnits(progress.AvailableUnits);
			_uiMap.OnSelectMission += SelectMission;
			_panel.OnCardSelect += SelectCard;
		}

		private void SelectMission(ViewMission mission) => _selectedMission = mission;
		private void SelectCard(BirdCard card) => _selectedCard = card;

		private void StartMission(ViewMission mission)
		{
			
		}
	}
}
using System;
using UI;
using UnityEngine;

namespace Gameplay
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private Installer _installer;
		[SerializeField] private UIController _ui;
		[SerializeField] private PlayerProgress _progress;
		
		private void Awake()
		{
			StartGame();
		}

		private void StartGame()
		{
			_installer.Initialize();
			_progress.Initialize();
			_progress.OnMissionComplete += UpdateView;
			_ui.Initialize(_progress);
		}

		private void UpdateView()
		{
			_ui.Initialize(_progress);
		}

		private void OnDestroy()
		{
			_progress.OnMissionComplete -= UpdateView;
		}
	}
}
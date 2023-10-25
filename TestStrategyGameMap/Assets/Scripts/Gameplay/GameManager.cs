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
			_ui.Initialize(_progress);
			_progress.OnMissionComplete += UpdateView;
		}

		private void UpdateView()
		{
			_ui.Initialize(_progress);
		}
	}
}
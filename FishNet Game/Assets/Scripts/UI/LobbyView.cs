using FishNet;
using Multiplayer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public sealed class LobbyView : View
	{
		[SerializeField] private Button toggleReadyButton;
		[SerializeField] private TextMeshProUGUI toggleReadyButtonText;
		[SerializeField] private Button startGameButton;

		public override void Initialize()
		{
			toggleReadyButton.onClick.AddListener(() => Player.Instance.ServerSetIsReady(!Player.Instance.isReady));

			if (InstanceFinder.IsHost)
			{
				startGameButton.onClick.AddListener(() => GameStarter.Instance.StartGame());

				startGameButton.gameObject.SetActive(true);
			}
			else
			{
				startGameButton.gameObject.SetActive(false);
			}

			Initialized = true;
		}

		private void Update()
		{
			if (!Initialized)
			{
				return;
			}

			toggleReadyButtonText.color = Player.Instance.isReady ? Color.green : Color.red;

			startGameButton.interactable = GameStarter.Instance.canStart;
		}
	}
}

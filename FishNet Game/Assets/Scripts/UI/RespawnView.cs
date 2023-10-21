using Multiplayer;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public sealed class RespawnView : View
	{
		[SerializeField] private Button respawnButton;

		public override void Initialize()
		{
			respawnButton.onClick.AddListener(() => Player.Instance.ServerSpawnPawn());
			Initialized = true;
		}
	}
}

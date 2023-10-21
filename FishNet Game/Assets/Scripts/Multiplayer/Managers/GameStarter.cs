using System.Linq;
using FishNet.Object;
using FishNet.Object.Synchronizing;

namespace Multiplayer
{
	public sealed class GameStarter : NetworkBehaviour
	{
		public static GameStarter Instance { get; private set; }

		[SyncObject] public readonly SyncList<Player> players = new();
		[SyncVar] public bool canStart;

		private void Awake()
		{
			Instance = this;
		}

		private void Update()
		{
			if (!IsServer)
			{
				return;
			}

			canStart = players.All(player => player.isReady);
		}

		[Server]
		public void StartGame()
		{
			if (!canStart)
			{
				return;
			}

			for (int i = 0; i < players.Count; i++)
			{
				players[i].StartGame();
			}
		}

		[Server]
		public void StopGame()
		{
			for (int i = 0; i < players.Count; i++)
			{
				players[i].StopGame();
			}
		}
	}
}

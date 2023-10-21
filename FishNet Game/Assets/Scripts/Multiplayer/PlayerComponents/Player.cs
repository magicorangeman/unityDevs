using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Multiplayer
{
	public sealed class Player : NetworkBehaviour
	{
		public static Player Instance { get; private set; }

		[SyncVar] public bool isReady;
		[SyncVar] public Body _controlledBody;

		public override void OnStartServer()
		{
			base.OnStartServer();
			GameStarter.Instance.players.Add(this);
		}

		public override void OnStopServer()
		{
			base.OnStopServer();
			GameStarter.Instance.players.Remove(this);
		}

		public override void OnStartClient()
		{
			base.OnStartClient();

			if (!IsOwner)
			{
				return;
			}
		
			Instance = this;
			UIManager.Instance.Initialize();
			UIManager.Instance.Show<LobbyView>();
		}

		private void Update()
		{
			if (!IsOwner) return;

			if (Input.GetKeyDown(KeyCode.R))
			{
				ServerSetIsReady(!isReady);
			}
		}

		public void StartGame()
		{
			var pawnPrefab = Addressables.LoadAssetAsync<GameObject>("Pawn").WaitForCompletion();
			var pawnInstance = Instantiate(pawnPrefab);
			Spawn(pawnInstance, Owner);
			_controlledBody = pawnInstance.GetComponent<Body>();
			_controlledBody.controllingPlayer = this;
			TargetPawnSpawned(Owner);
		}

		[ServerRpc(RequireOwnership = false)]
		public void ServerSpawnPawn() => StartGame();

		public void StopGame()
		{
			if (_controlledBody != null && _controlledBody.IsSpawned)
			{
				_controlledBody.Despawn();
			}
		}

		[ServerRpc(RequireOwnership = false)]
		public void ServerSetIsReady(bool value)
		{
			isReady = value;
		}

		[TargetRpc]
		private void TargetPawnSpawned(NetworkConnection networkConnection)
		{
			UIManager.Instance.Show<MainView>();
		}

		[TargetRpc]
		public void TargetPawnKilled(NetworkConnection networkConnection)
		{
			UIManager.Instance.Show<RespawnView>();
		}
	}
}

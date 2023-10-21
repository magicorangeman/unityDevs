using FishNet.Object;
using FishNet.Object.Synchronizing;

namespace Multiplayer
{
	public sealed class Body : NetworkBehaviour
	{
		[SyncVar] public Player controllingPlayer;
		[SyncVar] public float health;

		public void ReceiveDamage(float amount)
		{
			if (!IsSpawned)
			{
				return;
			}

			if ((health -= amount) <= 0.0f)
			{
				controllingPlayer.TargetPawnKilled(Owner);
				Despawn();
			}
		}
	}
}

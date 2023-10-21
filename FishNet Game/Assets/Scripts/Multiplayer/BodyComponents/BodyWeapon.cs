using Control;
using FishNet.Object;
using UnityEngine;

namespace Multiplayer
{
	public sealed class BodyWeapon : NetworkBehaviour
	{
		[SerializeField] private PlayerInput _playerInput;
		[SerializeField] private Transform _firePoint;
		[SerializeField] private float _damage;
		[SerializeField] private float _shotDelay;
	
		private float _timeUntilNextShot;

		private void Update()
		{
			if (!IsOwner)
			{
				return;
			}

			if (_timeUntilNextShot <= 0.0f)
			{
				if (!_playerInput.Fire)
				{
					return;
				}

				ServerFire(_firePoint.position, _firePoint.forward);
				_timeUntilNextShot = _shotDelay;
			}
			else
			{
				_timeUntilNextShot -= Time.deltaTime;
			}
		}

		[ServerRpc]
		private void ServerFire(Vector3 firePointPosition, Vector3 firePointDirection)
		{
			if (Physics.Raycast(firePointPosition, firePointDirection, out var hit) 
			    && hit.transform.TryGetComponent(out Body pawn))
			{
				pawn.ReceiveDamage(_damage);
			}
		}
	}
}

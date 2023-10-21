using Control;
using FishNet.Object;
using UnityEngine;

namespace Multiplayer
{
	public sealed class BodyController : NetworkBehaviour
	{
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField] private PlayerMovement _playerMovement;
		[SerializeField] private PlayerCameraLook _look;
		[SerializeField] private Transform _myCamera;

		public override void OnStartClient()
		{
			base.OnStartClient();
			_myCamera.GetComponent<Camera>().enabled = IsOwner;
			_myCamera.GetComponent<AudioListener>().enabled = IsOwner;
		}
		private void Update()
		{
			if (!IsOwner)
			{
				return;
			}
		
			_rigidbody.velocity = new Vector3(
				x:_playerMovement.moveVelocity.x,
				y:_rigidbody.velocity.y,
				z:_playerMovement.moveVelocity.z);
		
			_rigidbody.AddForce(_playerMovement.jumpVelocity, ForceMode.Impulse);
			_look.MoveCamera();
		}
	}
}

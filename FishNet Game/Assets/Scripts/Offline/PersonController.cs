using Control;
using UnityEngine;

public sealed class PersonController : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private PlayerMovement _playerMovement;
	[SerializeField] private PlayerCameraLook _look;

	private void Update()
	{
		_rigidbody.velocity = new Vector3(
			x:_playerMovement.moveVelocity.x,
			y:_rigidbody.velocity.y,
			z:_playerMovement.moveVelocity.z);
		
		_rigidbody.AddForce(_playerMovement.jumpVelocity, ForceMode.Impulse);
		_look.MoveCamera();
	}
}

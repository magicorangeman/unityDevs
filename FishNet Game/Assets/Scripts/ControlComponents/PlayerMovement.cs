using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Control
{
	public sealed class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private PlayerInput _input;
		[SerializeField] private float _speed;
		[SerializeField] private float _jumpSpeed;
		[SerializeField] private float _gravityScale;

		public bool IsGrounded { get; private set; }
		public bool IsShoot => _input.Fire;
		public Vector3 moveVelocity => Move();
		public Vector3 jumpVelocity => Jump();

		private void OnCollisionEnter() => IsGrounded = true;

		private Vector3 Move()
		{
			var verticalVelocity = transform.forward * _input.Vertical * _speed;
			var horizontalVelocity = transform.right * _input.Horizontal * _speed;
			var desiredVelocity = Vector3.ClampMagnitude(verticalVelocity + horizontalVelocity, _speed);

			return desiredVelocity;
		}

		private Vector3 Jump()
		{
			if (!_input.Jump)
			{
				return Physics.gravity * _gravityScale;
			}

			IsGrounded = false;
			return Vector3.up * _jumpSpeed;
		}
	}
}

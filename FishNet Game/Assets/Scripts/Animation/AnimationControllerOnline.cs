using Control;
using FishNet.Component.Animating;
using FishNet.Object;
using UnityEngine;

namespace Animation
{
	public class AnimationControllerOnline : NetworkBehaviour
	{
		[SerializeField] private NetworkAnimator _networkAnimator;
		[SerializeField] private PlayerMovement _playerMovement;

		private string _currentAnimation;
		
		private void Update()
		{
  			if (!IsOwner)
  			{
     				return;
			}

            if (!_playerMovement.IsGrounded)
            {
	            ChangeAnimation("Jump");
            }
            else if (!Mathf.Approximately(_playerMovement.moveVelocity.magnitude, 0))
            {
	            ChangeAnimation("Run");
            }
            else if (_playerMovement.IsShoot)
            {
	            ChangeAnimation("Shot");
            }
            else
            {
	            ChangeAnimation("Idle");
            }
		}

		private void ChangeAnimation(string animationName)
		{
			if (_currentAnimation == animationName) return;
		
			_networkAnimator.Play(animationName);
			_currentAnimation = animationName;
		}
	}
}

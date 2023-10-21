using Control;
using UnityEngine;

namespace Animation
{
	public class AnimationController : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private PlayerMovement _playerMovement;
		[SerializeField] private ParticleCreator _particle;

		public string CurrentAnimation { get; private set; }
		
		private void Update()
		{
			_animator.SetBool("Run",false);
			_animator.SetBool("Idle", false);
			
			if (!_playerMovement.IsGrounded)
			{
				_animator.SetTrigger("Jump");
			}
			else if (!Mathf.Approximately(_playerMovement.moveVelocity.magnitude, 0))
			{
				_animator.SetBool("Run",true);
			}
			else if (_playerMovement.IsShoot)
			{
				_animator.SetTrigger("Shot");
				_particle.CreateParticle();
				
			}
			else
			{
				_animator.SetBool("Idle", true);
			}
		}
	}
}

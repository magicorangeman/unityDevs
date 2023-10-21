using UnityEngine;

namespace Control
{
	public sealed class PlayerInput : MonoBehaviour
	{

		public float Horizontal { get; private set; }
		public float Vertical { get; private set; }
		public bool Jump { get; private set; }
		public bool Fire { get; private set; }
	
		private void Update()
		{
			Horizontal = Input.GetAxis("Horizontal");
			Vertical = Input.GetAxis("Vertical");
			Jump = Input.GetButton("Jump");
			Fire = Input.GetButtonDown("Fire1");
		}
	}
}

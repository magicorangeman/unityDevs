using UnityEngine;

namespace Control
{
	public sealed class PlayerCameraLook : MonoBehaviour
	{
		[SerializeField] private Transform _myCamera;
		[SerializeField] public float _sensitivity;
		[SerializeField] private float _xMin;
		[SerializeField] private float _xMax;
	
		private float _mouseX;
		private float _mouseY;
	
		private Vector3 _eulerAngles;

		private void Update()
		{
			_mouseX = Input.GetAxis("Mouse X") * _sensitivity;
			_mouseY = Input.GetAxis("Mouse Y") * _sensitivity;
		}

		public void MoveCamera()
		{
			_eulerAngles.x -= _mouseY;
			_eulerAngles.x = Mathf.Clamp(_eulerAngles.x, _xMin, _xMax);
			_myCamera.localEulerAngles = _eulerAngles;
			transform.Rotate(0.0f, _mouseX, 0.0f, Space.World);
		}
	}
}

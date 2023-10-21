using Animation;
using FishNet.Object;
using UnityEngine;

public class PistolSpawner : MonoBehaviour
{
	[SerializeField] private AnimationController _controller;
	[SerializeField] private GameObject _prefab;
	[SerializeField] private Vector3 _position;
	[SerializeField] private Transform _parent;

	private bool _isSpawned;
	private GameObject _spawnedPistol;
	
	private void Update()
	{
		if (_controller.CurrentAnimation != "Shot")
		{
			if (_isSpawned)
			{
				Destroy(_spawnedPistol);
				_isSpawned = false;
			}
			return;
		}

		if (!_isSpawned)
		{
			SpawnPistol(_position);
		}
	}

	private void SpawnPistol(Vector3 position)
	{
		_spawnedPistol = Instantiate(_prefab, position, Quaternion.identity, _parent);
		_isSpawned = true;
	}
}

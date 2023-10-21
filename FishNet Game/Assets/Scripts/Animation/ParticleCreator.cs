using UnityEngine;

public class ParticleCreator : MonoBehaviour
{
	[SerializeField] private ParticleSystem _particle;
	[SerializeField] private Transform _parent;
	

	public void CreateParticle()
	{
		var position = _parent.transform.position;
		Instantiate(_particle, _parent.transform.position, _parent.rotation, _parent);
	}
}

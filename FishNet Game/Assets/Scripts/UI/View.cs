using UnityEngine;

namespace UI
{
	public abstract class View : MonoBehaviour
	{
		protected bool Initialized { get; protected private set; }

		public virtual void Initialize()
		{
			Initialized = true;
		}
	}
}

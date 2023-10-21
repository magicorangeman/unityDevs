using Multiplayer;
using TMPro;
using UnityEngine;

namespace UI
{
	public sealed class MainView : View
	{
		[SerializeField] private TextMeshProUGUI _healthText;
		[SerializeField] private string _title;

		private void Update()
		{
			if (!Initialized)
			{
				return;
			}

			var player = Player.Instance;
		
			if (player == null || player._controlledBody == null) return;
			_healthText.text = _title +" " + player._controlledBody.health;
		}
	}
}

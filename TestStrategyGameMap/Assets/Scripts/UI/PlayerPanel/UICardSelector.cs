using Units;
using UnityEngine;

namespace UI
{
	public class UICardSelector : MonoBehaviour
	{
		[SerializeField] private UIPlayerPanel _panel;
		
		public BirdCard SelectedCard { get; private set; }
		
		private bool _isBirdCardSelected;
		

		private void Awake()
		{
			_panel.OnCardSelect += SelectBirdCard;
		}

		private void SelectBirdCard(BirdCard card)
		{
			if (SelectedCard == card)
			{
				SelectedCard.Hide();
				_isBirdCardSelected = false;
				SelectedCard = null;
				return;
			}

			if (_isBirdCardSelected)
			{
				SelectedCard.Hide();
			}
			
			card.Show();
			SelectedCard = card;
			_isBirdCardSelected = true;
		}
	}
}
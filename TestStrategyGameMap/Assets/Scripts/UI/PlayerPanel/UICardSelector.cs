using System;
using Units;
using UnityEngine;

namespace UI
{
	public class UICardSelector : MonoBehaviour
	{
		[SerializeField] private UIPlayerPanel _panel;
		
		public BirdCard SelectedCard { get; private set; }

		private void Awake()
		{
			_panel.OnCardSelect += SelectBirdCard;
		}

		private void SelectBirdCard(BirdCard card)
		{
			if (SelectedCard == card)
			{
				SelectedCard.Hide();
				SelectedCard = null;
				return;
			}

			if (SelectedCard != null)
			{
				SelectedCard.Hide();
			}
			
			card.Show();
			SelectedCard = card;
		}

		private void OnDestroy()
		{
			_panel.OnCardSelect -= SelectBirdCard;
		}
	}
}
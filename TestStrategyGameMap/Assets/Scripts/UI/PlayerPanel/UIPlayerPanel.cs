using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace UI
{
	public class UIPlayerPanel : MonoBehaviour
	{
		[SerializeField] private GameObject _birdCardPrefab;
		
		private List<BirdCard> _birdCards = new();
		
		public event Action<BirdCard> OnCardSelect;

		public void ViewAvailableUnits(List<Bird> birds)
		{
			UnsubscribeAllCards();
			
			for (var i = 0; i < birds.Count; i++)
			{
				var position = GetPanelPosition(i, birds.Count);
				var birdCardObject = Instantiate(_birdCardPrefab, position, Quaternion.identity, transform);
				var birdCard = birdCardObject.GetComponent<BirdCard>();
				_birdCards.Add(birdCard);
				birdCard.Initialize(birds[i]);
				birdCard.CardSelected += InvokeWhenSelectCard;
			}
		}

		private Vector2 GetPanelPosition(int number, int amount)
		{
			var horizontal = 21 * (- amount / 2 + number) + _birdCardPrefab.transform.position.x;
			var vertical = _birdCardPrefab.transform.position.y;

			return new Vector2(horizontal, vertical);
		}

		private void InvokeWhenSelectCard(BirdCard card)
		{
			OnCardSelect?.Invoke(card);
		}

		private void UnsubscribeAllCards()
		{
			foreach (var birdCard in _birdCards)
			{
				birdCard.CardSelected -= InvokeWhenSelectCard;
				birdCard.Hide();
			}
		}
	}
}
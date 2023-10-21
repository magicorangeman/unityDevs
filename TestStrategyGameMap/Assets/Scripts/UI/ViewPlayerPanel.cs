using Units;
using UnityEngine;

namespace UI
{
	public class ViewPlayerPanel : MonoBehaviour
	{
		[SerializeField] private GameProgress _progress;
		[SerializeField] private GameObject _birdCardPrefab;

		private void Awake()
		{
			_progress.Initialize();
			ViewAvailableUnits();
		}

		private void ViewAvailableUnits()
		{
			var unitsCount = _progress.AvailableUnits.Count;
			for (var i = 0; i < unitsCount; i++)
			{
				var position = GetPanelPosition(i, unitsCount);
				var birdCard = Instantiate(_birdCardPrefab, position, Quaternion.identity, transform);
				var bird = _progress.AvailableUnits[i];
				birdCard.GetComponent<BirdCard>().Initialize(bird);
			}
		}

		private Vector2 GetPanelPosition(int number, int amount)
		{
			var horizontal = 21 * (- amount / 2 + number) + _birdCardPrefab.transform.position.x;
			var vertical = _birdCardPrefab.transform.position.y;

			return new Vector2(horizontal, vertical);
		}
	}
}
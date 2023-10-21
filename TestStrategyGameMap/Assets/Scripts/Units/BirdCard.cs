using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Units
{
	public class BirdCard : MonoBehaviour
	{
		[SerializeField] private TMP_Text _nameText;
		[SerializeField] private RawImage _icon;
		[SerializeField] private TMP_Text _pointsText;

		public void Initialize(BirdCardData data)
		{
			_nameText.text = data.birdName;
			_icon.texture = data.iconTexture;
			_pointsText.text = data.points.ToString();
		}
	}
}
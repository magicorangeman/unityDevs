using System;
using Gameplay;
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

		public event Action<BirdCard> CardSelected;
		
		public void Initialize(Bird bird)
		{
			var data = Installer.BirdData[bird];
			_nameText.text = data.birdName;
			_icon.texture = data.iconTexture;
			_pointsText.text = data.points.ToString();
		}

		public void ClickButton()
		{
			CardSelected?.Invoke(this);
		}

		public void Show()
		{
			_nameText.color = Color.red;
		}

		public void Hide()
		{
			_nameText.color = Color.black;
		}
	}
}
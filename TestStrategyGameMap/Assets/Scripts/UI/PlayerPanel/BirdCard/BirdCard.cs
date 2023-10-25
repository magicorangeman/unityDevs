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
		
		public Bird Bird { get; private set; }
		
		public event Action<BirdCard> CardSelected;
		
		public void Initialize(Bird bird)
		{
			Bird = bird;
			_nameText.text = bird.Name;
			_icon.texture = Installer.BirdData[bird].iconTexture;
			_pointsText.text = bird.Points.ToString();
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
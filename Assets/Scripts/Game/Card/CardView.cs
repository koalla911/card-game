using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class CardView : MonoBehaviour
	{
		[SerializeField] private Image background = default;
		[SerializeField] private Image icon = default;
		[SerializeField] private TextMeshProUGUI description = default;
		[SerializeField] private TextMeshProUGUI number = default;
		[SerializeField] private Button cardButton = default;

		private CardConfigData card = default;

		//public event Action OnCardSelected;

		public void Init(CardConfigData card, PackTypeInfo packType)
		{
			this.card = card;
			number.SetText(card.name.ToString());
			background.sprite = packType.PackIcon;
			description.SetText(card.Description);
			if (card.CardIcon != null)
			{
				icon.sprite = card.CardIcon;
			}
		}

		private void OnEnable()
		{
			cardButton.onClick.AddListener(SetActiveCard);
		}

		public void SetActiveCard()
		{
			GameController.Instance.PackProvider.TryAddSelectedCard(this.card);
			//OnCardSelected?.Invoke();
		}

		private void OnDisable()
		{
			cardButton.onClick.RemoveListener(SetActiveCard);
		}
	}
}

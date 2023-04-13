using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class CardView : MonoBehaviour
	{
		[SerializeField] private Image background = default;
		[SerializeField] private TextMeshProUGUI description = default;
		[SerializeField] private TextMeshProUGUI number = default;

		public void Init(CardData card)
		{
			background.sprite = card.CardImage;
			description.SetText(card.Description);
		}
	}
}

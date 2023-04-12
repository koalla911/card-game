using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
	public class RitualWindow : ScreenState
	{
		protected static CardProvider cardProvider = default;

		[SerializeField] private Button closeBtn = default;
		[SerializeField] private CardView cardView = default;
		[SerializeField] private GridLayoutGroup gridLayout = default;

		private void Start()
		{
			//closeBtn.onClick.AddListener(OnClickCloseBtn);
		}

		public override void Open()
		{
			base.Open();
			Debug.Log("Open window");
			foreach (Transform child in gridLayout.transform)
			{
				Destroy(child.gameObject);
			}

			var cards = cardProvider.CardConfig.Cards;
			foreach (var card in cards)
			{
				var preview = Instantiate(cardView, gridLayout.transform);
				preview.Init(card);
			}
		}

		public override void Close()
		{
			base.Close();
		}

		protected override void OnClickBackButton() => OnClickCloseBtn();

		private void OnClickCloseBtn()
		{
			uiService.Close<RitualWindow>();
		}
	}
}

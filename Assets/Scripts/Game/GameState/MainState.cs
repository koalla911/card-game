using Game.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
	public class MainState : GameState
	{
		[SerializeField] private Button ritualsButton = default;
		[SerializeField] private ResourcesWidget resourcesWidget = default;
		[SerializeField] private Button removeRitualsButton = default;
		[SerializeField] private TextMeshProUGUI selectedCardsLabel = default;

		private PoolMono<PackButtonView> packPool = default;
		private List<PackButtonView> packViews = new();
		private Level level = default;
		private StringBuilder cardsString = new();

		protected override void OnEnable()
		{
			base.OnEnable();
			//resourcesWidget.Init(GameController.Instance.ResourcesData);

			//GameController.Instance.ResetProgress();

			packPool = GameController.Instance.packBtnPool;
			GeneratePackButtons();
			ritualsButton.onClick.AddListener(OpenRituals);
			removeRitualsButton.onClick.AddListener(RemoveRituals);

			GameController.Instance.PackProvider.OnCardSelected += ShowSelectedCards;
			ShowSelectedCards();
		}

		protected override void OnDisable()
		{
			ritualsButton.onClick.RemoveListener(OpenRituals);
			removeRitualsButton.onClick.AddListener(RemoveRituals);
			DisablePool();
			GameController.Instance.PackProvider.OnCardSelected -= ShowSelectedCards;

			base.OnDisable();
		}

		private void GeneratePackButtons()
		{
			level = GameController.Instance.Level;
			for (int i = 0; i < level.packs.Count; i++)
			{
				PackButtonView packView = packPool.GetActive();
				packViews.Add(packView);
				packView.Init(level.packs[i]);
			}
		}

		private void ShowSelectedCards()
		{
			selectedCardsLabel.gameObject.SetActive(GameController.Instance.PackProvider.SelectedCards.Count > 0);
			if(GameController.Instance.PackProvider.SelectedCards.Count > 0)
			{
				foreach(var card in GameController.Instance.PackProvider.SelectedCards)
				{
					cardsString.Append(card.name + ", ");
				}
				selectedCardsLabel.SetText("Selected cards: "+ cardsString +"in progress...");
			}
		}

		private void OpenRituals()
		{
			if (GameController.Instance.PackProvider.AvailablePacks != null)
			{
				Switch<RitualState>();
			}
		}

		private void RemoveRituals()
		{
			if (GameController.Instance.PackProvider.AvailablePacks.Count > 0)
			{
				GameController.Instance.PackProvider.AvailablePacks.Clear();
				for (int i = 0; i < level.packs.Count; i++)
				{
					packViews[i].Init(level.packs[i]);
				}
			}
		}

		//TODO: ObjectPool needs to be able to enable existed objects and remove extra
		private void DisablePool()
		{
			foreach (var item in packPool.Pool)
			{
				item.gameObject.SetActive(false);
			}
		}
	}
}

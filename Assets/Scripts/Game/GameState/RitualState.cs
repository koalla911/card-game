using DG.Tweening;
using Game.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
	public class RitualState : GameState
	{
		[SerializeField] private Button exitButton = default;
		[SerializeField] private ResourcesWidget resourcesWidget = default;
		[SerializeField] private TextMeshProUGUI cardCountLabel = default;

		private PoolMono<CardView> cardPool = default;
		private int packIndex = default;
		private int cardCount = default;

		protected override void OnEnable()
		{
			base.OnEnable();
			//resourcesWidget.Init(GameController.Instance.ResourcesData);

			cardPool = GameController.Instance.cardPool;

			packIndex = 0;
			cardCount = 0;
			GameController.Instance.OnCardSelected += GetCardsByPack;
			GetCardsByPack();

			exitButton.onClick.AddListener(OnQuit);
		}

		protected override void OnDisable()
		{
			exitButton.onClick.RemoveListener(OnQuit);
			GameController.Instance.OnCardSelected -= GetCardsByPack;

			base.OnDisable();
		}

		public void GetCardsByPack()
		{
			if (GameController.Instance.AvailablePacks.Count > 0)
			{
				if (packIndex >= GameController.Instance.AvailablePacks.Count)
				{
					OnQuit();
				}
				else
				{
					DisablePool();
					GenerateCards(GameController.Instance.AvailablePacks[packIndex]);
					cardCount++;
					packIndex++;
				}
			}

			cardCountLabel.SetText("Select your {0} card!", cardCount);
		}

		private void GenerateCards(PackTypeInfo pack)
		{
			Level level = GameController.Instance.Level;
			var availableCards = GameController.Instance.AvailableCards;

			if (level != null)
			{
				int j = 0;
				while (j < GameController.Instance.ResearchesConfig.PackSlots)
				{
					System.Random randomNumber = new();
					int rn = randomNumber.Next(0, availableCards.Count);
					float k = K();

					if (availableCards[rn].P >= k)
					{
						CardView cardView = cardPool.GetActive();
						cardView.Init(availableCards[rn], pack);

						/*Debug.Log("Name: " + availableCards[rn].name + " "
							+ "Weight: " + availableCards[rn].Weight + " "
							+ "P: " + availableCards[rn].P.ToString("F2") + " "
							+ "K: " + k.ToString("F2"));*/

						j++;
					}
					else
					{
						/*Debug.Log("unsuitable: " + availableCards[rn].name + " "
							+ "Weight: " + availableCards[rn].Weight + " "
							+ "P: " + availableCards[rn].P.ToString("F2") + " "
							+ "K: " + k.ToString("F2"));*/
					}
				}
			}
		}

		private float K()
		{
			System.Random random = new();
			var k = (float)random.NextDouble();
			k = (float)Math.Round(k, 2);
			return k;
		}

		private void OnQuit()
		{
			DisablePool();
			GameState.Switch<MainState>();
		}

		//TODO: ObjectPool needs to be able to enable existed objects and remove extra
		private void DisablePool()
		{
			foreach (var item in cardPool.Pool)
			{
				item.gameObject.SetActive(false);
			}
		}
	}
}

using Game.UI;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
	public class RitualState : GameState
	{
		[SerializeField] private Button exitButton = default;
		[SerializeField] private ResourcesWidget resourcesWidget = default;

		private PoolMono<CardView> cardPool = default;
		public UnityEvent OnClickExitButton => exitButton.onClick;

		protected override void OnEnable()
		{
			base.OnEnable();
			//resourcesWidget.Init(GameController.Instance.ResourcesData);

			cardPool = GameController.Instance.cardPool;
			GenerateCards();

			OnClickExitButton.AddListener(OnQuit);
		}

		protected override void OnDisable()
		{
			OnClickExitButton.RemoveListener(OnQuit);
			base.OnDisable();
		}

		private void GenerateCards()
		{
			Level level = GameController.Instance.Level;
			if (GameController.Instance.currentPack != null)
			{
				var allCards = level.GetCardInfoByType(GameController.Instance.currentPack.CardType);
				Debug.Log(allCards);
			}

			if (level != null)
			{
				int j = 0;
				while (j < GameController.Instance.ResearchesConfig.PackSlots)
				{
					System.Random randomNumber = new();
					int rn = randomNumber.Next(0, level.cards.Count);
					float k = K();

					if (level.cards[rn].P >= k)
					{
						CardView cardView = cardPool.GetActive();

						cardView.Init(level.cards[rn]);

						/*Debug.Log("Number: " + level.cards[rn].Number + " "
							+ "Weight: " + level.cards[rn].Weight + " "
							+ "P: " + level.cards[rn].P.ToString("F2") + " "
							+ "K: " + k.ToString("F2"));*/

						j++;
					}
					/*else
					{
						Debug.Log("unsuitable Number: " + level.cards[rn].Number + " "
							+ "Weight: " + level.cards[rn].Weight + " "
							+ "P: " + level.cards[rn].P.ToString("F2") + " "
							+ "K: " + k.ToString("F2"));
					}*/
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

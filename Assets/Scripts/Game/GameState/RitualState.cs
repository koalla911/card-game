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
		[SerializeField] private ResourcesView resourcesWidget = default;
		[SerializeField] private LayoutGroup cardParent = default;

		private ObjectPool<CardView> cardPool = default;
		public UnityEvent OnClickExitButton => exitButton.onClick;

		protected override void OnEnable()
		{
			base.OnEnable();
			resourcesWidget.Init(GameController.Instance.ResourcesData);

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

			for (int i = 0; i < GameController.Instance.ResearchesConfig.PackSlots; i++)
			{
				CardView cardView = cardPool.GetFreeElement();

				Debug.Log(level.cards[i].Weight);
				cardView.Init(level.cards[i]);
			}
		}

		private float GenerateProbability()
		{
			System.Random random = new();
			var k = (float)random.NextDouble();
			k = (float)Math.Round(k, 2);
			return k;
		}

		private void OnQuit()
		{
			ClearLayout(cardParent);
			GameState.Switch<MainState>();
		}

		//TODO: ObjectPool needs to be able to enable existed objects and remove extra
		private void ClearLayout(LayoutGroup layout)
		{
			if (layout.transform.childCount > 0)
			{
				for (int i = 0; i < layout.transform.childCount; i++)
				{
					Destroy(layout.transform.GetChild(i).gameObject);
				}
			}
		}
	}
}

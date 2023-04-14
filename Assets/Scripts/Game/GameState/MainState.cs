using Game.UI;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
	public class MainState : GameState
	{
		[SerializeField] private Button ritualsButton = default;
		[SerializeField] private RitualView ritualPrefab = default;
		[SerializeField] private ResourcesWidget resourcesWidget = default;
		public UnityEvent OnClickRitualButton => ritualsButton.onClick;

		private ObjectPool<RitualView> ritualPool = default;

		private void Awake()
		{
			//ritualPool = new ObjectPool<CardView>(ritualPrefab, , cardParent.gameObject);

		}

		protected override void OnEnable()
		{
			base.OnEnable();
			resourcesWidget.Init(GameController.Instance.ResourcesData);

			OnClickRitualButton.AddListener(OpenRituals);
		}

		protected override void OnDisable()
		{
			OnClickRitualButton.RemoveListener(OpenRituals);
			base.OnDisable();
		}

		private void GenerateRitualButtons()
		{
			/*for (int i = 0; i < GameController.Instance.ConfigHolder.Researches.MinPackSize; i++)
			{
				CardView cardView = ritualPool.GetFreeElement();
				cardView.Init(GameController.Instance.ConfigHolder.Cards[i]);
			}*/
		}

		private void OpenRituals()
		{
			Switch<RitualState>();
		}
	}
}

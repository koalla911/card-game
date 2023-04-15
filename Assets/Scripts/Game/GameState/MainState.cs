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
		[SerializeField] private ResourcesWidget resourcesWidget = default;

		public UnityEvent OnClickRitualButton => ritualsButton.onClick;
		private PoolMono<PackButtonView> packPool = default;

		protected override void OnEnable()
		{
			base.OnEnable();
			//resourcesWidget.Init(GameController.Instance.ResourcesData);

			packPool = GameController.Instance.packBtnPool;
			GeneratePackButtons();
			OnClickRitualButton.AddListener(OpenRituals);
		}

		protected override void OnDisable()
		{
			OnClickRitualButton.RemoveListener(OpenRituals);
			DisablePool();
			base.OnDisable();
		}

		private void GeneratePackButtons()
		{
			Level level = GameController.Instance.Level;
			for (int i = 0; i < level.packs.Count; i++)
			{
				PackButtonView packView = packPool.GetActive();
				packView.Init(level.packs[i]);
			}
		}

		private void OpenRituals()
		{
			Switch<RitualState>();
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

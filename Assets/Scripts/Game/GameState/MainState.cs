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
		[SerializeField] private ResourcesView resourcesWidget = default;
		[SerializeField] private LayoutGroup packsBtnParent = default;

		public UnityEvent OnClickRitualButton => ritualsButton.onClick;
		private ObjectPool<PackButtonView> packPool = default;

		protected override void OnEnable()
		{
			base.OnEnable();
			resourcesWidget.Init(GameController.Instance.ResourcesData);

			packPool = GameController.Instance.packBtnPool;
			GeneratePackButtons();
			OnClickRitualButton.AddListener(OpenRituals);
		}

		protected override void OnDisable()
		{
			OnClickRitualButton.RemoveListener(OpenRituals);
			base.OnDisable();
		}

		private void GeneratePackButtons()
		{
			Level level = GameController.Instance.Level;
			for (int i = 0; i < level.packs.Count; i++)
			{
				PackButtonView packView = packPool.GetFreeElement();
				packView.Init(level.packs[i]);
			}
		}

		private void OpenRituals()
		{
			ClearLayout(packsBtnParent);
			Switch<RitualState>();
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

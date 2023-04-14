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

		private void OpenRituals()
		{
			Switch<RitualState>();
		}
	}
}

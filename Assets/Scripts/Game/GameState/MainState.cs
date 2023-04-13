using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
	public class MainState : GameState
	{
		[SerializeField] private Button settingsButton = default;
		[SerializeField] private Button ritualsButton = default;
		public UnityEvent OnClickSettingsButton => settingsButton.onClick;
		public UnityEvent OnClickRitualButton => ritualsButton.onClick;
		//private PoolMono<RacerViewOverview> racerPool;


		protected override void OnEnable()
		{
			base.OnEnable();
			OnClickRitualButton.AddListener(OpenRituals);
		}

		protected override void OnDisable()
		{
			OnClickRitualButton.RemoveListener(OpenRituals);
			base.OnDisable();
		}

		private void OpenSettings()
		{

		}

		private void OpenRituals()
		{
			Switch<RitualState>();
		}
	}
}

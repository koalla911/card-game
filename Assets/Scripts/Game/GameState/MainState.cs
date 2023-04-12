using System;
using UnityEngine;

namespace Game
{
	public class MainState : GameState
	{
		[Inject] private static UiService uiService = default;
		private MainHUDWindow window;

		protected override void OnEnable()
		{
			base.OnEnable();
			Debug.Log("this is Main");

			/*window = uiService.Open<MainHUDWindow>(dropStack: true);
			window.OnClickSettingsButton.AddListener(OpenSettings);
			window.OnClickRitualButton.AddListener(OpenRituals);*/
		}

		protected override void OnDisable()
		{
			/*window.OnClickSettingsButton.RemoveListener(OpenSettings);
			window.OnClickRitualButton.AddListener(OpenRituals);*/

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

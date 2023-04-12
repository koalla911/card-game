using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
	public class MainHUDWindow : ScreenState
	{
		[SerializeField] private Button settingsButton = default;
		[SerializeField] private Button ritualsButton = default;
		public UnityEvent OnClickSettingsButton => settingsButton.onClick;
		public UnityEvent OnClickRitualButton => ritualsButton.onClick;


		protected override void OnClickBackButton() { return; }
	}
}

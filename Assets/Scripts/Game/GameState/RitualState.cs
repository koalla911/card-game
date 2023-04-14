using Game.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
	public class RitualState : GameState
	{
		[SerializeField] private Button exitButton = default;
		[SerializeField] private ResourcesWidget resourcesWidget = default;

		public UnityEvent OnClickExitButton => exitButton.onClick;

		protected override void OnEnable()
		{
			base.OnEnable();
			resourcesWidget.Init(GameController.Instance.ResourcesData);

			OnClickExitButton.AddListener(OnQuit);
		}

		protected override void OnDisable()
		{
			OnClickExitButton.RemoveListener(OnQuit);
			base.OnDisable();
		}

		private void OnQuit()
		{
			GameState.Switch<MainState>();
		}
	}
}

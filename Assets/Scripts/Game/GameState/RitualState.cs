using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
	public class RitualState : GameState
	{
		[SerializeField] private Button exitButton = default;
		public UnityEvent OnClickExitButton => exitButton.onClick;

		protected override void OnEnable()
		{
			base.OnEnable();
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

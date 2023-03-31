using Game.UI;

namespace Game
{
	public class RitualState : GameState
	{
		[Inject] private static UiService uiService = default;
		private RitualWindow ritualWindow;

		protected override void OnEnable()
		{
			base.OnEnable();
			//ritualWindow = uiService.Open<RitualWindow>();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			SwitchToNextState();
		}

		private void SwitchToNextState()
		{
			//Switch<LevelStartState>();
		}
	}
}

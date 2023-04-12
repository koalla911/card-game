using Game.UI;
using UnityEngine;

namespace Game
{
	public class RitualState : GameState
	{
		private RitualWindow window;

		protected override void OnEnable()
		{
			base.OnEnable();
			Debug.Log("this is Ritual");
			//window = uiService.Open<RitualWindow>();
		}

		protected override void OnDisable()
		{
			//uiService.Close<RitualWindow>();
			base.OnDisable();
		}

	}
}

using Cysharp.Threading.Tasks;
using Fancy;
using Game.UI;
using UnityEngine;

namespace Game
{
	public class GameController : MonoSingleton<GameController>
	{
		[Inject] private static UiService uiService;

		protected override void Awake()
		{
			base.Awake();
			//Debug.Log($"Screen {Screen.width}x{Screen.height} {Screen.dpi}dpi");
			//Debug.Log($"Accelerometer: {SystemInfo.supportsAccelerometer} Gyroscope: {SystemInfo.supportsGyroscope}");
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 30;
		}

		private void Start()
		{
			GameState.Init<RitualState>();
		}

		public void RestartGameplay()
		{
			//GameState.Switch<RestartGameplayState>();
		}
		
		public void GoToLobby()
		{
			//GameState.Switch<LobbyState>();
		}

	}
}

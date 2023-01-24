//using Game.UI;
using UnityEngine;

namespace Game
{
	public class Lobby : MonoBehaviour
	{
		[Inject] private static UiService uiService;
		//[Inject] private static SceneDataProvider sceneDataProvider;

		[SerializeField] private Camera lobbyCamera = default;
		public Camera LobbyCamera => lobbyCamera;

		private void Awake()
		{
			//sceneDataProvider.RegisterLobby(this);
			//uiService.Open<LobbyHud>();
		}
	}
}
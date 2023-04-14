using Game.UI;
using UnityEngine;

namespace Game
{
	public class GameController : Fancy.MonoSingleton<GameController>
	{
		[SerializeField] private ResourcesConfigData resources = default;

		public ResourcesDataProvider ResourcesData { get; set; }
		public SaveService SaveService{ get; set; }

		protected override void Awake()
		{
			SaveService = new SaveService();
			SaveService.OnCreate();

			ResourcesData = new ResourcesDataProvider(SaveService, resources);
			ResourcesData.SetStartResources();

			GameState.Init<MainState>();

		}

		public void ResetProgress()
		{
			/*PlayerPrefs.DeleteAll();
			PlayerPrefs.Save();
			player.Load();
			UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");*/
		}
	}
}

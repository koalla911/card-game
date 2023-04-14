using Game.UI;
using UnityEngine;

namespace Game
{
	public class GameController : Fancy.MonoSingleton<GameController>
	{
		[SerializeField] private ResourcesConfigData resources = default;
		[SerializeField] private ConfigHolder configHolder = default;

		public ResourcesDataProvider ResourcesData { get; set; }
		public ConfigHolder ConfigHolder { get; set; }
		public SaveService SaveService{ get; set; }
		public CardConfigData CardConfigData { get; private set; }

		protected override void Awake()
		{
			SaveService = new SaveService();
			SaveService.OnCreate();

			ResourcesData = new ResourcesDataProvider(SaveService, resources);
			ResourcesData.SetStartResources();

			GameState.Init<MainState>();

		}

		//TODO: Simple Card Generator
		/*public void GenerateRace()
		{
			CardConfigData = raceGenerator.Generate(); //generate Race
		}*/

		public void ResetProgress()
		{
			/*PlayerPrefs.DeleteAll();
			PlayerPrefs.Save();
			player.Load();
			UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");*/
		}
	}
}

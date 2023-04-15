using Game.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class GameController : Fancy.MonoSingleton<GameController>
	{
		[SerializeField] private SimpleLevelGenerator levelGenerator = default;

		public ResourcesDataProvider ResourcesData { get; set; }
		public SaveService SaveService{ get; set; }
		public Level Level { get; private set; }

		[Header("Needs to be initialize in ConfigHolder")]
		[SerializeField] private PackConfigData packConfig = default;
		public PackConfigData PackConfig => packConfig;

		[SerializeField] private ResourcesConfigData resourcesConfig = default;
		public ResourcesConfigData ResourcesConfig => resourcesConfig;

		[SerializeField] private ResearchesConfigData researchesConfig = default;
		public ResearchesConfigData ResearchesConfig => researchesConfig;

		[SerializeField] private CardConfigData[] cardsConfig = default;
		public CardConfigData[] CardsConfig => cardsConfig;

		protected override void Awake()
		{
			GenerateLevel();
			GeneratePools();

			SaveService = new SaveService();
			SaveService.OnCreate();

			ResourcesData = new ResourcesDataProvider(SaveService, resourcesConfig);
			ResourcesData.SetStartResources();

			GameState.Init<MainState>();

		}

		//TODO: Simple Card Generator
		public void GenerateLevel()
		{
			Level = levelGenerator.Generate();//generate Race
		}

		public ObjectPool<PackButtonView> packBtnPool = default;
		[SerializeField] private PackButtonView packBtnPrefab = default;
		[SerializeField] private LayoutGroup packsBtnParent = default;

		public ObjectPool<CardView> cardPool = default;
		[SerializeField] private CardView cardPrefab = default;
		[SerializeField] private LayoutGroup cardParent = default;

		public void GeneratePools()
		{
			ClearLayout(packsBtnParent);
			packBtnPool = new ObjectPool<PackButtonView>(packBtnPrefab, PackConfig.Packs.Count, packsBtnParent.gameObject);

			ClearLayout(cardParent);
			cardPool = new ObjectPool<CardView>(cardPrefab, ResearchesConfig.PackSlots, cardParent.gameObject);
		}

		//TODO: ObjectPool needs to be able to enable existed objects and remove extra
		private void ClearLayout(LayoutGroup layout)
		{
			if (layout.transform.childCount > 0)
			{
				for (int i = 0; i < layout.transform.childCount; i++)
				{
					Destroy(layout.transform.GetChild(i).gameObject);
				}
			}
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

using Game.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class GameController : Fancy.MonoSingleton<GameController>
	{
		[SerializeField] private SimpleLevelGenerator levelGenerator = default;

		public ResourcesDataProvider ResourcesProvider { get; set; }
		public SaveService SaveService{ get; set; }
		public Level Level { get; private set; }

		[Header("Needs to be initialize in ConfigHolder")]
		[SerializeField] private PackConfigData packConfig = default;
		public PackConfigData PackConfig => packConfig;

		[SerializeField] private ResourcesConfigData resourcesConfig = default;
		public ResourcesConfigData ResourcesConfig => resourcesConfig;

		[SerializeField] private ResearchesConfigData researchesConfig = default;
		public ResearchesConfigData ResearchesConfig => researchesConfig;

		[Header("Cards: Needs to be initialize something else")]
		[SerializeField] private List<CardConfigData> cards = default;
		public IReadOnlyList<CardConfigData> Cards => cards;

		public PackTypeInfo currentPack = default;

		protected override void Awake()
		{
			GenerateLevel();
			GeneratePools();

			SaveService = new SaveService();
			SaveService.OnCreate();

			ResourcesProvider = new ResourcesDataProvider(SaveService, resourcesConfig);
			ResourcesProvider.SetStartResources();

			GameState.Init<MainState>();

		}

		//TODO: Simple Card Generator
		public void GenerateLevel()
		{
			Level = levelGenerator.Generate();//generate Level
		}

		public PoolMono<PackButtonView> packBtnPool = default;
		[SerializeField] private PackButtonView packBtnPrefab = default;
		[SerializeField] private LayoutGroup packsBtnParent = default;

		public PoolMono<CardView> cardPool = default;
		[SerializeField] private CardView cardPrefab = default;
		[SerializeField] private LayoutGroup cardParent = default;

		public void GeneratePools()
		{
			ClearLayout(packsBtnParent);
			packBtnPool = new PoolMono<PackButtonView>(packBtnPrefab, PackConfig.Packs.Count, packsBtnParent.gameObject.transform, false);

			ClearLayout(cardParent);
			cardPool = new PoolMono<CardView>(cardPrefab, ResearchesConfig.PackSlots, cardParent.gameObject.transform, false);
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

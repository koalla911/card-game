using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = nameof(ConfigHolder), menuName = "Data/"+nameof(ConfigHolder))]
	public class ConfigHolder : ScriptableObject
	{
		[SerializeField] private PackConfigData packConfig = default;
		public PackConfigData PackConfig => packConfig;

		[SerializeField] private ResourcesConfigData resourcesConfig = default;
		public ResourcesConfigData ResourcesConfig => resourcesConfig;
		
		[SerializeField] private ResearchesConfigData researchesConfig = default;
		public ResearchesConfigData ResearchesConfig => researchesConfig;
		
		[SerializeField] private CardConfigData[] cardsConfig = default;
		public CardConfigData[] CardsConfig => cardsConfig;

	}
}

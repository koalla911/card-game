using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = nameof(ConfigHolder), menuName = "Data/"+nameof(ConfigHolder))]
	public class ConfigHolder : ScriptableObject
	{
		[SerializeField] private PackConfigData packs = default;
		public PackConfigData Packs => packs;

		[SerializeField] private ResourcesConfigData resources = default;
		public ResourcesConfigData Resources => resources;
		
		[SerializeField] private ResearchesConfigData researches = default;
		public ResearchesConfigData Researches => researches;
		
		[SerializeField] private CardConfigData[] cards = default;
		public CardConfigData[] Cards => cards;

	}
}

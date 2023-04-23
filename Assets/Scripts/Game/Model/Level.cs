using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
	public class Level
	{
		public List<CardConfigData> cards = new();
		public List<PackTypeInfo> packs = new();
		public Dictionary<PackTypeInfo, List<CardConfigData>> cardPackSet = new();

		public IEnumerable<string> GetAllCardTypes() => cards.Select(t => t.IncludedInPack);
		public CardConfigData GetCardInfoByType(string cardType)
		{
			return cards.Find(t => t.IncludedInPack == cardType)
				?? throw new Exception($"{nameof(CardConfigData)} `{cardType}` not found");
		}

		public int SumCardWeights()
		{
			int sum = 0;

			for(int i = 0; i < cards.Count; i++)
			{
				sum += cards[i].Weight;
			}

			return sum;
		}

		public float k;
		public float p;
		public float P(int weight)
		{
			int allWeights = SumCardWeights();
			return (float)Math.Round((float)weight / allWeights, 2);
		}

		public float K()
		{
			Random random = new();
			k = (float)random.NextDouble();
			k = (float)Math.Round(k, 2);
			return k;
		}
	}
}

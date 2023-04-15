using System;
using System.Collections.Generic;

namespace Game
{
	public class Level
	{
		public List<CardConfigData> cards = new();
		public List<Pack> packs = new();
		public ResearchesConfigData researches = new();

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
		public float P(int weight, int allWeights)
		{
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

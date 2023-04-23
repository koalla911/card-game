using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
	public class Card
	{
		public int number;
		public int weight;

		public float k;
		public float p;

		/*public int Number(int capacity)
		{
			Random randomNumber = new();
			number = randomNumber.Next(1, capacity);
			return number;
		}*/
		/*public bool IsMatch(List<CardConfigData> cards, string packName)
		{
			return cards.Any(t => t.IncludedInPack == packName);
		}*/

		public float P(int allWeights)
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

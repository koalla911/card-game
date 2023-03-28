﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
	public class Card
	{
		static int setSize = 6;
		static int cardCount = default;

		/*public static void Main(string[] args)
		{
			do
			{
				Console.Write("Enter the size of your set> ");
				cardCount = Convert.ToInt32(Console.ReadLine());

				var set = FillSet(cardCount);
				var cards = Cards(setSize, set);
				//Console.WriteLine("Your set is : \n" + string.Join("\n", FillSet(setSize).Select(kvp => $"{kvp.Key}\t{kvp.Value}")));

				foreach (var item in cards)
				{
					Console.WriteLine(item.ToString());
				}

			} while (cardCount != -1);
		}*/

		private Dictionary<int, float> FillSet(int size)
		{
			Dictionary<int, float> cardSet = new();
			float percent = 1f;
			Random random = new();

			for (int i = 0; i < size; i++)
			{
				int randInt = random.Next(1, 99);
				percent -= (float)randInt / 100f;
				percent = (float)Math.Round(percent, 2);
				if (percent < 0) percent *= -1;
				cardSet.Add(i, percent);
			}

			return cardSet;
		}

		private List<int> Cards(int setSize, Dictionary<int, float> cardSet)
		{
			List<int> cards = new();

			while (cards.Count < setSize)
			{
				Random randomCard = new();
				int currentCard = randomCard.Next(1, cardSet.Keys.Count);
				float probability = GetRandomProbability();

				if (cardSet[currentCard] <= probability)
				{
					cards.Add(currentCard);
				}
				Console.WriteLine("Probability : " + probability + " Value : " + cardSet[currentCard]
							+ " Is suitable? " + (cardSet[currentCard] <= probability) + ";"
							+ " Card number : " + currentCard);
			}

			return cards;
		}

		public float GetRandomProbability()
		{
			Random random = new();
			float probability = (float)random.NextDouble();
			probability = (float)Math.Round(probability, 2);
			return probability;
		}
	}
}

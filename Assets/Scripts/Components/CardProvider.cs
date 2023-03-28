using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class CardProvider : MonoBehaviour
	{
		[SerializeField] private List<int> cardNums = new();
		[SerializeField] private List<int> cardWeights = new();
		private Dictionary<int, float> probabilities = new();
		private Card card = new();

		private void Awake()
		{
			
		}

		private int SumWeights(List<int> weights)
		{
			int sum = 0;

			foreach(int weight in weights)
			{
				sum += weight;
			}

			return sum;
		}

		private void SetProbability()
		{
			List<float> probs = new();

			foreach(int num in cardNums)
			{
				probabilities.Add(num, cardWeights[num] / SumWeights(cardWeights));
			}
		}

		private List<int> TryGetCard()
		{
			List<int> resultSet = new();

			foreach (int prob in probabilities.Keys)
			{
				float randomProb = card.GetRandomProbability();

				if (probabilities[prob] <= randomProb)
				{
				}
			}

			return resultSet;
		}
	}
}

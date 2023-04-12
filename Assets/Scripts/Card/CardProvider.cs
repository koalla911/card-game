using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
	public class CardProvider : MonoBehaviour //Service
	{
		private DataService dataService = default;
		private int cards = default;
		[SerializeField] private List<int> cardWeights = new();
		[SerializeField] private List<TextMeshProUGUI> numTexts = new();

		private List<int> cardNums = new();
		private Dictionary<int, float> probabilities = new();
		private CardLegacy card = new();

		public CardConfig CardConfig => dataService.CardConfig;

		public void Awake()
		{
			cards = cardWeights.Count;

			for (int i = 0; i < cards; i++)
			{
				cardNums.Add(i);
			}

			SetProbability();

			foreach (int num in cardNums)
			{
				Debug.Log(num);

				numTexts[num].SetText(TryGetCard().ToString());
			}
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
			int sum = SumWeights(cardWeights);

			foreach (int num in cardNums)
			{
				float weight = (float)Math.Round((float)cardWeights[num] / sum, 2);
				probabilities.Add(num, weight);
			}
		}

		private int TryGetCard()
		{
			System.Random randomNumber = new();
			int cardNumber = randomNumber.Next(1, cardNums.Count);
			float random = card.GetRandomProbability();
			int resultNumber = probabilities[cardNumber] <= random ? cardNumber : TryGetCard();
			Debug.Log(resultNumber);

			return resultNumber;
		}

		public struct AnimalGradeData
		{
			public int Grade;
			public bool IsMaxGrade;
			public int CurrentProgress;
			public int NextGradeProgress;
			public int NextGradeCoinsReward;
			public int AvailableCoinsReward;
		}

		public struct BiomeGradeData
		{
			public int CurrentProgress;
			public int NextGradeProgress;
			public int NextGradeCoinsReward;
			public int AvailableCoinsReward;
		}
	}
}

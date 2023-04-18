using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "LevelGenerator", menuName = "Game/LevelGenerator", order = 0)]
	public class SimpleLevelGenerator : LevelGenerator
	{
		public override Level Generate()
		{
			Level level = new Level();
			level.packs = GeneratePacks();
			level.cards = GenerateCards();
			//level.cardsTypeSet = GenerateCardsByType(level);

			/*for (int i = 0; i < GameController.Instance.ResearchesConfig.PackCapacity; i++)
			{
				level.cards[i].SetP(level.P(level.cards[i].Weight));
			}
*/
			return level;
		}

		public List<PackTypeInfo> GeneratePacks()
		{
			List<PackTypeInfo> packs = new();
			for (int i = 0; i < GameController.Instance.PackConfig.Packs.Count; i++)
			{
				packs.Add(GameController.Instance.PackConfig.Packs[i]);
			}
			return packs;
		}
		
		public List<CardConfigData> GenerateCards()
		{
			List<CardConfigData> cards = new();
			for (int i = 0; i < GameController.Instance.Cards.Count; i++)
			{
				cards.Add(GameController.Instance.Cards[i]);
				cards[i].SetNumber(i + 1);
			}
			return cards;
		}
		
		/*public Dictionary<string, List<CardConfigData>> GenerateCardsByType(Level level)
		{
			Dictionary<string, List<CardConfigData>> allCardsByType = new();
			//List<CardConfigData> cardType = new();
			*//*List<CardConfigData> cardsCopy = new();
			for (int j = 0; j < level.cards.Count; j++)
			{
				cardsCopy.Add(level.cards[j]);
			}*//*
			//Debug.Log(level.GetCardInfoByType(level.packs[2].CardType));
			//int i = 0;
			//while (i < level.cards.Count)
			for (int i = 0; i < level.cards.Count; i++)
			{
				if (allCardsByType.ContainsKey(level.cards[i].IncludedInPack))
				{
					//List<CardConfigData> cards = new();
					//cards.Add(level.GetCardInfoByType(level.packs[i].CardType));
					allCardsByType[level.cards[i].IncludedInPack].Add(level.GetCardInfoByType(level.packs[i].CardType));
				}
				else
				{
					List<CardConfigData> card = new();
					card.Add(level.GetCardInfoByType(level.packs[i].CardType));
					allCardsByType.Add(level.cards[i].IncludedInPack, card);
				}
				//i++;
			}
			return allCardsByType;
		}*/
	}
}

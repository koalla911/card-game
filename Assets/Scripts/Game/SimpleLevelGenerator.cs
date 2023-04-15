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

			for (int i = 0; i < GameController.Instance.ResearchesConfig.PackCapacity; i++)
			{
				level.cards[i].SetP(level.P(level.cards[i].Weight));
			}

			return level;
		}

		public List<Pack> GeneratePacks()
		{
			List<Pack> packs = new();
			for (int i = 0; i < GameController.Instance.PackConfig.Packs.Count; i++)
			{
				packs.Add(GameController.Instance.PackConfig.Packs[i]);
			}
			return packs;
		}
		
		public List<CardConfigData> GenerateCards()
		{
			List<CardConfigData> cards = new();
			for (int i = 0; i < GameController.Instance.ResearchesConfig.PackCapacity; i++)
			{
				cards.Add(GameController.Instance.CardsConfig[i]);
				cards[i].SetNumber(i+1);
			}
			return cards;
		}
	}
}

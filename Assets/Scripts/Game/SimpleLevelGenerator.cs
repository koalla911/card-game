using System;
using System.Collections.Generic;
using System.Linq;
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

			foreach(var pack in level.packs)
			{
				var cards = level.cards.Where(c => c.IncludedInPack == pack.PackName).Select(c => c).ToList();
				level.cardPackSet.Add(pack, cards);
			}

			foreach (var cards in level.cardPackSet.Values)
			{
				for (int i = 0; i < cards.Count; i++)
				{
					cards[i].SetP(level.P(cards[i].Weight));
				}
			}

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
			for (int i = 0; i < GameController.Instance.PackProvider.Cards.Count; i++)
			{
				cards.Add(GameController.Instance.PackProvider.Cards[i]);
				//cards[i].SetNumber(i + 1);
			}
			return cards;
		}
	}
}

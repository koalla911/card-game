using Game;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(CardConfigData), menuName = "Data/" + nameof(CardConfigData))]
public class CardConfigData : ScriptableObject
{
	[SerializeField] private List<CardTypeInfo> cards = default;
	public IReadOnlyList<CardTypeInfo> Cards => cards;

	[SerializeField] private List<CardWeightInfo> weights = default;
	public IReadOnlyList<CardWeightInfo> Weights => weights;

	public CardTypeInfo GetCardInfo(string cardType)
	{
		return cards.Find(t => t.CardType == cardType)
			?? throw new UnityException($"{nameof(CardTypeInfo)} not found for `{cardType}");
	}
}

[Serializable]
public class CardTypeInfo
{
	[SerializeField] private string cardType = default;
	public string CardType => cardType;

	[SerializeField] private Sprite preview = default;
	public Sprite Preview => preview;
}

[Serializable]
public class CardWeightInfo
{
	[field: SerializeField] public int Weight { get; private set; }
}

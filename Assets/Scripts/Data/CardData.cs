using Game;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(CardData), menuName = "Data/" + nameof(CardData))]
public class CardData : ScriptableObject
{
	[SerializeField, CardPackPopupAttribute] private string includedInPack = default;
	public string IncludedInPack => includedInPack;

	[SerializeField] private string type = default;
	public string Type => type;

	[field: Header("Visual")]
	[SerializeField] private Sprite cardImage = default;
	public Sprite CardImage => cardImage;

	[field: Header("Params")]
	[SerializeField] private int number = default;
	public int Number => number;

	[SerializeField] private int weight = default;
	public int Weight => weight;

	[SerializeField] private string description = default;
	public string Description => description;
}


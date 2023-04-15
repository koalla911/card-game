using Game;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(CardConfigData), menuName = "Data/" + nameof(CardConfigData))]
public class CardConfigData : ScriptableObject
{
	[SerializeField, PackNamePopupAttribute] private string includedInPack = default;
	public string IncludedInPack => includedInPack;

	[SerializeField] private string type = default;
	public string Type => type;

	[field: Header("Visual")]
	[SerializeField] private Sprite cardImage = default;
	public Sprite CardImage => cardImage;

	[field: Header("Params")]

	[SerializeField] private int weight = default;
	public int Weight => weight;

	[SerializeField] private string description = default;
	public string Description => description;

	private int number = default;
	[HideInInspector] public int Number => number;
	public void SetNumber(int value)
	{
		number = value;
	}
}


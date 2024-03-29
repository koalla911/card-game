﻿using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(CardConfigData), menuName = "Data/" + nameof(CardConfigData))]
public class CardConfigData : ScriptableObject
{
	[SerializeField, PackNamePopupAttribute] private string includedInPack = default;
	public string IncludedInPack => includedInPack;

	[SerializeField] private string type = default;
	public string Type => type;

	[field: Header("Visual")]
	[SerializeField] private Sprite cardIcon = default;
	public Sprite CardIcon => cardIcon;

	[field: Header("Params")]

	[SerializeField] private int weight = default;
	public int Weight => weight;

	[SerializeField] private string description = default;
	public string Description => description;

	private int number = default;
	/*[HideInInspector] public int Number => number;
	public void SetNumber(int value)
	{
		number = value;
	}*/
	
	private float p = default;
	[HideInInspector] public float P => p;
	public void SetP(float value)
	{
		p = value;
	}

	public bool IsMatch(List<CardConfigData> cards, PackTypeInfo pack)
	{
		return cards.Any(t => t.IncludedInPack == pack.PackName);
	}
}


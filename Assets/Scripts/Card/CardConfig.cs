using Game;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(CardConfig), menuName = "Data/" + nameof(CardConfig))]
public class CardConfig : ScriptableObject
{
	public enum CardType
	{
		DEFAULT = 0,
		MAGIC = 1,
	}

	[SerializeField] private List<CardInfo> cards = default;
	public IReadOnlyList<CardInfo> Cards => cards;

	[SerializeField] private Stations stations = null;
	[Serializable] private class Stations : SerializableDictionary<CardType, CardInfo> { }
	/*public CardInfo GetCardByNumber(WindowType type)
	{
		TryInitCards();
		if (!cards.TryGetValue(type, out var window))
		{
			throw new UnityException($"cant find window by type {type}");
		}
		return window;
	}

	private void TryInitCards()
	{
		if (windowsDict != null && windowsDict.Count > 0)
		{
			return;
		}

		windowsDict = new Dictionary<WindowType, Window>();
		foreach (var window in windows)
		{
			windowsDict.Add(window.WindowType, window.Origin);
		}
	}*/
}

[Serializable]
public class CardInfo
{
	[SerializeField] private string id = default;
	public string ID => id;

	[SerializeField] private Sprite cardImage = default;
	public Sprite CardImage => cardImage;

	[SerializeField] private int number = default;
	public int Number => number;

	[SerializeField] private int weight = default;
	public int Weight => weight;
	
	[SerializeField] private string description = default;
	public string Description => description;
}

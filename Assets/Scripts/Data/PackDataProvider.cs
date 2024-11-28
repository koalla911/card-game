using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PackDataProvider
	{
		[SerializeField] private List<CardConfigData> cards = new();
		public IReadOnlyList<CardConfigData> Cards => cards;

		public List<CardConfigData> AvailableCards = new();
		public List<PackTypeInfo> AvailablePacks = new();

		private List<CardConfigData> selectedCards = new();
		public List<CardConfigData> SelectedCards => selectedCards;
		public event Action OnCardSelected;

		public void TryAddSelectedCard(CardConfigData selectedCard)
		{
			selectedCards.Add(selectedCard);
			OnCardSelected?.Invoke();
			Debug.Log("Select card");
		}

		public void ClearCards()
		{
			selectedCards.Clear();
			AvailableCards.Clear();
			AvailablePacks.Clear();
		}
	}
}

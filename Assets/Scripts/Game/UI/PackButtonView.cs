using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class PackButtonView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI price = default;
		[SerializeField] private TextMeshProUGUI labelName = default;
		[SerializeField] private Button packIncreaseButton = default;
		[SerializeField] private Button packDecreaseButton = default;
		[SerializeField] private TextMeshProUGUI packCountLabel = default;

		private PackTypeInfo pack = default;
		private int packCount = default;

		public void Init(PackTypeInfo pack)
		{
			this.pack = pack; 
			price.SetText("price: "+ this.pack.PackPrice.ToString());
			labelName.SetText("name: "+ this.pack.PackName.ToString());
			packCount = 0;
			packCountLabel.SetText(packCount.ToString());
		}

		private void OnEnable()
		{
			packIncreaseButton.onClick.AddListener(SetCurrentPack);
			packDecreaseButton.onClick.AddListener(RemoveCurrentPack);
		}

		private void OnDisable()
		{
			packIncreaseButton.onClick.RemoveListener(SetCurrentPack);
			packDecreaseButton.onClick.RemoveListener(RemoveCurrentPack);
		}

		private void SetCurrentPack()
		{
			var currentCards = GameController.Instance.Level.cardPackSet[this.pack];
			GameController.Instance.PackProvider.AvailableCards = currentCards;
			GameController.Instance.PackProvider.AvailablePacks.Add(this.pack);
			packCount++;
			packCountLabel.SetText(packCount.ToString());

			/*for (int i = 0; i < currentCards.Count; i++)
			{
				Debug.Log("Name: " + currentCards[i].name + " "
							+ "Weight: " + currentCards[i].Weight);
			}*/
		}

		private void RemoveCurrentPack()
		{
			GameController.Instance.PackProvider.AvailablePacks.Remove(this.pack);
			packCount--;
			packCountLabel.SetText(packCount.ToString());
		}
	}
}

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
		[SerializeField] private Button packButton = default;
		private PackTypeInfo pack = default;

		public void Init(PackTypeInfo pack)
		{
			price.SetText("price: "+ pack.PackPrice.ToString());
			labelName.SetText("name: "+ pack.PackName.ToString());
		}

		private void OnEnable()
		{
			packButton.onClick.AddListener(SetCurrentPack);
		}

		private void OnDisable()
		{
			packButton.onClick.RemoveListener(SetCurrentPack);

		}

		private void SetCurrentPack()
		{
			if (pack != null)
			{
				GameController.Instance.currentPack = this.pack;
			}
		}
	}
}

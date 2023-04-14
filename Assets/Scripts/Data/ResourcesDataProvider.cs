using System;
using UnityEngine;
using Zenject;

namespace Game
{
	public class ResourcesDataProvider : Service
	{
		[Inject] private static SaveService saveService = default;
		[Inject] private static DataService dataService = default;

		public event Action<int> OnResourcesChanged;

		public ResourcesConfigData ResourcesConfig => ConfigHolder.Instance.ResourcesConfigData;
		private SaveData saveData => saveService.SaveData;
		public int Resources
		{
			get => saveData.Resources;
			private set
			{
				saveData.Resources = value;
				saveService.Save();
				OnResourcesChanged?.Invoke(saveData.Resources);
			}
		}

		public override void OnAwake()
		{
			Debug.Log("Resources provider Awake");
			SetStartResources();
		}

		public void SetResourcesAmount(int difference)
		{
			Resources += difference;
		}

		public void SetStartResources()
		{
			Resources = (Resources - Resources) + ResourcesConfig.ResourcesStartValue;
		}

		public bool TryBuyRitual(int price)
		{
			if (Resources >= price)
			{
				SetResourcesAmount(-price);
			}
			return false;
		}
	}
}

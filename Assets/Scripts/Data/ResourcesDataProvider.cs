using System;
using UnityEngine;
//using Zenject;

namespace Game
{
	public class ResourcesDataProvider
	{
		private SaveService saveService = default;
		private ResourcesConfigData resourcesConfig = default;

		public ResourcesDataProvider(SaveService saveService, ResourcesConfigData resourcesConfig)
		{
			this.saveService = saveService;
			this.resourcesConfig = resourcesConfig;
		}

		public event Action<int> OnResourcesChanged;

		//public ResourcesConfigData ResourcesConfig => ConfigHolder.Instance.ResourcesConfigData;
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

		public void SetResourcesAmount(int difference)
		{
			Resources += difference;
		}

		public void SetStartResources()
		{
			Resources = resourcesConfig.ResourcesStartValue;
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

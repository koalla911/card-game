using System;
using TMPro;
using UnityEngine;
//using Zenject;

namespace Game.UI
{
	public class ResourcesWidget : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI resourcesLabel = default;

		private ResourcesDataProvider resourcesDataProvider;

		public void Init(ResourcesDataProvider resourcesDataProvider)
		{
			this.resourcesDataProvider = resourcesDataProvider;
			this.resourcesDataProvider.OnResourcesChanged += OnResourcesChanged;
			OnResourcesChanged(this.resourcesDataProvider.Resources);
		}
		
		private void OnDisable()
		{
			if (resourcesDataProvider != null)
			{
				resourcesDataProvider.OnResourcesChanged -= OnResourcesChanged;
			}
		}

		private void OnResourcesChanged(int obj)
		{
			resourcesLabel.SetText("Resources: " + obj.ToString());
		}
	}
}

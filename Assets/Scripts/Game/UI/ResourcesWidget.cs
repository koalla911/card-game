using System;
using TMPro;
using UnityEngine;
//using Zenject;

namespace Game.UI
{
	public class ResourcesWidget : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI resourcesLabel = default;
		[SerializeField] private ResourcesConfigData resourcesConfig = default;

		public void OnEnable()
		{
			/*GameController.Instance.ResourcesProvider.OnResourcesChanged += OnResourcesChanged;
			OnResourcesChanged(GameController.Instance.ResourcesProvider.Resources);*/
			SetResources();
		}
		
		private void OnDisable()
		{
			/*if (GameController.Instance.ResourcesProvider != null)
			{
				GameController.Instance.ResourcesProvider.OnResourcesChanged -= OnResourcesChanged;
			}*/
		}

		private void OnResourcesChanged(int obj)
		{
			resourcesLabel.SetText("Resources: " + obj.ToString());
		}
		
		private void SetResources()
		{
			resourcesLabel.SetText("Resources: " + resourcesConfig.ResourcesStartValue.ToString());
		}
	}
}

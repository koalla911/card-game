using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.UI
{
	public class ResourcesWidget : MonoBehaviour
	{
		[Inject] private static ResourcesDataProvider resourcesDataProvider = default;

		[SerializeField] private TextMeshProUGUI resourcesLabel = default;

		private void OnEnable()
		{
			resourcesDataProvider.OnResourcesChanged += OnResourcesChanged;
			OnResourcesChanged(resourcesDataProvider.Resources);
		}
		
		private void OnDisable()
		{
			resourcesDataProvider.OnResourcesChanged -= OnResourcesChanged;
		}

		private void OnResourcesChanged(int obj)
		{
			resourcesLabel.SetText("Resources: "+obj.ToString());
		}
	}
}

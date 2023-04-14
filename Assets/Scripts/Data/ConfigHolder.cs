﻿using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = nameof(ConfigHolder), menuName = "Data/"+nameof(ConfigHolder))]
	public class ConfigHolder : ScriptableObject
	{
		public static ConfigHolder Instance = default;

		[SerializeField] private PackConfigData packConfigData = default;
		public PackConfigData PackConfigData => packConfigData;

		[SerializeField] private ResourcesConfigData resourcesConfigData = default;
		public ResourcesConfigData ResourcesConfigData => resourcesConfigData;

		public void CreateInstance()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				throw new UnityException("config instance already created");
			}
		}
	}
}

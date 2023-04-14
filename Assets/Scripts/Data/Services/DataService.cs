using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class DataService : Service
{
	//public PackConfigData PackConfigData { get; private set; }
	//public ResourcesConfigData ResourcesConfigData { get; private set; }

	public async UniTask InitAsync()
	{
		/*var tasks = new UniTask[]
		{
			Load<PackConfigData>(t=> CardConfigData = t),
			Load<ResourcesConfigData>(t=> ResourcesConfigData = t),
		};
		await UniTask.WhenAll();*/
	}

	private async UniTask Load<T>(Action<T> setter) where T : ScriptableObject
	{
		/*T asset = await DataLoader.LoadConfigAsync<T>(typeof(T).Name);
		setter.Invoke(asset);*/
	}

}

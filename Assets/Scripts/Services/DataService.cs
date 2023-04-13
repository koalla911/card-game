using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class DataService : Service
{
	public CardPackConfigData CardConfigData { get; private set; }

	public async UniTask InitAsync()
	{
		var tasks = new UniTask[]
		{
			Load<CardPackConfigData>(t=> CardConfigData = t),
		};
		await UniTask.WhenAll();
	}

	private async UniTask Load<T>(Action<T> setter) where T : ScriptableObject
	{
		/*T asset = await DataLoader.LoadConfigAsync<T>(typeof(T).Name);
		setter.Invoke(asset);*/
	}

}

/*public static class DataLoader
{
	public static string VariantDataFolder { get; set; }
	public static bool IsVariantPathSetUp { get; }

	public static Task<T> LoadConfigAsync<T>(string path) where T : ScriptableObject;
	public static Task<ScriptableObject> LoadConfigAsync(string path);
	public static void UnloadAll();
}*/

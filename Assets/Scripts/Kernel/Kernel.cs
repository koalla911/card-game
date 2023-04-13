using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Kernel : MonoBehaviour
{
	[Inject] private static DataService dataService;

	private static ServiceLocator serviceLocator;

	public static async UniTask InitializeServicesAsync()
	{
		serviceLocator = new ServiceLocator();
		serviceLocator.InjectTypes();
		await dataService.InitAsync();
	}

	private void Awake()
	{
		//SceneLoader.OnRestart += serviceLocator.OnRestart;
		serviceLocator.OnAwake();
	}

	private void Update()
	{
		//serviceLocator.OnUpdate();
	}

	private void OnDestroy()
	{
		//SceneLoader.OnRestart -= serviceLocator.OnRestart;
		serviceLocator.OnRestart();
	}

	private void OnApplicationQuit()
	{
		DOTween.KillAll();
		serviceLocator.OnDestroy();
	}
}

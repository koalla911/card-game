using Cysharp.Threading.Tasks;
using Game.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
	[Inject] private static UiService uiService = default;

	public static bool IsEntrySceneActive => SceneManager.GetActiveScene().name == Consts.Scenes.Entry;
	public static bool SecondSceneLoaded => SceneManager.sceneCount > 1;
	public static Action OnRestart;

	private static List<GameObject> lobbyObjects = new();
	private static List<GameObject> mainObjects = new();

	public static async void LoadLobby()
	{
		await SceneManager.LoadSceneAsync(Consts.Scenes.Lobby, LoadSceneMode.Additive);
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(Consts.Scenes.Lobby));
		CollectLobbyObjects();
		AudioManager.PlayMusic("Piano");
	}
	
	public static async void LoadMain()
	{
		await SceneManager.LoadSceneAsync(Consts.Scenes.Persistent, LoadSceneMode.Additive);
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(Consts.Scenes.Persistent));
		CollectMainObjects();
	}

	public static async UniTask LoadGameplay()
	{
		await SceneManager.LoadSceneAsync(GetCurrentLocationSceneName(), LoadSceneMode.Additive);
		SceneManager.SetActiveScene(GetCurrentLocationScene());
		lobbyObjects.ForEach(go => go.SetActive(false));
		AudioManager.PlayAmbient(GetCurrentLocationAmbient());
	}

	public static async UniTask UnloadGameplay()
	{
		OnRestart?.Invoke();
		lobbyObjects.ForEach(go => go.SetActive(true));
		await SceneManager.UnloadSceneAsync(GetCurrentLocationSceneName());
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(Consts.Scenes.Lobby));
		AudioManager.PlayMusic("Piano");
	}

	public static async void RestartGameplay()
	{
		//uiService.SetOverlayActive<LoadingOverlay>(true);
		await UnloadGameplay();
		await LoadGameplay();
		//uiService.SetOverlayActive<LoadingOverlay>(false);
	}

	private static void CollectLobbyObjects()
	{
		var rootObjects = SceneManager.GetSceneByName(Consts.Scenes.Lobby).GetRootGameObjects();
		foreach (var item in rootObjects)
		{
			lobbyObjects.Add(item);
		}
	}
	
	private static void CollectMainObjects()
	{
		var rootObjects = SceneManager.GetSceneByName(Consts.Scenes.Persistent).GetRootGameObjects();
		foreach (var item in rootObjects)
		{
			mainObjects.Add(item);
		}
	}

	private static Scene GetCurrentLocationScene()
	{
		return SceneManager.GetSceneByName(GetCurrentLocationSceneName());
	}

	private static string GetCurrentLocationSceneName()
	{
		/*string loc = questsDataProvider.GetCurrentQuest().Location;
		return locationsDataProvider.GetLocationInfo(loc).SceneName;*/
		return null;
	}

	private static AudioClip GetCurrentLocationAmbient()
	{
		/*string loc = questsDataProvider.GetCurrentQuest().Location;
		return locationsDataProvider.GetLocationInfo(loc).Ambient;*/
		return null;
	}

	public static string GetCurrentSceneName()
	{
		return SceneManager.GetActiveScene().name;
	}
}


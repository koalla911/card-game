using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiService : Service
{
	private Dictionary<Type, ScreenState> screens = new();
	private Stack<Type> screensStack = new();
	private GameObject uiCanvas;

	public override void OnAwake()
	{
		CollectScreens(Consts.Scenes.Persistent); //May collect nothing because scene may still not be populated on awake
	}

	private void CollectScreens(string sceneName)
	{
		var rootObjects = SceneManager.GetSceneByName(sceneName).GetRootGameObjects();
		foreach (var item in rootObjects)
		{
			if (item.TryGetComponent(out Canvas canvas))
			{
				uiCanvas = canvas.gameObject; //Rewrite if more than one canvas is in use
				foreach (Transform child in canvas.transform)
				{
					if (child.TryGetComponent(out ScreenState screen))
					{
						Debug.Log(child.gameObject.name);
						screens.Add(screen.GetType(), screen);
					}
				}
			}
		}
	}

	public T Open<T>(bool onTop = false, bool dropStack = false) where T : ScreenState
	{
		if (!onTop || dropStack)
		{
			foreach (var screenType in screensStack)
			{
				screens[screenType].Close();
			}
		}
		if (dropStack)
		{
			screensStack.Clear();
		}

		var type = typeof(T);
		screensStack.Push(type);
		screens[type].Open();
		return screens[type] as T;
	}

	public void Close<T>() where T : ScreenState
	{
		screensStack.Pop();
		screens[typeof(T)].Close();
		if (screensStack.Count > 0)
		{
			screens[screensStack.Peek()].Open();
		}
	}

	public T SetOverlayActive<T>(bool value) where T : ScreenState
	{
		var type = typeof(T);
		if (value)
		{
			screens[type].Open();
		}
		else
		{
			screens[type].Close();
		}
		return screens[type] as T;
	}

	public void SetActive<T>(bool value) where T : ScreenState
	{
		if (value)
		{
			Open<T>();
		}
		else
		{
			Close<T>();
		}
	}

	public void SetCanvasActive(bool value)
	{
		uiCanvas.SetActive(value);
	}

	public T GetScreen<T>() where T : ScreenState
	{
		return screens[typeof(T)] as T;
	}
}
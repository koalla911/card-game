using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fancy
{
public static class Helpers
{
	// Returns first encountered instance of T in currently loaded scenes
	// Note that result may have not been Awake'ned or OnEnable'ed yet
	public static T FindSceneComponent<T>(bool includeInactive = false) where T : MonoBehaviour
	{
		T result = null;
		result = GameObject.FindObjectOfType<T>(includeInactive);
		if(result != null) return result;

		var sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCount;
		for(int i = 0; i < sceneCount; i++)
		{
			var scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i);
			var allGameObjects = scene.GetRootGameObjects();
			for (int j = 0; j < allGameObjects.Length; j++)
			{
				var go = allGameObjects[j];
				result = go.GetComponentInChildren<T>(includeInactive);
				if(result != null) {
					return result;
				}
			}
		}
		return null;
	}

	public static T[] FindSceneComponents<T>(bool includeInactive = false) where T : MonoBehaviour
	{
		List<T> result = new List<T>();
		var sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCount;
		for(int i = 0; i < sceneCount; i++)
		{
			var scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i);
			var allGameObjects = scene.GetRootGameObjects();
			for (int j = 0; j < allGameObjects.Length; j++)
			{
				var go = allGameObjects[j];
				T[] arr = go.GetComponentsInChildren<T>(includeInactive);
				for(int k = 0; k < arr.Length; k++)
				{
					result.Add(arr[k]);
				}
			}
		}
		return result.ToArray();
	}

	public static T GetOrAddComponent<T>(this GameObject source) where T : Component
	{
		T component = source.GetComponent<T>();
		if (component != null) return component;
		return source.AddComponent<T>();
	}

	public static void Show(this GameObject go)
	{
		Animator anim = go.GetComponent<Animator>();
		if(anim != null)
		{
			anim.SetTrigger("Show");
		}
		go.SetActive(true);
	}
	public static void Hide(this GameObject go)
	{
		Animator anim = go.GetComponent<Animator>();
		if(anim == null)
		{
			go.SetActive(false);
		} else
		{
			anim.SetTrigger("Hide");
		}
	}

	public static void DestroyCarefully(this GameObject go)
	{
#if UNITY_EDITOR
		if(UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
		{
			GameObject.Destroy(go);
		} else {
			GameObject.DestroyImmediate(go);
		}
#else
		GameObject.Destroy(go);
#endif
	}

	public static GameObject InstantiateGently(this GameObject go, Transform parent)
	{
#if UNITY_EDITOR
		if(UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
		{
			return GameObject.Instantiate(go, parent);
		} else {
			return UnityEditor.PrefabUtility.InstantiatePrefab(go, parent) as GameObject;
		}
#else
		return GameObject.Instantiate(go, parent);
#endif
	}

	public static void ChangeLayerRecursively(this Transform tr, int defaultLayer, Dictionary<int, int> layerTable, bool includeInactive = false)
	{
		var children = tr.GetComponentsInChildren<Transform>(includeInactive);
		if(layerTable != null)
		{
			for(int j = 0; j < children.Length; j++)
			{
				int l = defaultLayer;
				GameObject go = children[j].gameObject;
				bool fromTable = layerTable.TryGetValue(go.layer, out l);
				go.layer = fromTable ? l : defaultLayer;
			}
			tr.gameObject.layer = layerTable.ContainsKey(tr.gameObject.layer) ? layerTable[tr.gameObject.layer] : defaultLayer;
		} else {
			for(int j = 0; j < children.Length; j++)
			{
				children[j].gameObject.layer = defaultLayer;
			}
			tr.gameObject.layer = defaultLayer;
		}
	}
}

}
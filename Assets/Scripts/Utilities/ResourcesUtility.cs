using System.IO;
using UnityEngine;
using UnityEditor;

public class ResourcesUtility
{
#if UNITY_EDITOR
	public static T GetDataAssetFromEditor<T>(string assetName) where T : Object
	{
		return AssetDatabase.LoadAssetAtPath<T>($"Assets/Bundles/Data/Default/{assetName}.asset");
	}

	public static T GetDefaultDataAssetFromEditor<T>() where T : Object
	{
		return AssetDatabase.LoadAssetAtPath<T>($"Assets/Bundles/Data/Default/{typeof(T).Name}.asset");
	}

	public static void SaveToJson(string defaultFileName, Object assetData)
	{
		string json = JsonUtility.ToJson(assetData, true);
		string path = EditorUtility.SaveFilePanel("Save as Json", "", defaultFileName + ".json", "json");
		if (path.Length != 0)
		{
			File.WriteAllText(path, json);
		}
	}

	public static void LoadFromJson(Object assetData)
	{
		string path = EditorUtility.OpenFilePanel("Load from Json", "", "json");
		string json = "";
		if (path.Length != 0)
		{
			json = File.ReadAllText(path);
		}
		try
		{
			JsonUtility.FromJsonOverwrite(json, assetData);
			Undo.FlushUndoRecordObjects();
			EditorUtility.SetDirty(assetData);
			AssetDatabase.SaveAssets();
		}
		catch (System.Exception ex)
		{
			Debug.LogException(ex);
		}
	}
#endif
}
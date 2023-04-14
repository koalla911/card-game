using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class SaveService
{
	public SaveData SaveData { get; private set; }
	public bool SaveExists => File.Exists(saveFilePath);
	public bool IsFirstSession { get; private set; }
	private string saveFilePath = Path.Combine(Application.persistentDataPath, "save.json");

	public void OnCreate()
	{
		if (SaveExists)
		{
			Load();
		}
		else
		{
			CreateEmpty();
		}
	}

	public void Save()
	{
		SaveData.Version = Application.version;
		SerializeToFile(SaveData, saveFilePath);
	}

	private void CreateEmpty()
	{
		SaveData = new SaveData();
		IsFirstSession = true;
	}

	private void Migrate(SaveData old)
	{
		// for now just drop all progress, keeping Settings and UserProperties
		SaveData = new SaveData();
		SaveData.Settings = old.Settings;
		SaveData.UserProperties = old.UserProperties;
	}

	public void Load()
	{
		string text = DeserializeFromFile(saveFilePath);
		SaveData data = null;
		try
		{
			data = JsonConvert.DeserializeObject<SaveData>(text);
		}
		catch (Exception e)
		{
			Debug.Log(e);
		}

		bool drop = false;
		//drop = true;
		if (data == null || drop)
		{
			CreateEmpty();
		}
		else if (data.Version != Application.version)
		{
			Migrate(data);
		}
		else
		{
			SaveData = data;
		}
	}

	private void SerializeToFile(object value, string filePath)
	{
		string directoryPath = Path.GetDirectoryName(filePath);
		if (!Directory.Exists(directoryPath))
		{
			Directory.CreateDirectory(directoryPath);
		}
		string text = JsonConvert.SerializeObject(value, Formatting.Indented);
		File.WriteAllText(filePath, text);
	}

	private string DeserializeFromFile(string filePath)
	{
		string data = File.ReadAllText(filePath);
		return data;
	}

	public void ClearSave()
	{
		File.Delete(saveFilePath);
	}
}
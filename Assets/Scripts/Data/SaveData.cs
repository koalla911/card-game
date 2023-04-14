using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
	public string Version { get; set; } = string.Empty;
	public int Coins { get; set; }
	public int Resources { get; set; }
	public SettingsSaveData Settings { get; set; } = new();
	public ProfileSaveData Profile { get; set; } = new();
}

public class SettingsSaveData
{
	public bool MuteSfx { get; set; }
	public bool MuteMusic { get; set; }
}

public class TutorialsSaveData
{
	public int TutorialStep { get; set; }
	public int FirstSessionStep { get; set; } = 3;
	public List<string> CompleteTutorials { get; set; } = new();
}

public class EnergySaveData
{
	public int CurrentValue { get; set; }
	public DateTime LastChange { get; set; } = new();
	public DateTime InfiniteEnergyEnd { get; set; } = new();
}

public class UserPropertiesSaveData
{
	public string InstallVersion { get; set; } = Application.version;
	public DateTime InstallDate { get; set; } = DateTime.UtcNow;
	public TimeSpan UserPlaytime { get; set; } = TimeSpan.Zero;
	public string UserType { get; set; } = string.Empty;
}

public class ProfileSaveData
{
}
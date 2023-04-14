using Cysharp.Threading.Tasks;
using Zenject;

public class SettingsDataProvider : Service
{
	[Inject] private static SaveService saveService;

	public SettingsSaveData SettingsSaveData => saveService.SaveData.Settings;

	public bool MuteSfx
	{
		get => SettingsSaveData.MuteSfx;
		set { SettingsSaveData.MuteSfx = value; AudioManager.MuteSfx(value);  saveService.Save(); }
	}

	public bool MuteMusic
	{
		get => SettingsSaveData.MuteMusic;
		set { SettingsSaveData.MuteMusic = value; AudioManager.MuteMusic(value); saveService.Save(); }
	}

	public override async void OnAwake()
	{
		base.OnAwake();
		await UniTask.Yield(PlayerLoopTiming.PreUpdate); // to ensure AudioManager Awake-s first
		AudioManager.MuteMusic(MuteMusic);
		AudioManager.MuteSfx(MuteSfx);
	}
}
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioSource musicSource = default;
	[SerializeField] private AudioSource sfxSource = default;
	[SerializeField] private AudioSource loopSourcePrefab = default;
	[SerializeField] private AudioData audioData = default;

	private static AudioManager instance;
	private static Dictionary<string, AudioData.Sfx> cachedClips = new();
	private static Dictionary<string, List<AudioSource>> playingSources = new();
	private static AudioListener defaultListener;
	private static AudioListener listener;

	private void Awake()
	{
		Cleanup();
		instance = this;
		foreach (var clip in audioData.Clips)
		{
			cachedClips.Add(clip.Id, clip);
		}
	}

	public static void AddListener(AudioListener audioListener, bool persistent)
	{
		if (persistent)
		{
			defaultListener = audioListener;
		}
		else
		{
			listener = audioListener;
			defaultListener.enabled = false;
		}
	}

	public static void RemoveListener()
	{
		if (listener)
		{
			listener.enabled = false;
			listener = null;
			defaultListener.enabled = true;
		}
	}

	public static void Cleanup()
	{
		foreach (var kvp in playingSources)
		{
			if (kvp.Value != null)
			{
				foreach (var source in kvp.Value)
				{
					if (source != null) Destroy(source);
				}
			}
		}
		playingSources.Clear();
		cachedClips.Clear();
	}

	public static void PlaySfx(string id)
	{
		if (TryGetData(id, out var data))
		{
			instance.sfxSource.PlayOneShot(data.Clip, data.Volume);
		}
	}

	public static void PlayLoop(string id)
	{
		if (TryGetData(id, out var data))
		{
			var source = Instantiate(instance.loopSourcePrefab, instance.transform);
			source.clip = data.Clip;
			source.loop = true;
			source.volume = data.Volume;
			source.Play();
			if (!playingSources.ContainsKey(id))
			{
				playingSources.Add(id, new List<AudioSource>());
			}
			playingSources[id].Add(source);
		}
	}

	public static void StopLoop(string id)
	{
		if (playingSources.TryGetValue(id, out var sources))
		{
			foreach (var source in sources)
			{
				source.Stop();
				Destroy(source);
				playingSources.Remove(id);
			}
		}
	}

	public static void PlayMusic(string id)
	{
		StopMusic();
		if (TryGetData(id, out var data))
		{
			instance.musicSource.clip = data.Clip;
			instance.musicSource.volume = data.Volume;
			instance.musicSource.Play();
		}
	}

	public static void PlayAmbient(AudioClip clip)
	{
		instance.musicSource.clip = clip;
		instance.musicSource.time = Random.Range(0f, instance.musicSource.clip.length);
		instance.musicSource.Play();
	}

	public static void StopMusic()
	{
		instance.musicSource.Stop();
		instance.musicSource.time = 0f;
	}

	public static void MuteMusic(bool value)
	{
		instance.musicSource.mute = value;
	}

	public static void MuteSfx(bool value)
	{
		instance.sfxSource.mute = value;
	}

	public static void PauseSfx(bool value)
	{
		if (value)
		{
			instance.sfxSource.Pause();
			foreach (var kvp in playingSources)
			{
				foreach (var source in kvp.Value)
				{
					source.Pause();
				}
			}
		}
		else
		{
			instance.sfxSource.UnPause();
			foreach (var kvp in playingSources)
			{
				foreach (var source in kvp.Value)
				{
					source.UnPause();
				}
			}
		}
	}

	private static object tweenLowpassTarget = new object();
	public static void UnderwaterFx(bool isActive)
	{
		if (instance != null && instance.musicSource != null)
		{
			DOTween.Kill(tweenLowpassTarget);
			string cutoffFreqKey = "Cutoff freq";
			float minValue = 3000f;
			float maxValue = 22000f;
			float duration = 0.2f;
			var mixer = instance.musicSource.outputAudioMixerGroup.audioMixer;
			mixer.GetFloat(cutoffFreqKey, out float currentCutoffFilter);
			DOTween.To(() => currentCutoffFilter, x => currentCutoffFilter = x, isActive ? minValue : maxValue, duration)
				.OnUpdate(() => { mixer.SetFloat(cutoffFreqKey, currentCutoffFilter); })
				.SetUpdate(true)
				.SetTarget(tweenLowpassTarget);
		}
	}

	private static bool TryGetData(string id, out AudioData.Sfx data)
	{
		data = null;
		if (string.IsNullOrEmpty(id))
		{
			Debug.LogError("Empty sound id");
			return false;
		}
		else if (!cachedClips.TryGetValue(id, out data))
		{
			Debug.LogError($"Sound \"{id}\" not exists");
			return false;
		}
		return true;
	}
}

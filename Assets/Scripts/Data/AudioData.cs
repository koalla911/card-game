using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(AudioData), menuName = "Data/" + nameof(AudioData))]
public class AudioData : ScriptableObject
{
	[SerializeField, NonReorderable] private List<Sfx> clips;
	public List<Sfx> Clips => clips;

	[Serializable]
	public class Sfx
	{
		public string Id;
		public AudioClip Clip;
		public float Volume = 1f;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
	public TMPro.TMP_Text label;
	public float updateInterval = 0.25f;
	public int bufferRange = 120;
	private int index;
	private float[] buffer;
	private float accum = 0.0f;

	private static string[] strings = new string[120];

	protected void Awake()
	{
#if UNITY_EDITOR || CHEATS_ENABLED
		
#else
			gameObject.SetActive(false);
#endif
	}

	void OnEnable()
	{
		buffer = new float[bufferRange];
		index = 0;
		for(int i = 0; i < strings.Length; i++)
		{
			strings[i] = i.ToString();
		}
	}

	void Update()
	{
		float t = Time.unscaledDeltaTime;
		buffer[index++] = t;
		if(index >= buffer.Length) {
			index = 0;
		}
		accum += t;
		if(accum >= updateInterval)
		{
			float sum = 0.0f;
			for(int i = 0; i < buffer.Length; i++)
			{
				sum += buffer[i];
			}
			float medium = sum / buffer.Length;
			int fps = (int) (1.0f / medium);
			label.text = (fps >= 0 && fps < strings.Length) ? strings[fps] : fps.ToString();
			//label.text = medium.ToString();
			while(accum >= updateInterval)
			{
				accum -= updateInterval;
			}
		}

	}
}

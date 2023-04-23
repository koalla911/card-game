using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
	public T Prefab { get; }
	public bool AutoExpand { get; set; }
	public Transform PrefabPosition { get; }

	private List<T> pool;
	public List<T> Pool { get { return pool; } }

	public PoolMono(T prefab, int count, Transform prefabParentPosition, bool autoExpand)
	{
		(Prefab, PrefabPosition, AutoExpand) = (prefab, prefabParentPosition, autoExpand);

		CreatePool(count);
	}

	private void CreatePool(int count)
	{
		pool = new List<T>();

		for (int i = 0; i < count; i++)
		{
			CreateObject();
		}
	}

	private T CreateObject(bool isActiveByDefault = false)
	{
		T createdObject = GameObject.Instantiate(Prefab, PrefabPosition);
		createdObject.gameObject.SetActive(isActiveByDefault);
		pool.Add(createdObject);
		return createdObject;
	}

	public bool HasActiveElement(out T element)
	{
		foreach (var item in pool)
		{
			if (!item.gameObject.activeInHierarchy)
			{
				element = item;
				item.gameObject.SetActive(true);
				return true;
			}
			/*else
			{
				element = item;
				item.gameObject.SetActive(false);
				HasActiveElement(out element);
				return true;
			}*/
		}

		element = null;
		return false;
	}

	public T GetActive()
	{
		if (HasActiveElement(out T element))
		{
			return element;
		}

		if (AutoExpand)
		{
			return CreateObject(true);
		}

		throw new Exception($"there is no free elements in pool of type {typeof(T)}");
	}
}


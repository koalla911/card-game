using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
	public T Prefab { get; }
	public bool AutoExpand = true;
	public GameObject PrefabParent { get; }

	private List<T> pool;
	public List<T> Pool { get { return pool; } }

	public ObjectPool(T prefab, int count, GameObject prefabParent)
	{
		(Prefab, PrefabParent) = (prefab, prefabParent);

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
		T createdObject = GameObject.Instantiate(Prefab, PrefabParent.transform);
		createdObject.gameObject.SetActive(isActiveByDefault);
		pool.Add(createdObject);

		return createdObject;
	}

	public bool HasFreeElement(out T element)
	{
		foreach (var item in pool)
		{
			if (!item.gameObject.activeInHierarchy)
			{
				element = item;
				item.gameObject.SetActive(true);
				return true;
			}
		}

		element = null;
		return false;
	}

	public T GetFreeElement()
	{
		if (HasFreeElement(out T element))
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


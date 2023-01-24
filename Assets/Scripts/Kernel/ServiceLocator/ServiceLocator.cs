using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ServiceLocator
{
	private List<Type> types = new List<Type>();
	private Dictionary<Type, object> instances = new Dictionary<Type, object>();

	public void InjectTypes()
	{
		var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name == "Assembly-CSharp");
		foreach (var assembly in assemblies)
		{
			foreach (var type in assembly.GetTypes())
			{
				var attributes = type.GetCustomAttributes<ServiceAttribute>(true);
				if (attributes.Count() > 0)
				{
					types.Add(type);
				}
			}
		}
		foreach (var type in types)
		{
			if (instances.ContainsKey(type))
			{
				throw new Exception($"{type} already registered");
			}
			else
			{
				instances[type] = (Service)Activator.CreateInstance(type);
			}
		}
		var fields = new List<FieldInfo>();
		foreach (var assembly in assemblies)
		{
			foreach (var type in assembly.GetTypes())
			{
				var typefields = type
					.GetFields(BindingFlags.NonPublic | BindingFlags.Static) //Using static so we don't need target instance to inject
					.Where(x => x.IsDefined(typeof(InjectAttribute), false));
				fields.AddRange(typefields);
			}
		}
		foreach (var field in fields)
		{
			var val = instances[field.FieldType];
			field.SetValue(null, val);
		}
		foreach (var service in instances.Values)
		{
			(service as Service)?.OnCreate();
		}
	}

	public void RegisterInstance<T>(T instance)
	{
		var type = typeof(T);
		if (instances.ContainsKey(type))
		{
			throw new Exception($"{type} already registered");
		}
		else
		{
			instances[type] = instance;
		}
	}

	public void OnAwake()
	{
		foreach (var service in instances.Values)
		{
			(service as Service)?.OnAwake();
		}
	}

	public void OnUpdate()
	{
		foreach (var service in instances.Values)
		{
			(service as Service)?.OnUpdate();
		}
	}

	public void OnRestart()
	{
		foreach (var service in instances.Values)
		{
			(service as Service)?.OnRestart();
		}
	}

	public void OnAppFocus(bool focus)
	{
		foreach (var service in instances.Values)
		{
			(service as Service)?.OnAppFocus(focus);
		}
	}

	public void OnDestroy()
	{
		foreach (var service in instances.Values)
		{
			(service as Service)?.OnDestroy();
		}
		types.Clear();
		instances.Clear();
	}
}
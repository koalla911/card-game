using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Game
{
	public abstract class StringsPopupDrawer : PropertyDrawer
	{
		public abstract string[] Values { get; }

		public override void OnGUI(Rect position,
								   SerializedProperty property,
								   GUIContent label)
		{
			if (property.propertyType == SerializedPropertyType.String)
			{
				int index = Mathf.Max(0, Array.IndexOf(Values, property.stringValue));
				index = EditorGUI.Popup(position, property.displayName, index, Values);
				property.stringValue = Values[index];
			}
			else
			{
				base.OnGUI(position, property, label);
			}
		}

		public static T[] GetAllPublicConstantValues<T>(Type type)
		{
			return type
				.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
				.Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(T))
				.Select(x => (T)x.GetRawConstantValue())
				.ToArray();
		}
	}
}

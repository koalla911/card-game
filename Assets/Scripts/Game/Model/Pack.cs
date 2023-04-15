using System;
using UnityEngine;

namespace Game
{
	[Serializable]
	public class Pack : ISerializationCallbackReceiver
	{
		[field: SerializeField] public string PackNameSetter { get; private set; }
		[HideInInspector] public string PackNameGetter { get; private set; }
		[field: SerializeField] public int PackPrice { get; private set; }

		public void OnAfterDeserialize()
		{
			PackNameGetter = GameUtils.SelectPackType(PackNameSetter);
		}

		public void OnBeforeSerialize()
		{
			PackNameGetter = GameUtils.SelectPackType(PackNameSetter);
		}
	}
}

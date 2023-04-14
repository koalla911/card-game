using Game;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PackConfigData), menuName = "Data/" + nameof(PackConfigData))]
public class PackConfigData : ScriptableObject
{
	[SerializeField] private List<CardPackInfo> packs = default;
	public IReadOnlyList<CardPackInfo> Packs => packs;
	public IEnumerable<string> GetAllPackNames() => packs.Select(t => t.Pack);

}

[Serializable]
public class CardPackInfo : ISerializationCallbackReceiver
{
	[field: SerializeField] public string PackName { get; private set; }
	[HideInInspector] public string Pack { get; private set; }
	[field: SerializeField] public int PackPrice { get; private set; }

	public void OnAfterDeserialize()
	{
		Pack = GameUtils.SelectPackType(PackName);
	}

	public void OnBeforeSerialize()
	{
		Pack = GameUtils.SelectPackType(PackName);
	}
}
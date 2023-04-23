using Game;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PackConfigData), menuName = "Data/" + nameof(PackConfigData))]
public class PackConfigData : ScriptableObject
{
	public List<PackTypeInfo> packs = default;
	public IReadOnlyList<PackTypeInfo> Packs => packs;

	public IEnumerable<string> GetAllPackNames() => packs.Select(t => t.PackName);
	//public IEnumerable<string> GetAllCardTypes() => packs.Select(t => t.CardType);

	/*public PackTypeInfo GetCardTypeInfo(string packType)
	{
		return packs.Find(t => t.CardType == packType)
			?? throw new UnityException($"{nameof(PackTypeInfo)} `{packType}` not found");
	}*/
}

[Serializable]
public class PackTypeInfo : ISerializationCallbackReceiver
{
	[field: SerializeField] public string PackName { get; private set; }
	[field: SerializeField] public int PackPrice { get; private set; }
	[field: SerializeField] public Sprite PackIcon { get; private set; }
	[field: SerializeField] public Sprite PackUniqueIcon { get; private set; }
	public string CardType { get; private set; }

	public void OnAfterDeserialize()
	{
		CardType = GameUtils.SelectPackType(PackName);
	}

	public void OnBeforeSerialize()
	{
		CardType = GameUtils.SelectPackType(PackName);
	}
}
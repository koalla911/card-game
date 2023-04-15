using Game;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PackConfigData), menuName = "Data/" + nameof(PackConfigData))]
public class PackConfigData : ScriptableObject
{
	[SerializeField] private List<Pack> packs = default;
	public IReadOnlyList<Pack> Packs => packs;
	public IEnumerable<string> GetAllPackNames() => packs.Select(t => t.PackNameGetter);

}
using Game;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(ResearchesConfigData), menuName = "Data/" + nameof(ResearchesConfigData))]
public class ResearchesConfigData : ScriptableObject
{
	[field: Header("Packs")]
	[SerializeField] private int minPackSize = default;
	public int MinPackSize => minPackSize;
	
	[SerializeField] private int maxPackSize = default;
	public int MaxPackSize => maxPackSize;
}

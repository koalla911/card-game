using Game;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(ResearchesConfigData), menuName = "Data/" + nameof(ResearchesConfigData))]
public class ResearchesConfigData : ScriptableObject
{
	[field: Header("Packs")]
	[SerializeField] private int packSlots = default;
	public int PackSlots => packSlots;

	[SerializeField] private int packCapacity = default;
	public int PackCapacity => packCapacity;
}

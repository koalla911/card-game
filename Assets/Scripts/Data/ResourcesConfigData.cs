using UnityEngine;

[CreateAssetMenu(fileName = nameof(ResourcesConfigData), menuName = "Data/"+nameof(ResourcesConfigData))]
public class ResourcesConfigData : ScriptableObject
{
	[field: SerializeField] public int ResourcesStartValue { get; private set; }
}

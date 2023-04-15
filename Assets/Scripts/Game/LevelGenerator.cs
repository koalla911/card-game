using UnityEngine;

namespace Game
{
	public abstract class LevelGenerator : ScriptableObject
	{
		public abstract Level Generate();
	}
}

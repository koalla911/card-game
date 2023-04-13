using UnityEngine;

namespace Game
{
	public static class GameUtils 
	{
		public static string SelectPackType(string packName)
		{
			return string.IsNullOrWhiteSpace(packName) ? string.Empty : packName;
		}
	}
}

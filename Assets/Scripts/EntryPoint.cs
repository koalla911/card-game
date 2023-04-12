using UnityEngine;

namespace Game
{
	public class EntryPoint : MonoBehaviour
	{
		private void Awake()
		{
			GameState.Init<MainState>();
		}
	}
}

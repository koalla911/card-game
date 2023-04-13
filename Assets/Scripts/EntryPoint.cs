using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

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

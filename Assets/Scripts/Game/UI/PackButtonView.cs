using TMPro;
using UnityEngine;

namespace Game
{
	public class PackButtonView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI price = default;

		public void Init(Pack pack)
		{
			price.SetText(pack.PackPrice.ToString());
		}
	}
}

using System.Linq;
using UnityEditor;

namespace Game
{
	[CustomPropertyDrawer(typeof(CardPackPopupAttribute))]
	public class CardPopupDrawer : StringsPopupDrawer
	{
		public override string[] Values
		{
			get
			{
				var asset = ResourcesUtility.GetDataAssetFromEditor<CardPackConfigData>(nameof(CardPackConfigData));
				return asset == null ? new string[] { string.Empty } : asset.GetAllPackNames()
					.Prepend(string.Empty)
					.ToArray();
			}
		}
	}
}

using System.Linq;
using UnityEditor;

namespace Game
{
	[CustomPropertyDrawer(typeof(PackNamePopupAttribute))]
	public class PackNamePopupDrawer : StringsPopupDrawer
	{
		public override string[] Values
		{
			get
			{
				var asset = ResourcesUtility.GetDataAssetFromEditor<PackConfigData>(nameof(PackConfigData));
				return asset == null ? new string[] { string.Empty } : asset.GetAllPackNames()
					.Prepend(string.Empty)
					.ToArray();
			}
		}
	}
}

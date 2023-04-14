using UnityEngine;

namespace Game
{
	public class ResearchesDataProvider
	{
		public int CurrentPackSize
		{
			get; set;
			/*get => saveData.Resources;
			private set
			{
				saveData.Resources = value;
				saveService.Save();
				OnResourcesChanged?.Invoke(saveData.Resources);
			}*/
		}
	}
}

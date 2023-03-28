using Cysharp.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using UnityEngine;

public partial class CardDataProvider : Service
{
	[Inject] private static SaveService saveService = default;
	//[Inject] private static DataService dataService = default;
	//[Inject] private static ResourcesDataProvider resourcesDataProvider = default;
	//[Inject] private static LocationsDataProvider locationsDataProvider = default;

	public event Action<string> AppliedCoinsChanged;
	public bool WasLastPhotoBest { get; private set; }

	//public BestiarySaveData BestiarySave => saveService.SaveData.Bestiary;
	//public CardConfigData BestiaryConfig => dataService.BestiaryConfigData;

	/*public void ApplyEarnedCoins(string biome, string animalType)
	{
		var gradeData = GetAnimalGradeData(biome, animalType);
		if (gradeData.AvailableCoinsReward > 0)
		{
			var animalData = GetOrAddAnimalSaveData(biome, animalType);
			resourcesDataProvider.ApplyCoinsFlow(gradeData.AvailableCoinsReward, Consts.Sources.GalleryAchievement);
			animalData.AppliedRewards = gradeData.Grade;
			saveService.Save();

			AppliedCoinsChanged?.Invoke(biome);
		}
		MessageUtility.Publish<RewardClaimedMessage>();
	}*/

	/*public void ApplyBiomeReward(string biome)
	{
		var gradeData = GetBiomeGradeData(biome);
		if (gradeData.AvailableCoinsReward > 0)
		{
			var biomeData = GetOrAddBiomeSaveData(biome);
			resourcesDataProvider.ApplyCoinsFlow(gradeData.AvailableCoinsReward, Consts.Sources.GalleryAchievement);
			biomeData.IsRewardApplied = true;
			saveService.Save();

			AppliedCoinsChanged?.Invoke(biome);
		}
	}*/

	public string GetPhotoFilePath(string biome, string animalType)
	{
		return Path.Combine(Application.persistentDataPath, "Bestiary", biome.ToString(), animalType) + ".jpg";
	}

	/*public async void SavePhotoAsync(PhotoData photoData)
	{
		if (photoData.capturedTargets.Count == 0) return;

		var animalType = photoData.capturedTargets[0].skinInfo.AnimalType;
		var biomeId = locationsDataProvider.GetCurrentBiomeId();
		var animalData = GetOrAddAnimalSaveData(biomeId, animalType);
		string path = GetPhotoFilePath(biomeId, animalType);
		await photoSpritesCache.SavePhotoAsync(photoData.photo.texture, path);
		animalData.PhotosMade++;
		animalData.LastPhotoFilePath = path;
		saveService.Save();
	}*/


	/*public UniTask<Sprite> LoadPhoto(string biome, string animalType)
	{
		string path = GetOrAddAnimalSaveData(biome, animalType).LastPhotoFilePath;
		return photoSpritesCache.LoadPhotoAsync(path);
	}*/

	/*public bool HasPhoto(string biome, string animalType)
	{
		return GetPhotosMade(biome, animalType) > 0;
	}*/

	/*public int GetPhotosMade(string biome, string animalType)
	{
		return GetOrAddAnimalSaveData(biome, animalType).PhotosMade;
	}*/

	/*public bool TryMarkAsAlreadyShown(string biome, string animalType)
	{
		var animalData = GetOrAddAnimalSaveData(biome, animalType);
		if (!animalData.AlreadyWasShown)
		{
			animalData.AlreadyWasShown = true;
			saveService.Save();
			return true;
		}

		return false;
	}*/

	/*public bool HasNonAppliedReward(string biome, string animalType)
	{
		return GetAnimalGradeData(biome, animalType).AvailableCoinsReward > 0;
	}*/

	/*public bool HasNonAppliedReward(string biome)
	{
		var biomeInfo = locationsDataProvider.GetBiomeInfo(biome);
		var gradeData = GetBiomeGradeData(biome);
		return gradeData.AvailableCoinsReward > 0
			|| biomeInfo.AnimalTypes.Any(t => HasNonAppliedReward(biome, t));
	}*/

	/*public bool HasNonAppliedReward()
	{
		return BestiarySave.Biomes.Any(t => HasNonAppliedReward(t.Key));
	}*/

	/*private BestiaryBiomeSaveData GetOrAddBiomeSaveData(string biome)
	{
		if (!BestiarySave.Biomes.ContainsKey(biome))
		{
			BestiarySave.Biomes.Add(biome, new BestiaryBiomeSaveData());
		}

		return BestiarySave.Biomes[biome];
	}

	private BestiaryAnimalSaveData GetOrAddAnimalSaveData(string biome, string animalType)
	{
		var biomeData = GetOrAddBiomeSaveData(biome);
		if (!biomeData.Animals.ContainsKey(animalType))
		{
			biomeData.Animals.Add(animalType, new BestiaryAnimalSaveData());
		}

		return biomeData.Animals[animalType];
	}*/

	/*public AnimalGradeData GetAnimalGradeData(string biome, string animalType)
	{
		int grade = 0;
		int coinsReward = 0;
		var animalData = GetOrAddAnimalSaveData(biome, animalType);
		int photosMade = animalData.PhotosMade;
		foreach (var gradeInfo in BestiaryConfig.Weights)
		{
			if (photosMade < gradeInfo.Weight)
			{
				break;
			}

			grade++;
			photosMade -= gradeInfo.Weight;
			if (animalData.AppliedRewards < grade)
			{
				coinsReward += gradeInfo.CoinsReward;
			}
		}

		return new AnimalGradeData
		{
			Grade = grade,
			IsMaxGrade = grade == BestiaryConfig.Weights.Count,
			CurrentProgress = photosMade,
			NextGradeProgress = BestiaryConfig.Weights[grade].Weight,
			NextGradeCoinsReward = BestiaryConfig.Weights[grade].CoinsReward,
			AvailableCoinsReward = coinsReward,
		};
	}

	public BiomeGradeData GetBiomeGradeData(string biome)
	{
		var biomeData = GetOrAddBiomeSaveData(biome);
		var biomeInfo = locationsDataProvider.GetBiomeInfo(biome);
		var animalTypes = biomeInfo.AnimalTypes;
		int total = animalTypes.Count;
		int current = biomeData.Animals.Count(kv => kv.Value.PhotosMade > 0 && animalTypes.Contains(kv.Key));
		bool isReady = current >= total;
		bool wasApplied = biomeData.IsRewardApplied;

		return new BiomeGradeData
		{
			CurrentProgress = current,
			NextGradeProgress = total,
			NextGradeCoinsReward = isReady || wasApplied ? 0 : biomeInfo.BestiaryCoinsReward,
			AvailableCoinsReward = isReady && !wasApplied ? biomeInfo.BestiaryCoinsReward : 0,
		};
	}*/
}

public struct AnimalGradeData
{
	public int Grade;
	public bool IsMaxGrade;
	public int CurrentProgress;
	public int NextGradeProgress;
	public int NextGradeCoinsReward;
	public int AvailableCoinsReward;
}

public struct BiomeGradeData
{
	public int CurrentProgress;
	public int NextGradeProgress;
	public int NextGradeCoinsReward;
	public int AvailableCoinsReward;
}

using System.Collections.Generic;
using UnityEngine;

public struct Consts
{
	public const string SaveEncryptionKey = "hWmYq3t6w9z$C&F)"; //128 bit

	public struct Scenes
	{
		public const string Entry = "Entry";
		public const string Persistent = "Persistent";
		public const string Lobby = "Lobby";
		public const string FirstLocation = "Siberia";
	}

	public struct Layers
	{
		public const string Animal = "Animal";
		public const string Obstacle = "Obstacle";
	}

	public struct Biomes
	{
		public const string Taiga = "Taiga";
	}

	public struct Animals
	{
		public const string Empty = "";

		public const string Bear = "Bear";
		public const string Boar = "Boar";
		public const string Deer = "Deer";
		public const string Fox = "Fox";
		public const string Moose = "Moose";
		public const string Owl = "Owl";
		public const string Panther = "Panther";
		public const string Rabbit = "Rabbit";
		public const string Raccoon = "Raccoon";
		public const string Seagul = "Seagul";
		public const string Spider = "Spider";
		public const string Tiger = "Tiger";
		public const string Wolf = "Wolf";
	}
	
	public struct AnimalSkins
	{
		public const string Empty = "";

		public const string Bear_Brown = "Bear/Brown";
		public const string Bear_BrownCub = "Bear/BrownCub";
		public const string Deer_Common = "Deer/Common";
		public const string Deer_Fawn = "Deer/Fawn";
		public const string Deer_Female = "Deer/Female";
		public const string Fox_Common = "Fox/Common";
		public const string Fox_CommonCub = "Fox/CommonCub";
		public const string Rabbit_BrownWhite = "Rabbit/BrownWhite";
		public const string Rabbit_Gray = "Rabbit/Gray";
		public const string Rabbit_GrayCub = "Rabbit/GrayCub";
		public const string Rabbit_WhiteSpots = "Rabbit/WhiteSpots";
		public const string Spider_Green = "Spider/Green";
		public const string Spider_Red = "Spider/Red";
		public const string Spider_Yellow = "Spider/Yellow";
		public const string Tiger_Common = "Tiger/Common";
		public const string Wolf_Common = "Wolf/Common";
		public const string Wolf_CommonCub = "Wolf/CommonCub";
	}

	public static readonly Dictionary<Hue, Color32> Colors = new Dictionary<Hue, Color32>
	{
		{ Hue.Red, new Color32(0xC0, 0x31, 0x40, 0xFF) },
		{ Hue.Green, new Color32(0x36, 0xB2, 0x56, 0xFF) },
		{ Hue.Blue, new Color32(0x30, 0x78, 0xBF, 0xFF) },
		{ Hue.Gray, new Color32(0x80, 0x80, 0x80, 0xFF) },
		{ Hue.Yellow, new Color32(0xB0, 0xA5, 0x00, 0xFF) },
	};

	public struct Sfx
	{
		public const string Pull = "Pull";
		public const string Put = "Put";
		public const string Shutter = "Shutter";
		public const string Whistle = "Whistle";
	}

	public struct Events
	{
		public const string TutorialStep = "tutorial_step";
		public const string CoinsFlow = "coins_flow";
		public const string EnergyFlow = "energy_flow";
		public const string ExperienceFlow = "experience_flow";
		public const string QuestStart = "quest_start";
		public const string QuestEnd = "quest_end";
		public const string QuestQuit = "quest_quit";
		public const string PlayerPathCheck = "player_path_check";
		public const string TakePhoto = "take_photo";
		public const string QuitPhoto = "quit_photo";
		public const string WindowOpen = "window_open";
		public const string FirstSessionSteps = "first_session_steps";
	}

	public struct Params
	{
		public const string Id = "id";
		public const string Number = "number";
		public const string Amount = "amount";
		public const string Source = "source";
		public const string QuestId = "quest_id";
		public const string QuestIdRepeat = "quest_id_repeat";
		public const string GoalsAmount = "goals_amount";
		public const string TimeOnRide = "time_on_ride";
		public const string TimeOnTinder = "time_on_tinder";
		public const string EndCondition = "end_condition";
		public const string PathPercent = "path_percent";
		public const string FramesMade = "frames_made";
		public const string FramesBoughtCounter = "frames_bought_counter";
		public const string FrameCurrent = "frame_current";
		public const string QuestgiverSlotsFilled = "questgiver_slots_filled";
		public const string QuestgiverSlotsEmpty = "questgiver_slots_empty";
		public const string ExperienceForSlot = "experience_for_slot";
		public const string ExperienceForFrames = "experience_for_frames";
		public const string ExperienceMaxInTrip = "experience_max_in_trip";
		public const string ExperienceForQuest = "experience_for_quest";
		public const string AverageFpsRiding = "average_fps_riding";
		public const string AverageFpsCamera = "average_fps_camera";
		public const string MinFps = "min_fps";
		public const string CameraInterMethod = "camera_inter_method";
		public const string TakePhotoMethod = "take_photo_method";
		public const string CameraOutMethod = "camera_out_method";
		public const string InCameraTime = "in_camera_time";
		public const string Badges = "badges";
		public const string TotalBadgesCount = "total_badges_count";
		public const string QuestBadgesCount = "quest_badges_count";
		public const string WindowId = "window_id";
		public const string AutoOpen = "auto_open";
		public const string StepName = "step_name";
	}

	public struct Values
	{
		public const string Tester = "tester";
		public const string Cheater = "cheater";
		public const string PathEnd = "path_end";
		public const string OutOfFrames = "out_of_frames";

		public const string Tap = "tap";
		public const string Button = "button";
		public const string TapOnAnimal = "tap_on_animal";
		public const string DoubleTap = "double_tap";
		public const string ZoomIn = "zoom_in";
		public const string ZoomOut = "zoom_out";
		public const string None = "none";
	}

	public struct Sources
	{
		public const string GalleryAchievement = "gallery_achievement";
		public const string Bought = "bought";
		public const string EnergyBought = "energy_bought";
		public const string FramesBought = "frames_bought";
		public const string StartQuest = "start_quest";
		public const string EndQuest = "end_quest";
	}

	public struct UserProperties
	{
		public const string UserLevel = "user_level";
		public const string QuestCounter = "quest_counter";
		public const string UserType = "user_type";
		//public const string AppInfoInstallVersion = "app_info_install_version";
		//public const string GameLanguage = "game_language";
		public const string UserLifetime = "user_lifetime";
		public const string UserPlaytime = "user_playtime";
		public const string EnergyCurrent = "energy_current";
		public const string EnergyCurrentEnough = "energy_current_enough";
		public const string CoinsCurrent = "coins_current";
		public const string ExperienceCurrent = "experience_current";
		public const string UserLevelProgress = "user_level_progress";
		//public const string UserLevelMax = "user_level_max";
	}
}

public enum EvaluationCriterion
{
	Aiming,
	Distance,
	Count,
	Angle,
	Pose
}

public enum Hue
{
	Red,
	Green,
	Blue,
	Gray,
	Yellow,
}

public enum QuestStatus
{
	Locked = 0,
	Available = 1,
	Completed = 2,
}

public enum BadgeAnchorMode
{
	Top = 0,
	Right = 1,
}

public enum UniqueBadgeType
{
	Baby = 1,
	Family = 2,
	Couple = 3,
	WholeInFrame = 4,
	ThreeQuarterView = 5,
	FullFaceView = 6,
	ProfileView = 7,
	BackView = 8,
	CloseUpView = 9,
}

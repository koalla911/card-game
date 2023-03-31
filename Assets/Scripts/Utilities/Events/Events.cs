using System;
using System.Collections.Generic;
using static Game.Control.SwipeManager;

namespace Core.Events
{
	public struct Window_Hide
	{
	}
	public struct Window_Appear
	{
	}
	public struct Window_Show { }

	public struct CompleteGesture
	{
		public CompletedGesture Gesture;

		public CompleteGesture(CompletedGesture gesture)
		{
			Gesture = gesture;
		}
	}

	public struct BalanceChange
	{
	}

	public struct EnergyChange
	{

	}

}
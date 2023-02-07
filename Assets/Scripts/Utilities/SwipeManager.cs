using Core.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Control
{
	public class SwipeManager : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
	{
		public float MinSwipeLength = 4;
		Vector2 _firstPressPos;
		Vector2 _secondPressPos;
		Vector2 _currentSwipe;

		private HashSet<object> lockers = new();
		public bool LockBy(object locker) => lockers.Add(locker);
		public bool UnlockBy(object locker) => lockers.Remove(locker);

		void Update()
		{
			DetectSwipe();
		}

		class GetCardinalDirections
		{
			public static readonly Vector2 Up = new Vector2(0, 1);
			public static readonly Vector2 Down = new Vector2(0, -1);
			public static readonly Vector2 Right = new Vector2(1, 0);
			public static readonly Vector2 Left = new Vector2(-1, 0);
		}


		public void DetectSwipe()
		{
			var swipe = CompletedGesture.BEGIN_JUMP;

#if UNITY_EDITOR
			if (Input.GetMouseButtonDown(0))
			{
				_firstPressPos = Input.mousePosition;
			}
			if (Input.GetMouseButtonUp(0))
			{
				_secondPressPos = Input.mousePosition;
				_currentSwipe = _secondPressPos - _firstPressPos;
			}
			else
			{
				return;
			}
#else
            if (Input.touches.Length > 0)
            {
                Touch t = Input.GetTouch(0);

                switch (t.phase)
                {
                    case TouchPhase.Began:
                        _firstPressPos = t.position;
                        break;
                    case TouchPhase.Ended:
                        _secondPressPos = t.position;
                        _currentSwipe = _secondPressPos - _firstPressPos;
                        break;
                    default:
                        return;
                }

            }
#endif

			Vector2 viewSwipe = new Vector2(_currentSwipe.x / Screen.width, _currentSwipe.y / Screen.height);
			//if (_currentSwipe.magnitude < MinSwipeLength)
			if(viewSwipe.sqrMagnitude < MinSwipeLength * MinSwipeLength || lockers.Count > 0)
			{
				return;
			}

			_currentSwipe.Normalize();
			if (Vector2.Dot(_currentSwipe, GetCardinalDirections.Up) > 0.4f)
			{
				swipe = CompletedGesture.MOVE_UP;
			}
			if (Vector2.Dot(_currentSwipe, GetCardinalDirections.Down) > 0.4f)
			{
				swipe = CompletedGesture.MOVE_DOWN;
			}
			if (Vector2.Dot(_currentSwipe, GetCardinalDirections.Left) > 0.75f)
			{
				swipe = CompletedGesture.MOVE_LEFT;
			}
			if (Vector2.Dot(_currentSwipe, GetCardinalDirections.Right) > 0.75f)
			{
				swipe = CompletedGesture.MOVE_RIGHT;
			}
			EventManager.Fire(new CompleteGesture(swipe));
		}
		public void OnPointerDown(PointerEventData eventData)
		{
			if (lockers.Count > 0)
			{
				return;
			}
			EventManager.Fire(new CompleteGesture(CompletedGesture.BEGIN_JUMP));
		}
		public void OnPointerUp(PointerEventData eventData)
		{
			var secondPress = Input.mousePosition;
			var swipe = (Vector2)secondPress - _firstPressPos;

			if (swipe.magnitude >= MinSwipeLength || lockers.Count > 0)
			{
				return;
			}
			EventManager.Fire(new CompleteGesture(CompletedGesture.MOVE_UP));
		}

		public enum CompletedGesture
		{
			MOVE_UP = 0,
			MOVE_LEFT = 1,
			MOVE_RIGHT = 2,
			BEGIN_JUMP = 3,
			MOVE_DOWN = 4
		}
	}
}

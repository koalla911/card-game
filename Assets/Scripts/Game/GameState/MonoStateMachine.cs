using UnityEngine;

namespace Fancy
{
	public abstract class MonoStateMachine : MonoBehaviour
	{
		public enum ActivationMode
		{
			DisableGameObject,
			DisableComponent
		}
		public virtual ActivationMode GetActivationMode() { return ActivationMode.DisableGameObject; }
	}
	public abstract class MonoStateMachine<T> : MonoStateMachine where T : MonoStateMachine<T> {
		public static T Instance { get; private set; }
		private static T actvateInstance = null;

		public static void Init<TInitialState>() where TInitialState : T
		{
			T[] states = Fancy.Helpers.FindSceneComponents<T>(true);
			TInitialState initialState = null;
			for(int i = 0; i < states.Length; i++)
			{
				if(states[i] is TInitialState && initialState == null)
				{
					initialState = states[i] as TInitialState;
				} else {
					states[i].Deactivate();
				}
			}
			Debug.Assert(initialState != null);
			initialState.Activate();
		}

		public static void Switch<TSpecificState>() where TSpecificState : T
		{
			T newState = Fancy.Helpers.FindSceneComponent<TSpecificState>(true);
			Debug.Assert(newState != null);
			newState.Activate();
		}

		public void Activate()
		{
			actvateInstance = this as T;

			if(GetActivationMode() == ActivationMode.DisableComponent)
			{
				enabled = true;
			} else
			{
				enabled = true;
				gameObject.SetActive(true);
			}
		}

		private void Deactivate()
		{
			if(GetActivationMode() == ActivationMode.DisableComponent)
			{
				enabled = false;
			} else
			{
				gameObject.SetActive(false);
			}
		}

		protected virtual void OnEnable()
		{
			if(actvateInstance != this)
			{
				Debug.LogWarning(typeof(T).ToString() + "." + gameObject.name + " was enabled without calling Switch<State>(). It may have been enabled in just loaded scene hierarchy, which leads to unexpected extra OnEnable/OnDisable calls for state component.", gameObject);
			}

			if(Instance != null && Instance != this)
			{
				Instance.Deactivate();
			}
			Instance = this as T;
			actvateInstance = null;
		}
		protected virtual void OnDisable() {
			if(Instance == this) Instance = null;
		}
	}
}

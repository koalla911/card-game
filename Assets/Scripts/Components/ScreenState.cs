using UnityEngine;

public class ScreenState : MonoBehaviour
{
	private bool quitting;

	private void OnApplicationQuit()
	{
		quitting = true;
	}

	public virtual void Open()
	{
		gameObject.SetActive(true);
	}

	public virtual void Close()
	{
		if (!quitting)
		{
			gameObject.SetActive(false);
		}
	}
}

public class ScreenState<T> : ScreenState where T : View
{
	public T View { get; private set; }

	public override void Open()
	{
		base.Open();
		View = GetComponent<T>();
	}
}

public class View : MonoBehaviour { }
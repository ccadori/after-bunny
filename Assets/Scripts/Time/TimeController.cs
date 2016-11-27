using UnityEngine;
using System.Collections;

public enum TimeState
{
	Slow,
	Normal
}

public class TimeController : MonoBehaviour
{
	private static TimeController singleton;

	// Inspector
	[SerializeField]
	private float slowScale;
	[SerializeField]
	private float normalScale;
	// Inspector

	//private TimeState state;

	void Awake()
	{
		singleton = this;
	}

	void Update()
	{
		
	}

	public static void ChangeState(TimeState newState)
	{
		//singleton.state = newState;

		if (newState == TimeState.Slow) 
		{
			Time.timeScale = singleton.slowScale;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
		} 
		else if (newState == TimeState.Normal) 
		{
			Time.timeScale = singleton.normalScale;
			Time.fixedDeltaTime = 0.02f;
		}	
	}
}

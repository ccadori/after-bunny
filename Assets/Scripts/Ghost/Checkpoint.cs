using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Checkpoint : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private string affectedTag;
	[SerializeField]
	private bool firstCheckpoint;
	// Inspector

	static private volatile Checkpoint lastCheckpoint;
	private Animator anim;
	private bool active;

	void Start()
	{
		anim = GetComponent<Animator> ();
		active = false;

		if (firstCheckpoint)
			Active ();
	}

	void Active()
	{
		if (active)
			return;

		active = true;
		anim.SetBool ("Active", true);
		NewCheckpoint (this);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag (affectedTag))
			Active ();	
	}

	static void NewCheckpoint(Checkpoint checkpoint)
	{
		lastCheckpoint = checkpoint;
	}

	public static Transform GetLastCheckpoint()
	{
		return lastCheckpoint.transform;
	}
}
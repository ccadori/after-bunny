using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private GameObject button;
	// Inspector

	private Animator anim;

	public void Exit()
	{
		Application.Quit ();
	}

	void Awake () 
	{
		anim = GetComponent<Animator> ();
		anim.SetBool ("Open", false);
	}

	public void Open()
	{
		anim.SetBool ("Open", true);
		button.SetActive (false);
	}

	public void Resume()
	{
		anim.SetBool ("Open", false);
		button.SetActive (true);
	}

	public void Restart()
	{
		
	}
}

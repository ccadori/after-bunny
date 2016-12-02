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
        TimeController.ChangeState(TimeState.Slow);
    }

	public void Resume()
	{
		anim.SetBool ("Open", false);
		button.SetActive (true);
        TimeController.ChangeState(TimeState.Normal);
	}

	public void Restart()
	{
        Checkpoint.Restart();
        if (Controller.currentBunny != null)
            Controller.currentBunny.GetComponent<Health>().Kill();
        Resume();
    }
}
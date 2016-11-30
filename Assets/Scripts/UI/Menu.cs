using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private GameObject button;
	// Inspector

	private Animator anim;

	void Awake () 
	{
		anim = GetComponent<Animator> ();
		anim.SetBool ("Open", true);
	}

	public void StartGame()
	{
		anim.SetBool ("Open", false);
		button.SetActive (true);
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
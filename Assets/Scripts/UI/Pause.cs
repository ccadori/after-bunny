using UnityEngine;
using System.Collections;

public class Pause : UIBase 
{
	// Inspector
	[SerializeField]
	private GameObject button;
	// Inspector

	public void Exit()
	{
		Application.Quit ();
	}

    public override void Open()
    {
        base.Open();
        button.SetActive(false);
        MusicVolume.OpenSingleton();
        TimeController.ChangeState(TimeState.Slow);
    }

    public override void Close()
    {
        base.Close();
        button.SetActive(true);
        MusicVolume.CloseSingleton();
        TimeController.ChangeState(TimeState.Normal);
    }

	public void Restart()
	{
        Checkpoint.Restart();
        if (Controller.currentBunny != null)
            Controller.currentBunny.GetComponent<Health>().Kill();
        Close();
    }
}
using UnityEngine;

public class Menu : UIBase 
{
	// Inspector
	[SerializeField]
	private GameObject button;
    // Inspector

    private void Start()
    {
        Open();
        MusicVolume.OpenSingleton();
    }

    public override void Close()
    {
        base.Close();
        button.SetActive(true);
        MusicVolume.CloseSingleton();
    }

    public void Exit()
	{
		Application.Quit ();
	}
}
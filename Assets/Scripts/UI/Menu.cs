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
        Controller.state = GameState.Menu;
    }

    public override void Close()
    {
        base.Close();
        button.SetActive(true);
        MusicVolume.CloseSingleton();
        Controller.state = GameState.Game;
    }

    public void Exit()
	{
		Application.Quit ();
	}
}
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Menu,
    Game,
    Pause
}

public class Controller : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private GameObject bunnyPrefab;
	[SerializeField]
	private float respawnDelay;
	[SerializeField]
	private GameObject deathParticle;
    [SerializeField]
    private float timeToRestart;
    // Inspector

    public static GameObject currentBunny { private set; get; }
    public static GameState state;

    void Start()
	{
        currentBunny = GameObject.FindWithTag("Player");
        SubscribeOnDie ();
        ReachFinal.onFinal += Final;
    }

    void Final()
    {
        Invoke("ReloadGame", timeToRestart);
    }
    
    void ReloadGame()
    {
        SceneManager.LoadScene("Fase1");
    }

	void SubscribeOnDie()
	{
		Health health = currentBunny.GetComponent<Health> ();
		if (health == null) 
		{
			Debug.LogError ("This bunny has no Health!");
			return;
		}

		health.onDie += OnDie;
	}

	void OnDie()
	{
		Instantiate (deathParticle, currentBunny.transform.position, Quaternion.identity);
		Destroy (currentBunny);
		Invoke ("Respawn", respawnDelay);
	}

	void Respawn()
	{
		Vector2 respawnPosition = Checkpoint.GetLastCheckpointPosition();
		currentBunny = Instantiate (bunnyPrefab ,respawnPosition, Quaternion.identity) as GameObject;
		SubscribeOnDie ();
	}
}

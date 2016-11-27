using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private GameObject bunnyPrefab;
	[SerializeField]
	private GameObject currentBunny;
	[SerializeField]
	private float respawnDelay;
	// Inspector

	void Start()
	{
		SubscribeOnDie ();
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
		Destroy (currentBunny);
		Invoke ("Respawn", respawnDelay);
	}

	void Respawn()
	{
		Vector2 respawnPosition = Checkpoint.GetLastCheckpoint ().position;
		currentBunny = Instantiate (bunnyPrefab ,respawnPosition, Quaternion.identity) as GameObject;
		SubscribeOnDie ();
	}
}

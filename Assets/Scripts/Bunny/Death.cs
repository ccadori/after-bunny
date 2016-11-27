using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health), typeof(Rigidbody2D))]
public class Death : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private float delay;
	// Inspector

	private Health health;
	private Rigidbody2D body;

	void Start()
	{
		body = GetComponent<Rigidbody2D> ();
		health = GetComponent<Health> ();
		health.onDie += OnDie;
	}

	void OnDie()
	{
		body.velocity = Vector2.zero;
		health.Restore ();
		transform.position = Checkpoint.GetLastCheckpoint ().position;
	}
}

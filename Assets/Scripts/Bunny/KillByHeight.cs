using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class KillByHeight : MonoBehaviour
{
	// Inspector
	[SerializeField]
	private float minHeight;
	[SerializeField]
	private float maxHeight;
	// Inspector

	private Health health;

	void Start()
	{
		health = GetComponent<Health> ();
	}

	void FixedUpdate()
	{
		if (transform.position.y > maxHeight || transform.position.y < minHeight)
			health.Kill ();
	}
}

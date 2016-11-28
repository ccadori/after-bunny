using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Trap : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private float raycastRange;
	[SerializeField]
	private LayerMask affectedlayers;
	[SerializeField]
	private float timeToReload;
	// Inspector

	private bool closed;
	private Animator anim;

	void Start()
	{
		closed = false;
		anim = GetComponent<Animator> ();
	}

	public void OnClose()
	{
		Invoke ("Open", timeToReload);

		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.up, raycastRange, affectedlayers);

		if (hit.collider == null)
			return; 
		
		Health health = hit.collider.gameObject.GetComponent<Health> ();

		if (health == null) 
		{
			Debug.LogError ("Cant get health from player");
			return;
		}

		health.Kill ();
	}

	public void OnOpen()
	{
		closed = false;
	}

	void Close()
	{
		if (closed)
			return;

		closed = true;
		anim.SetBool ("Closed", closed);
	}

	void Open()
	{
		if (!closed)
			return;
		
		anim.SetBool ("Closed", false);
	}

	void FixedUpdate()
	{
		CheckSomethingOver ();
	}

	void CheckSomethingOver()
	{
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.up, raycastRange, affectedlayers);

		if (hit.collider != null)
			Close ();
	}
}
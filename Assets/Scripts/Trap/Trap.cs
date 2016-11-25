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
		//RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector3.forward, raycastRange, affectedlayers);
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

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag ("Player"))
			Close ();
	}
}
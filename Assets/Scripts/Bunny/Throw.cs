using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Throw : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private LayerMask affectedLayer;
	[SerializeField]
	private float forceMultiplier;
	[SerializeField]
	private float maxForce;
	// Inspector

	private bool pressing;
	private Vector3 startDragging;
	private Rigidbody2D body;

	void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}
	// Update
	void FixedUpdate()
	{
		if (Input.GetAxisRaw ("Fire1") > 0 && !pressing) 
		{
			startDragging = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			TimeController.ChangeState (TimeState.Slow);
			pressing = true;
		} 
		else if (Input.GetAxisRaw ("Fire1") == 0)
		{
			if (pressing) 
			{
				ThrowTarget ();
				pressing = false;
			}

			TimeController.ChangeState (TimeState.Normal);
		}
	}
	// Cast a ray searching for throwable targets
	GameObject Raycast()
	{
		Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero, 1f, affectedLayer);

		if (hit.collider != null)
		{
			return hit.collider.gameObject;
		}
		else 
		{
			return null;	
		}
	}
	// Throw the pressed target
	void ThrowTarget()
	{
		Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 direction = ((Vector2)position - (Vector2)startDragging).normalized;

		float calcForce = forceMultiplier * Vector2.Distance (startDragging, position);
		if (calcForce > maxForce)
			calcForce = maxForce;

		body.velocity = Vector2.zero;
		body.AddForce (direction * calcForce);
	}
}
using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private int maxQuantity;
	[SerializeField]
	private LayerMask affectedLayer;
	[SerializeField]
	private float force;
	// Inspector

	private int currentQuantity;
	private bool pressing;
	private GameObject pressedTarget;

	// Start
	void Start()
	{
		currentQuantity = maxQuantity;
	}
	// Update
	void FixedUpdate()
	{
		if (Input.GetAxisRaw ("Fire1") > 0 && !pressing) 
		{
			if (currentQuantity > 0) 
			{
				pressedTarget = Raycast ();

				if (pressedTarget != null) 
				{
					pressing = true;
					//currentQuantity--;
				}
			}
		} 
		else if (Input.GetAxisRaw ("Fire1") == 0)
		{
			if (pressing) 
			{
				ThrowTarget ();
				pressing = false;
			}
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
		if (pressedTarget == null) 
			return;

		Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 direction = ((Vector2)position - (Vector2)pressedTarget.transform.position).normalized;
		float calcForce = force * Vector2.Distance (pressedTarget.transform.position, position);

		Rigidbody2D body = pressedTarget.GetComponent<Rigidbody2D> ();

		if (body == null) 
		{
			Debug.LogError ("Pressed target does not has RigidBody2D");
			return;
		}

		body.AddForce (direction * calcForce);
	}
}
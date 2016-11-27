using UnityEngine;
using System.Collections;

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
	private GameObject pressedTarget;

	// Update
	void FixedUpdate()
	{
		if (Input.GetAxisRaw ("Fire1") > 0 && !pressing) 
		{
			TimeController.ChangeState (TimeState.Slow);
			pressedTarget = Raycast ();

			if (pressedTarget != null) 
				pressing = true;
		} 
		else if (Input.GetAxisRaw ("Fire1") == 0)
		{
			if (pressing) 
			{
				TimeController.ChangeState (TimeState.Normal);
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
		float calcForce = forceMultiplier * Vector2.Distance (pressedTarget.transform.position, position);
		if (calcForce > maxForce)
			calcForce = maxForce;

		Rigidbody2D body = pressedTarget.GetComponent<Rigidbody2D> ();

		if (body == null) 
		{
			Debug.LogError ("Pressed target does not has RigidBody2D");
			return;
		}

		body.AddForce (direction * calcForce);
	}
}
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class VelocityToRotation : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private bool useScale;
	// Inspector

	private Rigidbody2D body;

	void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (body.velocity.x > 1) 
		{
			if (useScale)
				transform.localScale = new Vector3 (Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);
			else
				transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
		}
		else if (body.velocity.x < -1) 
		{
			if (useScale)
				transform.localScale = new Vector3 (-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
			else
				transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
		}
	}
}

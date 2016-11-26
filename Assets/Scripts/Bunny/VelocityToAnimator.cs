using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class VelocityToAnimator : MonoBehaviour 
{
	// Inspector 
	[SerializeField]
	private bool x;
	[SerializeField]
	private bool y;
	[SerializeField]
	private bool absoluteX;
	[SerializeField]
	private bool absoluteY;
	// Inspector 

	private Animator anim;
	private Rigidbody2D body;	

	void Start()
	{
		anim = GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		if (x) 
		{
			if (absoluteX)
				anim.SetFloat ("VelocityX", Mathf.Abs(body.velocity.x));
			else
				anim.SetFloat ("VelocityX", body.velocity.x);
		}
		if (y) 
		{
			if (absoluteY)
				anim.SetFloat ("VelocityY", Mathf.Abs(body.velocity.y));
			else
				anim.SetFloat ("VelocityY", body.velocity.y);
		}
	}
}

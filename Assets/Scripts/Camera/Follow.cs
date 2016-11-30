using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private float smoothTime;
	[SerializeField]
	private string targetTag;
	[SerializeField]
	private bool reAsign;
	[SerializeField]
	private bool x;
	[SerializeField]
	private bool y;
	// Inspector

	private GameObject target;
	private Vector3 velocity;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag (targetTag);
	}

	void FixedUpdate()
	{
		if (target == null) 
		{
			if (reAsign)
				target = GameObject.FindGameObjectWithTag (targetTag);
			return;
		}

		FollowTarget ();
	}

	void FollowTarget()
	{
		float newX = (x)? target.transform.position.x : transform.position.x ;
		float newY = (y)? target.transform.position.y : transform.position.y ;
		float newZ = transform.position.z;

		transform.position = Vector3.SmoothDamp (transform.position, new Vector3(newX, newY, newZ), ref velocity, smoothTime);
	}
}

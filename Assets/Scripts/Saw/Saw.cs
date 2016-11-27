﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Saw : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	[Range(0, 100)]
	private float spinVelocity;
	// Inspector

	private Rigidbody2D body;

	void Start()
	{
		body = GetComponent<Rigidbody2D> ();
		Spin ();
	}

	void Spin()
	{
		body.AddTorque (spinVelocity * Time.deltaTime * 100);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			Health health = other.gameObject.GetComponent<Health> ();

			if (health == null) 
			{
				Debug.LogError ("Cant get health from player");
				return;
			}

			health.Kill ();
		}
	}
}
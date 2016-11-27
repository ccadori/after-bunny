using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour
{
	// Inspector
	[SerializeField]
	private float timeToDeath;
	// Inspector

	void Start()
	{
		Invoke ("Death", timeToDeath);
	}

	void Death()
	{
		Destroy (gameObject);
	}
}

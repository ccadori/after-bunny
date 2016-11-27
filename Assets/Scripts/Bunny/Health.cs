using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	public int health;
	[SerializeField]
	public bool useAnimator;
	// Inspector

	private int currentHealth;
	private bool alive;
	private Animator anim;

	void Start()
	{
		Restore ();

		if (useAnimator) 
		{
			anim = GetComponent<Animator> ();
			anim.SetBool ("Alive", alive);
		}
	}

	public void Restore()
	{
		alive = true;
		currentHealth = health;	
	}

	public void Damage(int damage)
	{
		currentHealth -= damage;

		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			Kill ();
		}
	}

	public void Kill()
	{
		alive = false;

		Debug.Log (alive);

		if (useAnimator && anim != null)
			anim.SetBool ("Alive", alive);
	}
}
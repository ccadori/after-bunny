using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Throw : MonoBehaviour 
{
	// Inspector
	[SerializeField]
	private LayerMask groundLayer;
	[SerializeField]
	private float forceMultiplier;
	[SerializeField]
	private float maxForce;
	[SerializeField]
	private Vector3[] characterEdges;
	// Inspector

	private bool pressing;
	private Vector2 startDragging;
	private Rigidbody2D body;

	void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}
	// Update
	void FixedUpdate()
	{
		if (Input.GetAxisRaw ("Fire1") > 0 && !pressing && IsOnGround () && !EventSystem.current.IsPointerOverGameObject()) 
		{
            //startDragging = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            startDragging = Input.mousePosition;
            pressing = true;
		} 
		else if (Input.GetAxisRaw ("Fire1") == 0 && pressing && IsOnGround ())
		{
			ThrowTarget ();
			pressing = false;
		}
	}
	bool IsOnGround()
	{
		foreach(Vector3 edge in characterEdges)
		{
			RaycastHit2D hit = Physics2D.Raycast (transform.position + edge, -Vector2.up, 0.5f, groundLayer);
			if (hit.collider != null)
				return true;	
		}

		return false;
	}
	// Throw the pressed target
	void ThrowTarget()
	{
        //Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Vector2 position = Input.mousePosition;
        Vector2 direction = ((Vector2)position - (Vector2)startDragging).normalized;

		float calcForce = forceMultiplier * Vector2.Distance (startDragging, position);
		if (calcForce > maxForce)
			calcForce = maxForce;

		body.velocity = Vector2.zero;
		body.AddForce (direction * calcForce);
	}
}
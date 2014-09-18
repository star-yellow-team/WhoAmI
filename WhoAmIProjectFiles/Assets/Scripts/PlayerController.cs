using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector2 movement;
	public float unitX = 10f;
	public float unitY = 300f;
	private float maxVelocity = 3f;
	private bool goingRight = true;
	private bool jumped;
	private float time;
	private Animator animator;

	void Start () {
		movement.x = 0f;
		movement.y = 0f;
		time = 0f;
		jumped = false;
		animator = GetComponent<Animator> ();
		animator.SetBool ("moving", false);
	}

	void Update () {
		movement.x = movement.y = 0f;
		time += Time.deltaTime;
		ProcessInput ();

		if (movement.x != 0 || movement.y != 0 || jumped)
		{
			animator.SetBool("moving", true);
		}
		else
		{
			animator.SetBool("moving", false);
		}
		
		float velocityX = rigidbody2D.velocity.x;
		float velocityY = rigidbody2D.velocity.y;
		
		transform.localScale = new Vector3(goingRight ? 1 : -1, 1, 1);		
		rigidbody2D.AddForce (new Vector2 (Mathf.Abs(velocityX) < maxVelocity ? movement.x : 0,
											Mathf.Abs(velocityY) < maxVelocity ? movement.y : 0));

	}

	void ProcessInput()
	{
		if (Input.GetKey("d") || Input.GetKey ("right"))
		{
			movement.x += unitX;
			goingRight = true;
		}
		if (Input.GetKey ("a") || Input.GetKey ("left")) 
		{
			movement.x -= unitX;
			goingRight = false;
		}
		if (Input.GetKey ("space"))
		{
			if(!jumped)
			{
				movement.y += unitY;
				jumped = true;
				time = 0f;
			}
			else if(time < 0.6f && time > 0.3f)
			{
				movement.y += unitY/2;
				time = 0.6f;
			}
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		jumped = false;
		time = 0f;
	}
}

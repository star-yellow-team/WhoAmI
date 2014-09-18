using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector2 movement;
	public float mulX = 15f;
	public float mulY = 100f;
	private float unitX = 15f;
	private float unitY = 50f;
	private bool jumped;
	private float time;

	void Start () {
		movement.x = 0f;
		movement.y = 0f;
		time = 0f;
		jumped = false;
	}

	void Update () {
		movement.x = movement.y = 0f;
		time += Time.deltaTime;
		ProcessInput ();
		rigidbody2D.AddForce (new Vector2 (mulX*movement.x, mulY*movement.y));

	}

	void ProcessInput()
	{
		if (Input.GetKey("d") || Input.GetKey ("right"))
		{
			movement.x += unitX;
		}
		if (Input.GetKey ("a") || Input.GetKey ("left")) 
		{
			movement.x -= unitX;
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
				movement.y += unitY;
				time = 2.5f;
			}
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		jumped = false;
		time = 0f;
	}
}

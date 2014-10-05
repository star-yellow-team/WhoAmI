using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour 
{
	public float speed = 10f;
	void Update()
	{
		transform.Rotate (0, 0, Time.deltaTime * 500);
	}
}
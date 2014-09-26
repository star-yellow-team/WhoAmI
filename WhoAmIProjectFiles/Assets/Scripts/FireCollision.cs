using UnityEngine;
using System.Collections;

public class FireCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Debug.Log("foc atins");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D target){
		Debug.Log ("atins");
		if (target.gameObject.tag == "Player")
			Destroy (target.gameObject);

	}
}

using UnityEngine;
using System.Collections;

public class SlowPlatform : MonoBehaviour {

	public float slowAcceleration = 15.0f;
	public float slowSpeed = 4.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
		Debug.Log (col.collider.tag);
		if(col.collider.tag == "Player") {
			Debug.Log ("On the slow platform");
			PlayerController.speed = slowSpeed;
			PlayerController.acceleration = slowAcceleration;
		}
	}
}

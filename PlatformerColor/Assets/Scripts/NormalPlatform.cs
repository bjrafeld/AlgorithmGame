using UnityEngine;
using System.Collections;

public class NormalPlatform : MonoBehaviour {

	public static float normalSpeed = 8f;
	public float normalAcceleration = 30.0f;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision col) {
		Debug.Log (col.collider.tag);
		if(col.collider.tag == "Player") {
			Debug.Log ("On the normal platform");
			PlayerController.acceleration = normalAcceleration;
			PlayerController.speed = normalSpeed;
		}
	}
}

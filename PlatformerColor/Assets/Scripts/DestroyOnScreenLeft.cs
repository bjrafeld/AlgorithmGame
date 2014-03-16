using UnityEngine;
using System.Collections;

public class DestroyOnScreenLeft : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 cameraLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
		if ((transform.position.x + transform.localScale.x) < cameraLeft.x) {
			Destroy(gameObject);
		}
	}
}

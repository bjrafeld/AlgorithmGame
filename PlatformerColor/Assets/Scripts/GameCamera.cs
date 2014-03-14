using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	public float trackSpeed = 10;
	public float cameraAddHeight = 2.0f;

	public float cameraBuffer = 1f;

	private Transform target;

	private PlayerController player;

	void Start() {
	}

	public void SetTarget(Transform t) {
		target = t;
	}

	void Update() {
		if(target) {
			//Restrict too much forward movement
			Vector3 clipRightPoint = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, 0.0f, camera.nearClipPlane));
			float maxRight = clipRightPoint.x;
			transform.Translate( new Vector3(PlayerController.runnerForce,0) * Time.deltaTime);
		}
	}


	float IncrementTowards(float n, float target, float a) {
		if(n == target) {
			return n;
		} else {
			float dir = Mathf.Sign(target - n);
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target - n))? n: target;
		}
	}
}

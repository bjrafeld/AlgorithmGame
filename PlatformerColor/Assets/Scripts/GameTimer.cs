using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public PlatformManager manager;

	public float timer = 120f;

	private float totalTime;

	// Use this for initialization
	void Start () {
		totalTime = timer;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0.0f) {
			Application.LoadLevel("MainMenu");
		}

		if (timer >= (totalTime/4) && timer <= (totalTime/4 + .25f)) {
			LastLevel();
		}
		if (timer >= (totalTime/2) && timer <= (totalTime/2 + .25f)) {
			HalfLevel();
		}
		if (timer >= ((3 * (totalTime/4))) && timer <= ((3 * (totalTime/4)) + .25f)) {
			QuarterLevel();
		}
	}

	void QuarterLevel() {
		Debug.Log ("hit quarter time");
		manager.hazardProbability = .35f;

	}

	void HalfLevel() {
		Debug.Log ("hit half time");
		manager.hazardProbability = .5f;
		PlayerController.runnerForce = 6f;

	}

	void LastLevel() {
		Debug.Log ("hit last time");
		manager.hazardProbability = .85f;
		PlayerController.runnerForce = 8f;
	}
}

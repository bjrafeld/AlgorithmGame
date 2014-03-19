using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public PlatformManager manager;

	public float timer = 120f;
	public float heightBuffer = 10f;

	public float boxHeight = 30f;
	public float boxWidth = 100f;
	public float buttonHeight = 30f;
	public float buttonWidth = 100f;

	private float totalTime;
	private PauseMenu menu;
	private float timeElapsed = 0.0f;
	private bool showScore = false;

	// Use this for initialization
	void Start () {
		totalTime = timer;
		menu = GetComponent<PauseMenu>();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		timeElapsed += Time.deltaTime;
		if (timer <= 0.0f) {
			//displayMenu();
			ShowScore();
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

	void OnGUI() {
		if(showScore) {
			menu.disable ();
			displayMenu();
			float centerPointX = (Camera.main.pixelWidth/2);
			float centerPointY = (Camera.main.pixelHeight/2 - boxHeight/2);
			GUI.Box(new Rect((centerPointX - (1/2)*boxWidth), centerPointY - heightBuffer, boxWidth, boxHeight), "Your Score: "+ (int)timeElapsed);
		}
	}

	void ShowScore() {
		showScore = true;
	}

	void displayMenu() {
		Time.timeScale = 0f;
		float centerPointX = (Camera.main.pixelWidth/2);
		float centerPointY = (Camera.main.pixelHeight/2 - buttonHeight/2);
		if(GUI.Button(new Rect((centerPointX - (1/2)*buttonWidth), centerPointY + heightBuffer, buttonWidth, buttonHeight), "Restart")) {
			Application.LoadLevel("Gary");
		}
	}
}

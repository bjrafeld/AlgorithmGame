using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public float buttonHeight = 30f;
	public float buttonWidth = 100f;

	private bool paused = false;

	private bool enabled = true;

	// Use this for initialization
	public void disable() {
		enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)) {
			paused = !paused;
		}
	}

	void OnGUI() {
		if(enabled) {
			if(paused) {
				displayMenu();
			} else {
				resumeGame();
			}
		}
	}

	public void displayMenu() {
		Time.timeScale = 0f;
		float centerPointX = (Camera.main.pixelWidth/2);
		float centerPointY = (Camera.main.pixelHeight/2 - buttonHeight/2);
		if(GUI.Button(new Rect((centerPointX - (1/2)*buttonWidth), centerPointY, buttonWidth, buttonHeight), "Restart")) {
			Application.LoadLevel("Gary");
		}
	}

	void resumeGame() {
		Time.timeScale = 1f;
	}
}

using UnityEngine;
using System.Collections;

public class MainMenuLayout : MonoBehaviour {

	public float centerSymmetry = 10f;
	public float heightBuffer = 0f;
	public float buttonHeight = 30f;
	public float buttonWidth = 100f;

	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		float centerPointX = (Camera.main.pixelWidth/2);
		float centerPointY = (Camera.main.pixelHeight/2 - buttonHeight/2);
		if(GUI.Button (new Rect(centerPointX - (((3/2)*centerSymmetry) + ((3/2)*buttonWidth)), centerPointY + heightBuffer, buttonWidth, buttonHeight), "Gary")) {
			Debug.Log ("Gary clicked");
			Application.LoadLevel("Gary");
		}

		if(GUI.Button (new Rect(centerPointX + centerSymmetry/2 + (buttonWidth/2), centerPointY + heightBuffer, buttonWidth, buttonHeight), "Buddy")) {
			Debug.Log ("Buddy clicked");
			Application.LoadLevel("Buddy");
		}
	}
}

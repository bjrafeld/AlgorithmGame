using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float timer = 120f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0.0f) {
			Application.LoadLevel("MainMenu");
		}
	}
}

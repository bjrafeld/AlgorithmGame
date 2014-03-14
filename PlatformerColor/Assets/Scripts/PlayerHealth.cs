﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public static int lives = 3;

	public float deathEdge = 1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x;
		if (transform.position.x <= (left + deathEdge)) {
			Debug.Log("Fell and lost a life");
			loseLife();
			Vector3 newPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
			transform.position = newPosition;
		}
	}

	public void loseLife() {
		PlayerHealth.lives -= 1;
		if (PlayerHealth.lives <= 0) {
			gameOverScreen();
		}
	}

	void gameOverScreen() {
		//Load GameOver!!!
	}
	
}
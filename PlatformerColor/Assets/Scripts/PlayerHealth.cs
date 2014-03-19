using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int lives = 3;

	public float deathEdge = 1f;

	private GameTimer timer;

	// Use this for initialization
	void Start () {
		timer = Camera.main.GetComponent<GameTimer>();
	}
	
	// Update is called once per frame
	void Update () {
		float left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x;
		if (transform.position.x <= (left + deathEdge)) {
			Debug.Log("Fell and lost a life");
			loseLife();
		}
	}

	public void loseLife() {
		this.lives -= 1;
		if (this.lives <= 0) {
			gameOverScreen();
		}
		Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .8f, 0));
		Vector3 newPosition = new Vector3(position.x, position.y, 0);
		transform.position = newPosition;
	}

	void gameOverScreen() {
		timer.ShowScore();
	}
	
}

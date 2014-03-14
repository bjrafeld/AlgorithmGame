using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerPhysics))]

public class PlayerController : MonoBehaviour {

	//Player Handling
	public float gravity = 20;
	public float speed = 8.0f;
	public float acceleration = 30.0f;
	public float slowFactor = 2f;

	private float normalAcceleration;
	private float normalSpeed;
	private float slowSpeed;
	private float slowAcceleration;
	public float jumpHeight = 12.0f;
	public static float runnerForce = 5.0f;

	public static float distanceTravelled;

	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;

	private PlayerPhysics playerPhysics;

	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
		normalAcceleration = acceleration;
		normalSpeed = speed;
		slowSpeed = (speed/slowFactor);
		slowAcceleration = (acceleration/slowFactor);
	}
	
	// Update is called once per frame
	void Update () {
		if(playerPhysics.movementStopped) {
			currentSpeed = 0;
			targetSpeed = 0;
		}

		targetSpeed = Input.GetAxisRaw("Horizontal") * this.speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

		if(playerPhysics.grounded) {
			amountToMove.y = 0;
	
			if(Input.GetButtonDown("Jump")) {
				amountToMove.y = jumpHeight;
			}
		}

		amountToMove.x = currentSpeed;
		if(playerPhysics.grounded) {
			//amountToMove.x += runnerForce;
		}
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move (amountToMove * Time.deltaTime);
		distanceTravelled = transform.position.x;
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

	public void slowMovement() {
		this.acceleration = slowAcceleration;
		this.speed = slowSpeed;
	}

	public void normalMovement() {
		this.acceleration = normalAcceleration;
		this.speed = normalSpeed;
	}
}

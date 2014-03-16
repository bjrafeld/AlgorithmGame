using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;

	[HideInInspector]
	public bool grounded;

	[HideInInspector]
	public bool movementStopped;

	private BoxCollider collider;
	private Vector3 size;
	private Vector3 center;
	private PlayerController player;
	private PlayerHealth playerHealth;

	public float skin = .005f;

	public float boundary = 1f;

	Ray ray;
	RaycastHit hit;

	void Start() {
		collider = GetComponent<BoxCollider>();
		player = GetComponent<PlayerController>();
		playerHealth = GetComponent<PlayerHealth>();
		size = collider.size;
		center = collider.center;

	}

	public void Move(Vector2 moveAmount) {

		float deltaX = moveAmount.x;
		float deltaY = moveAmount.y;
		Vector2 playerPosition = transform.position;

		grounded = false;

		for(int i = 0; i<3;i++) {
			float dir = Mathf.Sign(deltaY);
			float x = (playerPosition.x + center.x - size.x/2) + size.x/2 * i;
			float y = playerPosition.y + center.y + size.y/2 * dir;

			ray = new Ray(new Vector2(x, y), new Vector2(0, dir));
			Debug.DrawRay(ray.origin, ray.direction);
			if(Physics.Raycast(ray, out hit, Mathf.Abs(deltaY) + skin, collisionMask)) {
				float distance = Vector3.Distance(ray.origin, hit.point);

				//Stop Player downward movement if comes within skin width of collider
				if(distance > skin) {
					deltaY = distance * dir - skin * dir;
				} else {
					deltaY = 0;
				}

				if (hit.collider.tag == "Normal" && dir == -1) {
					player.normalMovement();
				} else if (hit.collider.tag == "Slow" && dir == -1) {
					player.slowMovement();
				} else if (hit.collider.tag == "Death") {
					Debug.Log ("I see the spikes!!!!! Bleghhhhhh...");
					playerHealth.loseLife();
				}
				grounded = true;
				break;
			}

		}

		movementStopped = false;
		for(int i = 0; i<3;i++) {
			float dir = Mathf.Sign(deltaX);
			float x = playerPosition.x + center.x + size.x/2 * dir;
			float y = playerPosition.y + center.y - size.y/2 + size.y/2 * i;
			
			ray = new Ray(new Vector2(x, y), new Vector2(dir, 0));
			Debug.DrawRay(ray.origin, ray.direction);
			if(Physics.Raycast(ray, out hit, Mathf.Abs(deltaX) + skin, collisionMask)) {
				float distance = Vector3.Distance(ray.origin, hit.point);
				
				//Stop Player downward movement if comes within skin width of collider
				if(distance > skin) {
					deltaX = distance * dir - skin * dir;
				} else {
					deltaX = 0;
				}
				movementStopped = true;
				break;
			}
			
		}

		if(!grounded && !movementStopped) {
			Vector3 playerDirection = new Vector3(deltaX, deltaY);
			Vector3 origin = new Vector3(playerPosition.x + center.x + size.x/2 * Mathf.Sign(deltaX), playerPosition.y + center.y + size.y/2 * Mathf.Sign(deltaY));
			ray = new Ray(origin, playerDirection.normalized);

			if(Physics.Raycast(ray, Mathf.Sqrt((deltaX*deltaX) + (deltaY*deltaY)), collisionMask)) {
				grounded = true;
				deltaY = 0;
			}
		}

		Vector2 finalTransform = new Vector2(deltaX, deltaY);

		transform.Translate(finalTransform);

		//Check if too far right
		float right = (Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0))).x;
		right -= boundary;
		if(transform.position.x >= right) {
			transform.position = new Vector3(right, transform.position.y, transform.position.z);
		}
	}
}

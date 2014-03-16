using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	public Transform prefab;
	public Transform hazardPrefab;
	public int numberOfObjects;
	public float recycleOffset;
	public Vector3 startPosition;
	public Vector3 minSize, maxSize, minGap, maxGap;
	public float minY, maxY;

	public float hazardProbability = 0f;

	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;

	void Start () {
		objectQueue = new Queue<Transform>(numberOfObjects);
		for(int i = 0; i < numberOfObjects; i++){
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}
		nextPosition = startPosition;
		for(int i = 0; i < numberOfObjects; i++){
			Recycle();
		}
	}

	void Update () {
		if(objectQueue.Peek().localPosition.x + recycleOffset < PlayerController.distanceTravelled){
			Recycle();
		}
	}

	private void Recycle () {
		Vector3 scale = new Vector3(
			Random.Range(minSize.x, maxSize.x),
			Random.Range(minSize.y, maxSize.y),
			Random.Range(minSize.z, maxSize.z));

		Vector3 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;

		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		objectQueue.Enqueue(o);

		nextPosition += new Vector3(
			Random.Range(minGap.x, maxGap.x) + scale.x,
			Random.Range(minGap.y, maxGap.y),
			Random.Range(minGap.z, maxGap.z));

		if(nextPosition.y < minY){
			nextPosition.y = minY + maxGap.y;
		}
		else if(nextPosition.y > maxY){
			nextPosition.y = maxY - maxGap.y;
		}

		float lottery = Random.Range (0.0f, 1.0f);
		if (lottery <= hazardProbability) {
			//Calculate Random Size
			float maxHazardSize = hazardProbability * o.localScale.x;
			float hazardSize = Random.Range(1.0f, Mathf.Max(1.0f, maxHazardSize));

			//Calculate random position
			float hazardX = hazardSize/2;
			float oPosition = o.position.x;
			float oSize = o.localScale.x/2;
			float x = Random.Range (((oPosition - oSize) + hazardX), (((oPosition + oSize) - hazardX)));
			float y = o.position.y + o.localScale.y/2 + hazardPrefab.transform.localScale.y/2;
			Vector3 newPosition = new Vector3(x, y, 0.0f);

			//Instantiate and set size
			Transform hazard = Instantiate(hazardPrefab, newPosition, Quaternion.identity) as Transform;
			hazard.localScale = new Vector3(hazardSize, hazard.localScale.y, hazard.localScale.z);
		}

	}
}
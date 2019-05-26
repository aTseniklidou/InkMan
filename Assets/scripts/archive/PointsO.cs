using UnityEngine;
using System.Collections.Generic;

public class PointsO : MonoBehaviour {
	
	public Transform prefab;
	public int numberOfObjects;
	public float recycleOffset;
	public Vector3 startPosition;
	public float size;
	public Vector3 minGap, maxGap;
	public float minY, maxY;
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	public Vector3 velocity;
	private int oldScore, newScore;

	void Start () {
		oldScore = Characterfinal.score;
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

		if (Characterfinal.gamestarted ==true){
			newScore = Characterfinal.score;
			if(objectQueue.Peek().localPosition.x + recycleOffset < Characterfinal.distanceTraveled){	
				
				Recycle();
			}
		}
		else {
			Characterfinal.distanceTraveled = 0;
		}
	}
	
	public void Recycle () {

		if (newScore - oldScore>= 5 && size>0.1) {
			oldScore = newScore;
			size = size - 0.05f;
		}

			Vector3 scale = new Vector3(
				size,
				size,
				0);
			
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
	     }
	
	void OnCollisionEnter2D()
	{
		

		Recycle();
		
	}
}
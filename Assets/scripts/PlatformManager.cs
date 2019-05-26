using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {
	
	public Transform prefab;
	public int numberOfObjects;
	
	public float recycleOffset;
	public Vector3 startPosition;
	public float size_x, size_y;
	public float gap;
	private Vector3 nextPosition;

	private Queue<Transform> objectQueue;
	
	void Start () {
		objectQueue = new Queue<Transform>(numberOfObjects);
		for (int i = 0; i < numberOfObjects; i++) {
						objectQueue.Enqueue ((Transform)Instantiate (prefab));
				}
		nextPosition = startPosition;
		for(int i = 0; i < numberOfObjects; i++){
			Recycle();
		}
	}


	void Update () {

		if (Characterfinal.gamestarted ==true){
			
			if(objectQueue.Peek().position.x + recycleOffset < Characterfinal.distanceTraveled){	
				
				Recycle();
			}
		}
		else {
			Characterfinal.distanceTraveled = 0;
		}

	}
	
	public void Recycle () {
		
		Vector3 scale = new Vector3(
			size_x,
			size_y,
			0);

		
		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.position = nextPosition;
		objectQueue.Enqueue(o);

		nextPosition.x = 
			nextPosition.x + gap + scale.x ;


	}
	
	void OnCollisionEnter2D()
	{
		
		
		Recycle();
		
	}
}
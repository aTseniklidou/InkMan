using UnityEngine;
using System.Collections.Generic;

public class SObst : MonoBehaviour {
	
	public Transform prefab;
	public int numberOfObjects, level1;
	public float recycleOffset;
	public Vector3 startPosition;
	public float size;
	public Vector3 minGap, maxGap;
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	public Vector3 velocity;
	private int oldScore, newScore;
	
	void Start () {
		//prefab.GetComponent<Renderer>().enabled = false;
	//	prefab.GetComponent<Collider2D>().enabled = false;
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
				newScore = Characterfinal.score;
				if (newScore > 5) {
			//prefab.GetComponent<Renderer>().enabled = true;
			//prefab.GetComponent<Collider2D>().enabled = true;
						if ((Characterfinal.gamestarted == true)) {

								if (objectQueue.Peek ().localPosition.x + recycleOffset < Characterfinal.distanceTraveled) {	
				
										Recycle ();
				}
								}
			     else {
	     				Characterfinal.distanceTraveled = 0;
								}
						
				}
		}
	public void Recycle () {
		
		//	if (newScore - oldScore>= 5 && minGap.x >5 && maxGap.x<50 ) {
		//		oldScore = newScore;
		//	size = size - 0.05f;
		//	}
		///

						
		Vector3 scale = new Vector3(
			size,
			size,
			0);
		
		//Vector3 position = nextPosition;
		//position.x += scale.x * 0.5f;
		//position.y += scale.y * 0.5f;
		
		Transform o = objectQueue.Dequeue();
		//prefab.GetComponent<Renderer> ().enabled = true;
		//prefab.GetComponent<Collider2D> ().enabled = true;
		o.localScale = scale;
		o.localPosition = nextPosition;
		objectQueue.Enqueue(o);

			minGap.y=-2.2f;
			maxGap.y=2.2f;
			

		
		nextPosition = new Vector3 (
			nextPosition.x + Random.Range (minGap.x, maxGap.x) + scale.x,
			Random.Range (minGap.y, maxGap.y),
			Random.Range (minGap.z, maxGap.z));
		}
	
	void OnCollisionEnter2D()
	{
		
		
		Recycle();
		
	}
}
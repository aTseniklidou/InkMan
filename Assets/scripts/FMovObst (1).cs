using UnityEngine;
using System.Collections.Generic;

public class FMovObst : MonoBehaviour {
	
	public Transform prefab;
	public int numberOfObjects, upOrDown, level1;
	public float recycleOffset;
	public Vector3 startPosition;
	public float size;
	public Vector3 minGap, maxGap;
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	//public Vector3 velocity;
	private int oldScore, newScore;
	private int  l ;
	
	void Start () {
		l =Application.loadedLevel;
		//	oldScore = Characterfinal.score;
		objectQueue = new Queue<Transform>(numberOfObjects);
		for(int i = 0; i < numberOfObjects; i++){
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}
		nextPosition = GameObject.FindGameObjectWithTag("Player").transform.position+startPosition;
		for(int i = 0; i < numberOfObjects; i++){
			Recycle();
		}
	}
	
	void Update () {
		
		if (Characterfinal.gamestarted == true) {
			newScore = Characterfinal.score;
			//	if (newScore >10 && 
			if (Application.loadedLevel != l) {
				if (objectQueue.Count != 0)
					DestroyO ();
				else 
					Destroy(gameObject);
			} else {
				
				if (objectQueue.Peek ().localPosition.x + recycleOffset < Characterfinal.distanceTraveled) {	
					Recycle ();
				}
				
			}
		}
		else {
			Characterfinal.distanceTraveled = 0;
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
		o.localScale = scale;
		o.localPosition = nextPosition;

//		Vector3 dw = o.transform.TransformDirection(Vector3.down);
//		Vector3 upp = o.transform.TransformDirection(Vector3.up);
//		Vector3 rg = o.transform.TransformDirection(Vector3.right);
//		Vector3 lf = o.transform.TransformDirection(Vector3.left);
//		while (Physics2D.Raycast (o.transform.position, dw, 40) || Physics2D.Raycast (o.transform.position, upp, 40) || Physics2D.Raycast (o.transform.position, lf, 20) || Physics2D.Raycast (o.transform.position, rg, 20)) {
//						nextPosition = new Vector3 (
//				nextPosition.x + Random.Range (minGap.x, maxGap.x) + scale.x,
//				Random.Range (minGap.y, maxGap.y),
//				Random.Range (minGap.z, maxGap.z));
//						o.localPosition = nextPosition;
//						// Recycle();
//						//objectQueue.Enqueue(obj);
//						print ("There is something in front of the object!");
//						//ValidPosition (o);
//				}
//		while(Physics2D2D2D.CircleCast(o.transform.position, 0.5f, Vector2.zero, 0, 1 << LayerMask.NameToLayer("hit")))
//		{
//			nextPosition = new Vector3 (
//				nextPosition.x + Random.Range (minGap.x, maxGap.x) + scale.x,
//				Random.Range (minGap.y, maxGap.y),
//				Random.Range (minGap.z, maxGap.z));
//			o.localPosition = nextPosition;
//		}

		objectQueue.Enqueue(o);
		
		
		//	if (newScore < level1) {
		//	upOrDown = Random.Range(0,2);
		//		if (upOrDown==0){
		//		minGap.y=-2.2f;
		//				maxGap.y=-2.2f;
		//				
		//			}
		//			else {
		//				minGap.y=2.2f;
		//				maxGap.y=2.2f;
		//			}
		//			
		//		}
		//		else {
		minGap.y=-2.2f;
		maxGap.y=2.2f;
		
		//	}
		
		nextPosition = new Vector3 (
			nextPosition.x + Random.Range (minGap.x, maxGap.x) + scale.x,
			Random.Range (minGap.y, maxGap.y),
			Random.Range (minGap.z, maxGap.z));
		//velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
		//previous = transform.position;
		//ValidPosition ();
	}
	
	void DestroyO() 
	{
		Transform o = objectQueue.Dequeue ();
		if ((o.localPosition.x > Characterfinal.distanceTraveled + 20) || (o.localPosition.x < Characterfinal.distanceTraveled - 20)) {
			
			Destroy (o.gameObject);
		} else {
			objectQueue.Enqueue (o);
		}
		
	}
//
//		void ValidPosition(Transform obj) 
//		{
//			Vector3 dw = obj.transform.TransformDirection(Vector3.down);
//			Vector3 upp = transform.TransformDirection(Vector3.up);
//			if (Physics2D2D.Raycast (transform.position, dw, 40) || Physics2D2D.Raycast (transform.position, upp, 40) )
//			     {
//			    // Recycle();
//				objectQueue.Enqueue(obj);
//			     print("There is something in front of the object!");
//			     
//			     }
//			}

	void OnCollisionEnter2D(Collision2D hit)
	{
		
		
		Recycle();
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Recycle ();
	}
	
	
}
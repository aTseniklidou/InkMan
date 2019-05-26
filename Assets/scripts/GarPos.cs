using UnityEngine;
using System.Collections;

public class GarPos : MonoBehaviour {

	public Transform points;

	private Transform obj;

	int num;
	int maxArray;
	
	int  p_min, p_max;
		
	int limit;//, newScore=0;
	
	public float recycleOffset;
	public Vector3 startPosition;
	public float size;
	public Vector3 minGap, maxGap;
	private Vector3 nextPosition;
	
	public Transform[] objs;
	
	void Start () {
	
		p_min = 0;  p_max = p_min+4;

		
		maxArray = p_max + 1;                    //Full objects array                
		
		objs = new Transform [maxArray];
		

		for (int i = p_min; i<=p_max; i++) {
			objs [i] = Instantiate(points);
		}

		limit = p_max+1 ;     //Initialize level 1
		
		nextPosition = startPosition;
		//		for(int i = 0; i <= limit ; i++)
		//			  {
		//				 	Recycle(objs[i]);
		//			  }
	}
	

	// Update is called once per frame
	void Update () {
		
		if (Characterfinal.gamestarted == true) {


			//newScore = Characterfinal.score;
			
         	num = Random.Range (0, limit);     //Still in level1
			
			obj = objs [num];

		if (obj.position.x + recycleOffset < Characterfinal.distanceTraveled)
				Recycle(obj);

			
		} 
		else {
			Characterfinal.distanceTraveled = 0;
		}
		
	}
	
	public void Recycle (Transform o) {
		
		//		if (newScore - oldScore>= 5 && size>0.1) {
		//			oldScore = newScore;
		//			size = size - 0.05f;
		//		}
//		if ((o.tag == "Must")&&(o.position.x!=0)) {
//			Characterfinal.died=true;}

		Vector3 scale = new Vector3(
			size,
			size,
			0);
		
		
		o.localScale = scale;
		o.position = nextPosition;
		
	//	minGap.y=-2.2f;
	//	maxGap.y=2.2f;
		
		
		nextPosition = new Vector3 (
			nextPosition.x + Random.Range (minGap.x, maxGap.x) + scale.x,
			Random.Range (minGap.y, maxGap.y),
			Random.Range (minGap.z, maxGap.z));
	}
}

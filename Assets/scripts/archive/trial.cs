using UnityEngine;
using System.Collections.Generic;

public class trial : MonoBehaviour {

	public Transform obb;
	public Transform mob;
	
	//private Transform obj;
	//	public Transform points;
	//public Transform fObs;
	//public Transform sObs;
	//public Transform vObs;
	//public Transform hObs;
	public Sprite FObs;
	public Sprite SObs;
	public Sprite HObs;
	public Sprite VObs;
	public Sprite ammo;

	
	//private Transform obj;
	private Sprite sprite;

	int num;
	int maxArray;
	
	int a_min, a_max; //, p_min, p_max;
	int f_min, f_max, s_min, s_max;
	int v_min, v_max, h_min, h_max;
	
	public int level2_thres, level3_thres;
	private int limit, newScore=0;
	public int sObjects, mObjects;
	public float recycleOffset;
	public Vector3 startPosition;
	public float size;
	public Vector3 minGap, maxGap;
	private Vector3 nextPosition;
	
	private Sprite[] objspr;

	private Queue<Transform> objectQueue;
	private int upOrDown;


	
	void Start () {
		a_min = 0; 	a_max = a_min;
		//  p_min = a_max + 1;  p_max = p_min+2;
		
		f_min = a_max +1; f_max = f_min;
		s_min = f_max + 1; s_max = s_min;
		
		v_min = s_max + 1; v_max = v_min ;
		h_min = v_max + 1; h_max = h_min ;
		
		maxArray = h_max + 1;                    //Full objects array                
		
		objspr = new Sprite [maxArray];
		
		for (int i = a_min; i<=a_max; i++) {
			objspr [i] = ammo;
		}
		//		for (int i = p_min; i<=p_max; i++) {
		//			objs [i] = Instantiate(points);
		//		}
		//obj = Instantiate(obb);

		for (int i = f_min; i<=f_max; i++) {
			objspr [i] =  FObs;
		}
		for (int i = s_min; i<=s_max; i++) {
			objspr [i] = SObs;
		}
		for (int i = v_min; i<=v_max; i++) {
			objspr [i] = VObs;
		}
		for (int i = h_min; i<=h_max; i++) {
			objspr [i] = HObs;
		}
		
		limit = s_max+1 ;     //Initialize level 1

		objectQueue = new Queue<Transform>(sObjects+mObjects);

		for (int i = 0; i < sObjects; i++) {
			objectQueue.Enqueue ((Transform)Instantiate (obb));
		}
		for (int i = 0; i < mObjects; i++) {
			objectQueue.Enqueue ((Transform)Instantiate (mob));
		}
		
		nextPosition = startPosition;
//		for(int i = 0; i < numberOfObjects; i++){
//			Recycle();
//		}


		//		for(int i = 0; i <= limit ; i++)
		//			  {
		//				 	Recycle(objs[i]);
		//			  }
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Characterfinal.gamestarted == true) {
			
			newScore = Characterfinal.score;
			
			if (newScore >= level3_thres) {  //Move on to level3
				limit = maxArray;
				num = Random.Range (0, limit);
			} 
			else if (newScore >= level2_thres) {  //Move on to level2
				limit = maxArray + (a_max - a_min + 1); 
				num = Random.Range (v_min, limit );
				if (num >= maxArray) {
					num = num - maxArray ; }
			} 
			else	num = Random.Range (0, limit);  //Still in level1
			
			sprite = objspr [num];
			
			if (objectQueue.Peek().position.x + recycleOffset + recycleOffset < Characterfinal.distanceTraveled) {	
			//	if (objectQueue.Peek().
				Recycle (sprite); }
			
		} else {
			Characterfinal.distanceTraveled = 0;
		}
		
	}
	
	public void Recycle (Sprite s) {
		
		//		if (newScore - oldScore>= 5 && size>0.1) {
		//			oldScore = newScore;
		//			size = size - 0.05f;
		//		}
		
		Vector3 scale = new Vector3(
			size,
			size,
			0);
		
		
		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.position = nextPosition;
		objectQueue.Enqueue(o);
		o.GetComponent<SpriteRenderer>().sprite = s;
		        if (s == ammo) {
						o.tag = "Ammo";
			            o.GetComponent<Collider2D>().isTrigger = true;
				} else {
						o.tag = "Obstacle";
						o.GetComponent<Collider2D>().isTrigger = false;
				}





		//	minGap.y=-2.2f;
		//	maxGap.y=2.2f;
		
		
		nextPosition = new Vector3 (
			nextPosition.x + Random.Range (minGap.x, maxGap.x) + scale.x,
			Random.Range (minGap.y, maxGap.y),
			Random.Range (minGap.z, maxGap.z));
	}


}

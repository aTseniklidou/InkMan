using UnityEngine;
using System.Collections;

public class AllObjs : MonoBehaviour {
	
	public Transform ammo;
	public Transform points;
	public Transform fObs;
	public Transform sObs;
	public Transform vObs;
	public Transform hObs;
	private Transform obj;
	
	int num;
	int maxArray;
	
	int a_min, a_max, p_min, p_max;
	int f_min, f_max, s_min, s_max;
	int v_min, v_max, h_min, h_max;
	
	public int level2_thres, level3_thres;
	int limit, newScore=0;
	
	public float recycleOffset;
	public Vector3 startPosition;
	public float size;
	public Vector3 minGap, maxGap;
	private Vector3 nextPosition;
	
	public Transform[] objs;
	
	void Start () {
		a_min = 0; 	a_max = a_min+1;
		p_min = a_max + 1;  p_max = p_min+2;
		
		f_min = p_max + 1; f_max = f_min+1;
		s_min = f_max + 1; s_max = s_min+1;
		
		v_min = s_max + 1; v_max = v_min + 1;
		h_min = v_max + 1; h_max = h_min + 1;
		
		maxArray = h_max + 1;                    //Full objects array                
		
		objs = new Transform [maxArray];
		
		for (int i = a_min; i<=a_max; i++) {
			objs [i] = Instantiate (ammo);
		}
		for (int i = p_min; i<=p_max; i++) {
			objs [i] = Instantiate(points);
		}
		for (int i = f_min; i<=f_max; i++) {
			objs [i] = Instantiate(fObs);
		}
		for (int i = s_min; i<=s_max; i++) {
			objs [i] = Instantiate(sObs);
		}
		for (int i = v_min; i<=v_max; i++) {
			objs [i] = Instantiate(vObs);
		}
		for (int i = h_min; i<=h_max; i++) {
			objs [i] = Instantiate(hObs);
		}
		
		limit = s_max+1 ;     //Initialize level 1
		
		nextPosition = startPosition;
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
				limit = maxArray; 
				num = Random.Range (v_min, maxArray + (p_max - a_min + 1));
				if (num >= maxArray) {
					num = num - maxArray ; }
			} 
			else	num = Random.Range (0, limit);  //Still in level1
			
			obj = objs [num];
			
			if (obj.localPosition.x + recycleOffset < Characterfinal.distanceTraveled) {	
				Recycle (obj); }
			
		} else {
			Characterfinal.distanceTraveled = 0;
		}
		
	}
	
	public void Recycle (Transform o) {
		
		//		if (newScore - oldScore>= 5 && size>0.1) {
		//			oldScore = newScore;
		//			size = size - 0.05f;
		//		}
		
		Vector3 scale = new Vector3(
			size,
			size,
			0);
		
		
		o.localScale = scale;
		o.localPosition = nextPosition;
		
		minGap.y=-2.2f;
		maxGap.y=2.2f;
		
		
		nextPosition = new Vector3 (
			nextPosition.x + Random.Range (minGap.x, maxGap.x) + scale.x,
			Random.Range (minGap.y, maxGap.y),
			Random.Range (minGap.z, maxGap.z));
	}
}
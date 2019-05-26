using UnityEngine;
using System.Collections;

public class ArrayObj : MonoBehaviour {

	public Transform ammo;
	public Transform points;
	public Transform fObs;
	public Transform sObs;
	public Transform vObs;
	public Transform hObs;
	private Transform obj;

	int num;
	int maxArray =10;
	int a_min = 0, a_max = 2;
	int p_min = 3, p_max = 5;
	int f_min = 6, f_max = 7;
	int s_min = 8, s_max = 9;

	public float recycleOffset;
	public Vector3 startPosition;
	public float size;
	public Vector3 minGap, maxGap;
	private Vector3 nextPosition;

	public Transform[] objs;
	
	void Start () {
		objs = new Transform [maxArray];
		objs [0] = ammo;
		objs [1] = ammo;
		objs [2] = ammo;
		objs [3] = points;
		objs [4] = points;
		objs [5] = points;
		objs [6] = fObs;
		objs [7] = fObs;
		objs [8] = sObs;
		objs [9] = sObs;
		//objs [4] = vObs;
		//objs [5] = hObs;
	}
	
	// Update is called once per frame
	void Update () {
		num = Random.Range (0, maxArray+1);
		if (a_min <= num && num <= a_max) {
						obj = ammo;
				} else if (p_min <= num && num <= p_max) {
						obj = points;
				} else if (f_min <= num && num <= f_max) {
						obj = fObs;
				} else
						obj = sObs;


		if (Characterfinal.gamestarted == true) {

//			if (Application.loadedLevel != l) {
//     			for(int i = 0; i < Objs.Length; i++)
//				  {
//				 	Destroy(Objs[i].gameObject);
//				  }
//			}
			// else {
				
				if (obj.localPosition.x + recycleOffset < Characterfinal.distanceTraveled) {	
					Recycle (obj);
				}
//				
//			}
//		}
		else {
			Characterfinal.distanceTraveled = 0;
		}


}
}

	public void Recycle (Transform o) {

		Vector3 scale = new Vector3(
			size,
			size,
			0);
		
		//Vector3 position = nextPosition;
		//position.x += scale.x * 0.5f;
		//position.y += scale.y * 0.5f;

		o.localScale = scale;
		o.localPosition = nextPosition;

		minGap.y=-2.2f;
		maxGap.y=2.2f;
		
		//	}
		
		nextPosition = new Vector3 (
			nextPosition.x + Random.Range (minGap.x, maxGap.x) + scale.x,
			Random.Range (minGap.y, maxGap.y),
			Random.Range (minGap.z, maxGap.z));
	}
}
using UnityEngine;
using System.Collections;

public class NarPos : MonoBehaviour {
	
	public Transform points;
	
	private Transform obj;
	private int num, maxArray;
	
	private int  p_min, p_max;
	public int quantity; 
	
	public float recycleOffset; //how far back should the obj be to recycle
	public Vector3 startPosition; //posiion of the first obj
	public float size;   
	public Vector3 minGap, maxGap;  //offset at x and y axis
	private Vector3 nextPosition;
	
	private Transform[] objs; //array of objects
	
	
	void Start () {
		
		p_min = 0;  p_max = p_min+quantity-1; //calculate the amount of objects based on the quantity provided
		
		
		maxArray = p_max + 1;                                
		
		objs = new Transform [maxArray];   //Initialize array  
		
		
		for (int i = p_min; i<=p_max; i++) {
			objs [i] = Instantiate(points);
		}   
		
		nextPosition = startPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Characterfinal.gamestarted == true) {
			
						num = Random.Range (0, maxArray);   
			
						obj = objs [num];

			
						if (obj.position.x + recycleOffset < Characterfinal.distanceTraveled) {	
								Recycle (obj);
						}
			
				} else {
						Characterfinal.distanceTraveled = 0;
				}
	}
	
	public void Recycle (Transform o) {
		Vector3 scale = new Vector3(
			size,
			size,
			0);
		o.localScale = scale;
		o.position = nextPosition;			
		nextPosition = new Vector3 (
			nextPosition.x + Random.Range (minGap.x, maxGap.x) + scale.x,
			Random.Range (minGap.y, maxGap.y),
			Random.Range (minGap.z, maxGap.z));
	}
}

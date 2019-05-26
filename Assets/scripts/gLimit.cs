using UnityEngine;
using System.Collections;

public class gLimit : MonoBehaviour {

	public static int diff;

	// Use this for initialization
	void Start () {
		diff = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//print (diff);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		
		if((col.gameObject.tag == "Obstacle"))
		{
			diff++;
			//print (diff);
			
		}
		
	}

}

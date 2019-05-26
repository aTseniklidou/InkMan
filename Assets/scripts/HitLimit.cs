using UnityEngine;
using System.Collections;

public class HitLimit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Collider2D>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Characterfinal.died == true) {
			GetComponent<Collider2D>().enabled = false;
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{

		if((col.gameObject.tag == "Obstacle"))
		{
			Characterfinal.score++;

		}
		if(col.gameObject.tag == "Must")
		{
			Characterfinal.dead = true;
		//	Characterfinal.gamestarted = false;
			
		}
		
	}


}

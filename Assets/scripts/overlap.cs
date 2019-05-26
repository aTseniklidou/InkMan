using UnityEngine;
using System.Collections;

public class overlap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{  float pos = transform.position.x;
		float posy = transform.position.y;
		transform.position = new Vector3(pos+5,posy,0);
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}

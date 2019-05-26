using UnityEngine;
using System.Collections;

public class targetcam : MonoBehaviour {

	public Transform target;
	public float x;
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(target.position.x + x,transform.position.y,transform.position.z) ;
	
	}
}

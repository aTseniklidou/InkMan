using UnityEngine;
using System.Collections;

public class stains : MonoBehaviour {


	//private Animator anim;	


	public Transform target;
	public float x,y;
	
	// Use this for initialization
	void Awake () {
	//	anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
				if (Characterfinal.gamestarted) {
						GetComponent<SpriteRenderer> ().enabled = true;
						GetComponent<Animator> ().enabled = true;
				}
				if (Characterfinal.died) {
						GetComponent<SpriteRenderer> ().enabled = false;
						GetComponent<Animator> ().enabled = false;
				}
		}


	void LateUpdate () {

		transform.position = new Vector3(target.position.x + x,target.position.y+y,transform.position.z) ;
		
	}
}

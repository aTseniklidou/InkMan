using UnityEngine;
using System.Collections;

public class P_moving : MonoBehaviour {
	public int level2_thres, level3_thres;
	int num;
	private Rigidbody2D rb;
	private int upOrDown;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
				if (Characterfinal.score >= level3_thres) { //move to level 3
						if (transform.position.x == 0) {
								num = Random.Range (0, 3); //randomly pick type of movement
								if (num == 2) {
										upOrDown = Random.Range (0, 2); //starting direction up or down for vertical 
										if (upOrDown == 0) {
												rb.velocity = new Vector3 (0, -2, 0);
										} else 
												rb.velocity = new Vector3 (0, 2, 0);
								}
						} else { 
								if (num == 0) {
										Horizontal ();
								} else {
										Vertical ();
								}
		         
						}
				} else if (Characterfinal.score >= level2_thres) { //move to level 2
						if (transform.position.x == 0) {
								num = Random.Range (0, 3);
								if (num == 2) {
										upOrDown = Random.Range (0, 2);
										if (upOrDown == 0) {
												rb.velocity = new Vector3 (0, -2, 0);
										} else 
												rb.velocity = new Vector3 (0, 2, 0);
								}
						} else { 
								if (num == 0) {
										Zero ();
								} else if (num == 1) {
										Horizontal ();
								} else {
										Vertical ();
								}
						}
				} else  //still on level 1
						Zero ();
		}

	void Horizontal(){   //horizontal movement
	rb.velocity = new Vector3(-1, 0, 0);
	rb.angularVelocity = 100;

		}
	
	void Vertical(){  //vertical movement

			if (transform.position.y > 2.2) {  //do not exceed the horizontal borders
				rb.velocity = new Vector3 (0, -2, 0);
			}
			
			else if (transform.position.y <-2.2  ){
				rb.velocity = new Vector3 (0, 2, 0);}
			
			rb.angularVelocity = 100;
			
		}
	  
	void Zero(){  //stay still
	   rb.velocity = new Vector3(0, 0, 0);
	   rb.angularVelocity = 0;
		}
}

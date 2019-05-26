using UnityEngine;
using System.Collections;

public class V_movement : MonoBehaviour {
	private Rigidbody2D rb;
	private int upOrDown;
	
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		upOrDown = Random.Range (0, 2);
		if (upOrDown ==0)
			rb.velocity = new Vector3 (0, -2, 0);
		else 
			rb.velocity = new Vector3 (0, 2, 0);
	}
	void FixedUpdate() {
		if (transform.position.y > 2.2) {
						rb.velocity = new Vector3 (0, -2, 0);
				}

		else if (transform.position.y <-2.2  ){
			rb.velocity = new Vector3 (0, 2, 0);}

		rb.angularVelocity = 100;
		
	}
}

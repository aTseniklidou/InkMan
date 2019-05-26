using UnityEngine;
using System.Collections;

public class H_movement : MonoBehaviour {
	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate() {
			rb.velocity = new Vector3(-3, 0, 0);
		rb.angularVelocity = 100;
		
	}
}
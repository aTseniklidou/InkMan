using UnityEngine;
using System.Collections;

public class asp_ratio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//	Camera cam = GetComponent<Camera>();
		Camera.main.aspect = 600f/800f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

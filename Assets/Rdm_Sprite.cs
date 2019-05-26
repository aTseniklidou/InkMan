using UnityEngine;
using System.Collections;

public class Rdm_Sprite : MonoBehaviour {
	public Sprite FObs;
	public Sprite SObs;
	private int choice;
	// Use this for initialization
	void Start () {
		choice = Random.Range (0, 2);
		if (choice == 0) {
						GetComponent<SpriteRenderer>().sprite = FObs;
				}
		else {

			GetComponent<SpriteRenderer>().sprite = SObs;
				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

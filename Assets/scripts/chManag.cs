using UnityEngine;
using System.Collections;

public class chManag : MonoBehaviour {

	public Canvas deathWind;

	// Use this for initialization
	void Start () {
		deathWind.enabled = false;
	}
	
	// Update is called once per frame
	public void pAgain() {
	//	deathWind.enabled = false;
		Application.LoadLevel (Application.loadedLevel);
		
	}

	public void Quit() {
		Application.Quit();
	}

	public void Menu() {
		
		Application.LoadLevel("Main");
	}

}

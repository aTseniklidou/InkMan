using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getAmmo : MonoBehaviour {

	Text text;                      // Reference to the Text component.
	
	
	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();
		
		// Reset the score.
	}
	
	
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Ammo:" + Characterfinal.ammo;
	}
}

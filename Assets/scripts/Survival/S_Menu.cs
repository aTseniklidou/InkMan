using UnityEngine;
using System.Collections;

public class S_Menu : MonoBehaviour {


	public Rect windowRect;// = new Rect(100, 100, 400, 200);
	public GUIStyle windStyle,bStyle, sStyle;
	AudioSource source;
	public AudioClip flipSound;
	public Vector3 correct = new Vector3(1,0,0);
	public bool playAgain;

	
	void Start () {
		source = GetComponent<AudioSource>();
		Characterfinal.startgame = false;
		if (playAgain == false) {
			source.PlayOneShot (flipSound, 1.0f);
		}

	}
	
	
	void OnGUI() {
		windowRect = new Rect(Screen.width/2 - 250, Screen.height/2 - 150, 500, 300);
		if (Characterfinal.died==true){
			windowRect = GUI.Window(0, windowRect, EndWindow, "Your Score: "+ Characterfinal.score,windStyle);
			//	obj.GetComponent<Renderer>().enabled = false;
			
		}
		if (Characterfinal.startgame==false){
			windowRect = GUI.Window(0, windowRect, StartWindow, "Gravity Man",windStyle);
			//	obj.GetComponent<Renderer>().enabled = false;
		}
	}
	
	void StartWindow(int windowID) {
		if (GUI.Button (new Rect (Screen.width / 2 - 370, Screen.height / 2 - 140, 140, 110), "Start", sStyle)) {
			Application.LoadLevel ("survival_1");
		}
		if (GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-110, 300, 100), "How To Play",bStyle))
		{}
		if (GUI.Button(new Rect(Screen.width/2-370,Screen.height/2-40, 140, 110), "Quit",sStyle))
			Application.Quit();
	}
	
	void EndWindow(int windowID) {
		if (GUI.Button(new Rect(Screen.width/2-395, Screen.height/2-140, 300, 100), "Play Again",bStyle))
		{    
			Application.LoadLevel("survival_1");}
		
		if (GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-60, 300, 100), "Main Menu",bStyle))
		{
			Application.LoadLevel("S_Main");}
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}

using UnityEngine;
using System.Collections;

public class level_manager : MonoBehaviour {


	//private Animator anim;					// Reference to the player's animator component.
	public Rect windowRect, modeRect;// = new Rect(100, 100, 400, 200);
	public GUIStyle windStyle,modeStyle;
	public GUIStyle bStyle, sStyle, mStyle;
	AudioSource source;
	public AudioClip flipSound;
	//public Quaternion correct = new Quaternion(0,0,0,0);
	public Vector3 correct = new Vector3(1,0,0);
	public bool playAgain;
	// Use this for initialization
	//Characterfinal obj;
	private int i;
	public GameObject[] gameObjs ;
	private bool modeWindON = false;
	private int loadLevel = 0;

	void Awake()
	{   
		source = GetComponent<AudioSource>();
	//	anim = GetComponent<Animator>();
		
		
	}
	void Start () {

		DontDestroyOnLoad(transform.gameObject);
		Application.LoadLevel ("Main");
//		if (Characterfinal.startgame == false) {
//						source.PlayOneShot (flipSound, 1.0f);
//				}

		}


	void OnGUI() {
		windowRect = new Rect(Screen.width/2 - 250, Screen.height/2 - 150, 500, 300);
		if (Characterfinal.died==true){
			windowRect = GUI.Window(0, windowRect, EndWindow, "Your Score: "+ Characterfinal.score,windStyle);

		}
		if (Characterfinal.startgame==false){
			windowRect = GUI.Window(0, windowRect, StartWindow, "Gravity Man",windStyle);
	
		}
		if (modeWindON == true) {
						windowRect = GUI.Window (0, windowRect, ModeWindow, "Choose Mode", modeStyle);
				}
	}

	void StartWindow(int windowID) {
		if (GUI.Button (new Rect (Screen.width / 2 - 370, Screen.height / 2 - 140, 140, 110), "Start", sStyle)) {
			           Characterfinal.startgame =true;
			        if (loadLevel==0){
				Application.LoadLevel ("G_Level");}
			        else if (loadLevel==1){
				Application.LoadLevel ("S_Level");}
			        else {
				Application.LoadLevel ("N1L_Level");}
				}

		if (GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-110, 300, 100), "How To Play",bStyle)){


		}

		if (GUI.Button(new Rect(Screen.width/2-370,Screen.height/2-40, 140, 110), "Quit",sStyle))
			Application.Quit();
		if (GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-90, 300, 150), "Change Mode",bStyle))
		{modeWindON = true;}
	}
	
	void EndWindow(int windowID) {

		if (GUI.Button(new Rect(Screen.width/2-395, Screen.height/2-140, 300, 100), "Play Again",bStyle))
		{    

			if (loadLevel==0){
				Application.LoadLevel ("G_Level");}
			else if (loadLevel==1){
				Application.LoadLevel ("S_Level");}
			else {
				Application.LoadLevel ("N1L_Level");}
		}
		
		if (GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-60, 300, 100), "Main Menu",bStyle))
		{

			Characterfinal.startgame =false;
			source.PlayOneShot (flipSound, 1.0f);
			Application.LoadLevel("Main");}
	}

	void ModeWindow(int modeID) {
		if (GUI.Button(new Rect(Screen.width/2-395, Screen.height/2-140, 300, 100), "Greedy Mode",mStyle))
		{    
			modeWindON=false;
			loadLevel = 0;
			Application.LoadLevel("G_Level");
			}
		if (GUI.Button(new Rect(Screen.width/2-410, Screen.height/2-140, 300, 100), "Survival Mode",mStyle))
		{    
			modeWindON=false;
			loadLevel = 1;
			Application.LoadLevel("S_Level");
			}
		if (GUI.Button(new Rect(Screen.width/2-395, Screen.height/2-100, 300, 100), "Not-One-Less Mode",mStyle))
		{    
			modeWindON=false;
			loadLevel = 2;
			Application.LoadLevel("N1L_Level");
			}

	}
	
}

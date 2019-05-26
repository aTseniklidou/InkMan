using UnityEngine;
using System.Collections;

public class g_manager : MonoBehaviour {
	
				// Condition for whether the player should jump.	
	//public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	//public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	//private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
	public Rect windowRect;// = new Rect(100, 100, 400, 200);
	public GUIStyle windStyle,bStyle, sStyle;
	AudioSource source;
	public AudioClip flipSound;
	//public Quaternion correct = new Quaternion(0,0,0,0);
	public Vector3 correct = new Vector3(1,0,0);
	public bool playAgain;
	// Use this for initialization
	//Characterfinal obj;
	private int i;
	public GameObject[] gameObjs ;
	public static bool restart;

	void Awake()
	{   
		//gameObject.GetComponent<Renderer>().enabled = false;
		source = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		
		
	}
	void Start () {
		restart = false;
		//DontDestroyOnLoad(transform.gameObject);
		if (Characterfinal.startgame == false) {
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
			           Characterfinal.startgame =true;
						Application.LoadLevel ("greedy_1");
				}
		if (GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-110, 300, 100), "How To Play",bStyle))
		{}
		if (GUI.Button(new Rect(Screen.width/2-370,Screen.height/2-40, 140, 110), "Quit",sStyle))
			Application.Quit();
		if (GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-110, 300, 150), "Change Mode",bStyle))
		{}
	}
	
	void EndWindow(int windowID) {

		if (GUI.Button(new Rect(Screen.width/2-395, Screen.height/2-140, 300, 100), "Play Again",bStyle))
		{    
			DeleteAll();
		    restart = true;
			Application.LoadLevel("greedy_1");}
		
		if (GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-60, 300, 100), "Main Menu",bStyle))
		{

			Characterfinal.startgame =false;
			DeleteAll();

			gameObjs =  GameObject.FindGameObjectsWithTag ("Kill");
			for(i = 0 ; i < gameObjs.Length ; i ++)
				Destroy(gameObjs[i]);

			restart = true;
			Application.LoadLevel("G_Main");}
	}

	void DeleteAll(){
		
		gameObjs =  GameObject.FindGameObjectsWithTag ("Platform");
		for(i = 0 ; i < gameObjs.Length ; i ++)
			Destroy(gameObjs[i]);
		gameObjs =  GameObject.FindGameObjectsWithTag ("Obstacle");
		for(i = 0 ; i < gameObjs.Length ; i ++)
			Destroy(gameObjs[i]);
		gameObjs =  GameObject.FindGameObjectsWithTag ("Player");
		for(i = 0 ; i < gameObjs.Length ; i ++)
			Destroy(gameObjs[i]);
		gameObjs =  GameObject.FindGameObjectsWithTag ("Points");
		
		for(i = 0 ; i < gameObjs.Length ; i ++)
			Destroy(gameObjs[i]);
		gameObjs =  GameObject.FindGameObjectsWithTag ("Ammo");
		
		for(i = 0 ; i < gameObjs.Length ; i ++)
			Destroy(gameObjs[i]);
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((Application.loadedLevel ==1) &&(Characterfinal.score >=10)) {
			Application.LoadLevel("greedy_2");}
		if ((Application.loadedLevel ==2) &&(Characterfinal.score >=20)) {
			Application.LoadLevel("greedy_3");}
	}
}

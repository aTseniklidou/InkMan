using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class LevManager : MonoBehaviour {


	public Canvas modeWind;
	public Canvas tutWind;
	//public Canvas mainWind;
	//private Animator anim;					// Reference to the player's animator component.
	public Text ctr_tut;
	public Text s_tut, g_tut, n_tut;
	public Text guide;
		AudioSource source;
	public AudioClip flipSound;

	private static int loadLevel;


	void Awake()
	{   
		source = GetComponent<AudioSource>();
		//	anim = GetComponent<Animator>();
		//loadLevel = 0;
		print (loadLevel);
		
	}
	void Start () {
	//	modeWind.enabled = false;
	//	deathWind.enabled = false;
	//	mainWind.enabled = true;
		
	}


	 public void Play() {
		//	Characterfinal.startgame =true;
	//	mainWind.enabled = false;
		if (loadLevel==0){
				Application.LoadLevel ("G_Level");}
			else if (loadLevel==1){
				Application.LoadLevel ("S_Level");}
			else {
				Application.LoadLevel ("N1L_Level");}
	//	 theMenu.enabled = false;
		}

	public void HtP() {
		source.PlayOneShot (flipSound, 1.0f);
		tutWind.enabled = true;
		guide.GetComponent<Text>().enabled = true;

		n_tut.GetComponent<Text>().enabled = false;
		ctr_tut.GetComponent<Text>().enabled = false;
		s_tut.GetComponent<Text>().enabled = false;
		g_tut.GetComponent<Text>().enabled = false;


		}

	public void ChangeMode() {
		source.PlayOneShot (flipSound, 1.0f);
		modeWind.enabled = true;

	}
	public void Menu() {
		Application.LoadLevel("Main");
	}


	public void Quit() {
		Application.Quit();
	}
	
	public void back(){
				source.PlayOneShot (flipSound, 1.0f);
				modeWind.enabled = false;
		        tutWind.enabled = false;
	}
	
	
	public void G_Mode() {  
			loadLevel = 0;
		    modeWind.enabled = false;
		source.PlayOneShot (flipSound, 1.0f);
		}

	public void S_Mode() { 
			loadLevel = 1;
	     	modeWind.enabled = false;
		source.PlayOneShot (flipSound, 1.0f);
		}
	

	public void N1L_Mode() { 
			loadLevel = 2;
		    modeWind.enabled = false;
		source.PlayOneShot (flipSound, 1.0f);
		}

	public void N_Tut(){
		n_tut.GetComponent<Text>().enabled = true;
		guide.GetComponent<Text>().enabled = false;

		ctr_tut.GetComponent<Text>().enabled = false;
		s_tut.GetComponent<Text>().enabled = false;
		g_tut.GetComponent<Text>().enabled = false;
	}

	public void S_Tut(){
		s_tut.GetComponent<Text>().enabled = true;
		guide.GetComponent<Text>().enabled = false;
		n_tut.GetComponent<Text>().enabled = false;
		ctr_tut.GetComponent<Text>().enabled = false;

		g_tut.GetComponent<Text>().enabled = false;
	}
	public void G_Tut(){
		g_tut.GetComponent<Text>().enabled = true;
		guide.GetComponent<Text>().enabled = false;
		n_tut.GetComponent<Text>().enabled = false;
		ctr_tut.GetComponent<Text>().enabled = false;
		s_tut.GetComponent<Text>().enabled = false;

		
	}
	public void Ctr_Tut(){
		ctr_tut.GetComponent<Text>().enabled = true;
		guide.GetComponent<Text>().enabled = false;
		n_tut.GetComponent<Text>().enabled = false;

		s_tut.GetComponent<Text>().enabled = false;
		g_tut.GetComponent<Text>().enabled = false;
	}
		

}

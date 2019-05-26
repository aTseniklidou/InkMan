using UnityEngine;
using System.Collections;

public class Characterfinal : MonoBehaviour
{ 
	public Canvas deathWind;
	public static int score = 0;
	public static int ammo = 0;
	private int combo = 0;
	public GUIText scoreText;
	public GUIText ammoText;
	public static bool died = false;				

	private Animator anim;					// Reference to the player's animator component.
	public static bool gamestarted = false;
	public static bool startgame = false;
	private bool isdown = true;
	private bool iskeydown1 =false;
	private bool iskeydown2 =false;
	private Vector2 char_velocity;
	public static float distanceTraveled;

	public Rect windowRect;// = new Rect(100, 100, 400, 200);

	public int bulletSpeed = 20;
	public Rigidbody2D bullet;

	AudioSource source;
	public AudioClip deathSound;
	public AudioClip flipSound;
	public AudioClip fireSound;
	public AudioClip ammoSound;
	public AudioClip pointSound;

	public static bool dead = false;
	private Vector3 correct = new Vector3(1,0,0);
	private Vector3 stop = new Vector3(0,0,0);

	void Awake()
	{   

		source = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();	    

	}
	//the game start
	void Start()
	{
		died = false;
		dead = false;
		gamestarted = false;
		score = 0;
		ammo = 0;
			
	}

	void OnCollisionEnter2D(Collision2D hit)
	{

		if(hit.gameObject.tag == "Obstacle")
		{
			dead = true;

		}

	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if(col.gameObject.tag == "Points")
		{
			source.PlayOneShot(pointSound,1.0f);
			col.gameObject.transform.position = new Vector3(0, 0, 0);
			combo++;
			score=score+combo;
			scoreText.text = "Score: " + score;


		}
		if(col.gameObject.tag == "Must")
		{
			source.PlayOneShot(pointSound,1.0f);
			col.gameObject.transform.position = new Vector3(0, 0, 0);
			score++;
			scoreText.text = "Score: " + score;
			
			
		}

		else if(col.gameObject.tag == "Ammo")
		{
			source.PlayOneShot(ammoSound,1.0f);
			col.gameObject.transform.position = new Vector3(0, 0, 0);
			ammo++;
			combo = 0;
			ammoText.text = "Ammo: " + ammo;
			
			
		}
	}
	

	void Fire()
	{
		source.PlayOneShot(fireSound,1.0f);

	Rigidbody2D bulletClone = (Rigidbody2D) Instantiate(bullet, transform.position+correct, transform.rotation);
		bulletClone.velocity = transform.right * bulletSpeed;
	}
	
	
	void Update()
	{
		if (died == false) {
						scoreText.text = "Score: " + score;
			if (Input.GetButtonUp ("Jump")||Input.GetButtonUp ("Fire1")) {
								iskeydown1 = false;
						}
						//change gravity
		     	if ((Input.GetButtonDown ("Jump") || Input.GetButtonDown ("Fire1")) && iskeydown1 == false) {		
				 
								if ((isdown == true) && (gamestarted == true)) {

										GetComponent<Rigidbody2D> ().gravityScale = -15;
										transform.Rotate (180, 0, 0);
										isdown = false;
										iskeydown1 = true;
								} else if ((gamestarted == true) && (isdown == false)) {
										GetComponent<Rigidbody2D> ().gravityScale = 15;
										transform.Rotate (-180, 0, 0);
										isdown = true;
										iskeydown1 = true;
				
								}
						}
						//use ammo

			      if   (Input.GetButtonUp ("Fire2")||Input.GetKeyUp(KeyCode.F)) {
								iskeydown2 = false;
						}
			
			          if ((Input.GetButtonDown ("Fire2")||Input.GetKeyDown(KeyCode.F)) && iskeydown2 == false) {		
			     
								if (gamestarted == true) {
				    
					
										iskeydown2 = true;
										if (ammo != 0) {
												ammo--;
												Fire ();

												ammoText.text = "Ammo: " + ammo;
										}
								}

						}

						//play running animation

			if (Input.GetButtonDown ("Jump")||Input.GetButtonDown ("Fire1")) {
								gamestarted = true;
								//g_manager.restart = false;
								anim.SetTrigger ("Start");

						}

				} 
		if (dead==true){
			        scoreText.enabled=false;
			        ammoText.enabled=false;
			        deathWind.enabled = true;
		            gamestarted = false;
		            dead = false;
					died = true;
					source.PlayOneShot (deathSound, 1.0f);
			        gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GetComponent<Rigidbody2D> ().velocity = stop;
					anim.SetTrigger ("End");
					score = score + ammo;
					
					GetComponent<Rigidbody2D> ().gravityScale = 0;
				}

	}


	//everything in the Physics2D2D is set in the fixupdate 
	void FixedUpdate ()
	{
		// if game is started we move the character forward...
		if (gamestarted == true && died==false) 
		{
		GetComponent<Rigidbody2D>().velocity = new Vector2( 10 , GetComponent<Rigidbody2D>().velocity.y  );
			char_velocity = GetComponent<Rigidbody2D>().velocity;
			distanceTraveled = transform.position.x;
		}
//		if (dead == true){
//			dead = false;
//			died = true;
//			source.PlayOneShot(deathSound,1.0f);
//			GetComponent<Rigidbody2D>().velocity = stop;
//			anim.SetTrigger("End");
//			score = score+ammo;
//			gamestarted = false;
//			GetComponent<Rigidbody2D>().gravityScale = 0;
//	}

	}

}

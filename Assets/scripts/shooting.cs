using UnityEngine; 
using System.Collections;

public class shooting : MonoBehaviour 
{

	public Collision2D hit;
	public float timePass = 100 ;
	AudioSource source;
	public AudioClip hitSound;
	private Animator anim;	
	float keepx,keepy;

	void Awake()
	{   
		anim = GetComponent<Animator>();
		source = GetComponent<AudioSource>();

	}


	void OnCollisionEnter2D(Collision2D hit)
	{

		if(hit.gameObject.tag == "Obstacle")
		{   

			GetComponent<Rigidbody2D>().isKinematic = true;
			GetComponent<Collider2D>().enabled = false;
			source.PlayOneShot(hitSound,1.0f);
			gLimit.diff++;
			transform.localScale=new Vector2(0.24f,0.24f);
			gameObject.transform.position = new Vector3(keepx+1f, keepy, 0);
			anim.SetTrigger ("Hit");

			hit.gameObject.transform.position = new Vector3(0, 0, 0);

			//Destroy(gameObject);
			//transform.position = new Vector3(-20,-20,0);

		}
	}
	void Update () 
	{
		keepx = transform.position.x;
		keepy = transform.position.y;

		if (timePass <0f){
		Destroy(gameObject);
		}
		timePass--;
	}


}
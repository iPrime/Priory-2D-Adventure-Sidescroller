using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	Animator anim;

	AudioSource[] sounds;
		public AudioSource footsteps;
		public AudioSource jump;
	

	//==== Check ground Distance <-> Character ===
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0f;
	public LayerMask whatIsGround;
	public float jumpForce = 500f;

	bool inFire = false;

	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();

		sounds = GetComponents<AudioSource>();
		footsteps = sounds[0];
		jump = sounds[1];

	}




	// ===== Collision with Campfire ===

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag=="Campfire"){
			inFire = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag=="Campfire"){
			inFire = false;

		}
	}




	
	// Update is called exact timestamp
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);



		// ===== Flip Character ===
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}






	void Update()
	{
		if(grounded && Input.GetKeyDown (KeyCode.UpArrow)) {
			anim.SetBool ("Ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			jump.Play ();

		} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
			jump.Stop ();
		}


		// ===== Call Throwing Animation ===
		if(inFire && Input.GetKeyDown(KeyCode.E)) {
			
			if (WoodBehaviour.count > 0 && WoodBehaviour.count <= 4) {
				anim.SetTrigger ("Throw");
			}
			
		}


		// ===== Call AudioClip Walking ===
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.LeftArrow)) {

			// Play the hurt sound effect.
			footsteps.Play ();

		} else if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) { 
			footsteps.Stop();
		}


	}


	// ===== Flipping Function ===
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}


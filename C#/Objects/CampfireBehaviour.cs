using UnityEngine;
using System;
using System.Collections;

public class CampfireBehaviour : MonoBehaviour {
	
	public Animator anim;
	public int campfireStatus;
	public float timer;
	public float beforeDecrease; // timer for campfires
	bool inTrigger = false;	

	public AudioClip campfireClip;
	private AudioSource source;

	//bool isFull = false;                                                // Whether the player is dead.


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		source = GetComponent<AudioSource>();

	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag=="Player"){
			inTrigger = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag=="Player"){
			inTrigger = false;
		}
	}

	// Update is called once per frame
	void Update () {

		anim.SetInteger("Intensity", campfireStatus);

		if(inTrigger && Input.GetKeyDown(KeyCode.E)) {

			if (WoodBehaviour.count > 0 /*&& WoodBehaviour.count <= 4*/) {

				if (campfireStatus < 4) {
					campfireStatus++;
					source.PlayOneShot(campfireClip);
				}

			}


		}


		timer+= Time.deltaTime;
		
		if (timer > beforeDecrease) {
			
			timer = 0;

			if (campfireStatus !=0 && campfireStatus !=4){
				campfireStatus--;
				//Debug.Log ("Decrease");
			}

		}



	}


}

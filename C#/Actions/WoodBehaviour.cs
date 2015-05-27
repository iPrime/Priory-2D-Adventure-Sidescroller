using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WoodBehaviour : MonoBehaviour {
	
	static public int count;
	public GUIText countText;

	public AudioClip plopClip;
	private AudioSource source;

	GameObject campfire;
	CampfireBehaviour campfireBehaviour;

	bool inTrigger = false;	
	


	// Use this for initialization
	void Start () {
	
		campfire = GameObject.FindGameObjectWithTag ("Campfire");
		campfireBehaviour = campfire.GetComponent <CampfireBehaviour> ();

		count = 0;
		setCountText ();
		source = GetComponent<AudioSource>();

	}
	
	void Update () {
		
		if(inTrigger && Input.GetKeyDown(KeyCode.E)) {

			if(count > 0) {

				//if(this.campfireBehaviour.campfireStatus < 4) {
					
					count -= 1;
					setCountText ();

				//}
			
			}
		}

	}
	
	// OnTriggerEnter 2D
	void OnTriggerEnter2D(Collider2D other) {

		// If gameObject comes in contact with player
		if (other.gameObject.tag == "WoodStumps") {
			other.gameObject.SetActive (false);
			//source.clip = plopClip;
			source.PlayOneShot(plopClip);

			count += 1;
			setCountText ();
			Debug.Log (source);
		}

		// If player comes in collide with gameObject
		if (other.gameObject.tag=="Campfire") {
			inTrigger = true;
			print ("campfire");

		}

	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag=="Campfire"){
			inTrigger = false;
		}
	}
	
	void setCountText() {
		countText.text = "x " + count.ToString();
	}
	
	
}

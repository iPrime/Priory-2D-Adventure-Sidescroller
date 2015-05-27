using UnityEngine;
using System.Collections;

public class Climb : MonoBehaviour {
	
	GameObject player;                          // Reference to the player GameObject.
	bool canClimb = false;
	// float speed = 1;
	public bool isKinematic;

	void Awake () {
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnTriggerEnter2D(Collider2D other) { // send in the other collider (should always work)
		if(other.gameObject == player) {
			canClimb = true;
			SendMessage("hoi");
		}
	}
	
	void OnTriggerExit2D(Collider2D other) { // send in the other collider (should always work)
		if(other.gameObject == player) {
			canClimb = false;
		}
	}
	
	void Update () {
		if(canClimb){
			if(Input.GetKey(KeyCode.Space)){
				SendMessage("get");

			}
			if(Input.GetKey(KeyCode.S)){
				//playerObject.transform.Translate (Vector2(0,-1,0) * Time.deltaTime*speed);
			}
		}
	}
	
}

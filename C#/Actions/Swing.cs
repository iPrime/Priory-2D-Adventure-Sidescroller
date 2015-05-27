using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour {

	public bool isKinematic;

	// trigger event within rope
	void OnTriggerEnter2D(Collider2D other) { // send in the other collider (should always work)
		if (other.gameObject.tag == "Player") { // used a tag to ID collider as player
			other.transform.SetParent (this.transform); // set gameobject as others parent
			other.gameObject.SendMessage ("trigger send");
			other.GetComponent<Rigidbody2D>().isKinematic = true;
		} 
	}

	void OnTriggerExit2D(Collider2D other) { // send in the other collider (should always work)
		if (other.gameObject.tag == "Player") { // used a tag to ID collider as player
			other.GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}

}

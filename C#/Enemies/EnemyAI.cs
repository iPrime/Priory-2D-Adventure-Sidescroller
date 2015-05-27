using UnityEngine;
using System;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	float startPos;					// Define startPos
	float endPos;					// Define endPos
	Vector2 walkAmount;

	public float walkSpeed = 1;		// WalkSpeed
	public float unitsToMove = 3; 	// Define endPos

	float walkingDirection = 1.0f;
	bool facingRight = true;


	void Start () {

		startPos = this.transform.position.x;
		endPos = startPos + unitsToMove;

	}
	
	// Update is called once per frame
	void Update () {
		endPos = startPos + unitsToMove;

		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;

		if (walkingDirection > 0.0f && transform.position.x >= endPos) {
			walkingDirection = -1.0f;
			Flip ();
		} else if (walkingDirection < 0.0f && transform.position.x <= startPos) {
			walkingDirection = 1.0f;
			Flip ();
		}
		transform.Translate(walkAmount);

	}
	
	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}


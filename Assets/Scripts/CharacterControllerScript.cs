using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour 
{
	public float maxSpeed = 10f;
	public float speed;
	int direction;

	Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		Physics2D.IgnoreLayerCollision (0,9);
	}

	void Attack(int direction)
	{
		switch (direction){
		case 0:
			anim.SetTrigger ("Attack");
			break;
		case 1:
			anim.SetTrigger ("Attack");
			break;
		case 2:
			anim.SetTrigger ("Attack");
			break;
		case 3:
			anim.SetTrigger ("Attack");
			break;

		}

	}


	// Update is called once per frame
	void FixedUpdate () 
	{
		
		if (Input.GetKeyDown (KeyCode.J)) {
			Attack (direction);
		}
		float movex = Input.GetAxisRaw ("Horizontal");

		if (movex > 0) {
			anim.SetBool ("Right", true);
			direction = 1;
		} else{
			anim.SetBool ("Right", false);
		}
		if (movex < 0) {
			anim.SetBool ("Left", true);
			direction = 3;
		} else {
			anim.SetBool ("Left", false);
		}
		float movey = Input.GetAxisRaw ("Vertical");
		if (movey > 0) {
			anim.SetBool ("Up", true);
			direction = 0;
		} else {
			anim.SetBool ("Up", false);
		}
		if (movey < 0) {
			anim.SetBool ("Down", true);
			direction = 2;
		} else {
			anim.SetBool ("Down", false);
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex*maxSpeed, movey*maxSpeed);



		/* Temp try
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector2.right * speed);
			anim.SetBool ("Right", true);
		} else{
			anim.SetBool ("Right", false);
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector2.up * speed);
			anim.SetBool ("Up", true);
		} else {
			anim.SetBool ("Up", false);
		}
		if (Input.GetKey (KeyCode.A)){
			transform.Translate (Vector2.left * speed);
			anim.SetBool ("Left", true);
		} else {
			anim.SetBool ("Left", false);
		}
		if (Input.GetKey (KeyCode.S)){
			transform.Translate (Vector2.down * speed);
			anim.SetBool ("Down", true);
		} else {
			anim.SetBool ("Down", false);
		}
		*/
	}

}

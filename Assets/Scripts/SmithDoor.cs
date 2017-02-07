using UnityEngine;
using System.Collections;

public class SmithDoor : MonoBehaviour {
	public Transform exit;
	public GameObject newcamera;
	public bool up;
	public bool down;


	void OnTriggerStay2D(Collider2D other)
	{

		if (other.GetComponent<Collider2D>().tag == "Player"){
			if((up == true && Input.GetKey(KeyCode.W)) || (down == true && Input.GetKey(KeyCode.S))){
	
				CameraController.changeCamera (newcamera);

				other.transform.position = exit.transform.position;
			}
		}

	}
}

using UnityEngine;
using System.Collections;

public class SmithDoor : MonoBehaviour {
	public Transform exit;
	public GameObject newcamera;


	void OnTriggerStay2D(Collider2D other)
	{

		if (other.GetComponent<Collider2D>().tag == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))){
	
			CameraController.changeCamera (newcamera);

			other.transform.position = exit.transform.position;
		}

	}
}

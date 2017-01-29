using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform Player;

	public Vector2 Margin, Smoothing;

	public static BoxCollider2D Bounds;
	private static Vector3 _min, _max;

	public bool IsFollowing{ get; set; }

	// Use this for initialization
	void Start () 
	{
		GameObject mapbounds = GameObject.Find ("CameraBounds");
		Bounds = mapbounds.GetComponent<BoxCollider2D> ();

		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		IsFollowing = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float x = transform.position.x;
		float y = transform.position.y;

		if (IsFollowing) {
			if (Mathf.Abs (x - Player.position.x) > Margin.x)
				x = Mathf.Lerp (x, Player.position.x, Smoothing.x);
			if (Mathf.Abs (y - Player.position.y) > Margin.y)
				y = Mathf.Lerp (y, Player.position.y, Smoothing.y);
		}

		var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);

		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);

		transform.position = new Vector3 (x, y, transform.position.z);
	}

	public static void changeCamera(GameObject newbounds)
	{


		Debug.Log (newbounds.name);
		Bounds = newbounds.GetComponent<BoxCollider2D> ();
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;

	}
}

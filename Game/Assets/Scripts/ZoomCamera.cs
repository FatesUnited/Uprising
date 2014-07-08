using UnityEngine;
using System.Collections;


public class ZoomCamera : MonoBehaviour {

	private float moveSpeed = 100.0f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float movement = Input.GetAxis("Mouse ScrollWheel") * moveSpeed;
		movement *= Time.deltaTime;
		/*Debug.Log ("position: " + transform.position.y + ", movement: " + Input.GetAxis ("Mouse ScrollWheel")
		           + ", Move up: " +  (transform.position.y <= 5.0f || Input.GetAxis ("Mouse ScrollWheel") >= 0.1f)
		           + ", Move down: " + (transform.position.y >= 0.5f || Input.GetAxis("Mouse ScrollWheel") <= -0.1f));*/
		if ((transform.position.y <= 5.0f || Input.GetAxis ("Mouse ScrollWheel") >= 0.1f) && 
		    (transform.position.y >= 0.5f || Input.GetAxis("Mouse ScrollWheel") <= -0.1f)) {
			transform.Translate(0, 0 , movement);
		}
	}
}

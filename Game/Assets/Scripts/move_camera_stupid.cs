using UnityEngine;
using System.Collections;

public class move_camera_stupid : MonoBehaviour {

	float speed = (float).1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x_move = Input.GetAxis ("Horizontal");
		float y_move = Input.GetAxis ("Vertical");
		if ((x_move <= -0.1f || this.transform.position.x < 10.55f) &&
		    (x_move >= 0.1f || this.transform.position.x > -1.05f) &&
		    (y_move <= 0.1f || this.transform.position.z < 1.5f) &&
		    (y_move >= -0.1f || this.transform.position.z > -10.97f))
		{
			transform.Translate (x_move * speed, y_move * speed, 0);
		}
	}
}

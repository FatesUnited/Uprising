using UnityEngine;
using System.Collections;

/* Written by: b0rg
 * Last Modified: 3/18/14 18:00
 * Porpose: Moving the camera by moving the mouse to the edge of the screen.
 * The scroll speed can be changed in the Unity GUI via the public variable speed.
 */

// started with this source code:
// http://answers.unity3d.com/questions/275436/move-the-camera-then-the-cursor-is-at-the-screen-e.html

public class MouseMoveCamera : MonoBehaviour {
	// global variables
	int boundary = 10;// distance from edge scrolling starts
	//int speed = 5;
	int screenWidth;
	int screenHeight;

	public Camera cam;
    public int speed;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         

	// Use this for initialization
	void Start () {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
	}// end start
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Current position - x: " + cam.transform.position.x + " y: " + cam.transform.position.y + " z: " + cam.transform.position.z);
		if (Input.mousePosition.x > screenWidth - boundary && cam.transform.position.x < 10.55f) {
			//cam.transform.position.x += speed * Time.deltaTime;
			cam.transform.position -= Vector3.left * speed * Time.deltaTime;
		}// end if
		if (Input.mousePosition.x < 0 + boundary && cam.transform.position.x > -1.05f) {
			//cam.transform.position.x -= speed * Time.deltaTime;
			cam.transform.position -= Vector3.right * speed * Time.deltaTime;
		}// end if
		if (Input.mousePosition.y > screenHeight - boundary && cam.transform.position.z < 1.5f) {
			//cam.transform.position.z += speed * Time.deltaTime;
			cam.transform.position -= Vector3.back * speed * Time.deltaTime;
		}// end if
		if (Input.mousePosition.y < 0 + boundary && cam.transform.position.z > -10.97f) {
			//cam.transform.position.z -= speed * Time.deltaTime;
			cam.transform.position -= Vector3.forward * speed * Time.deltaTime;
		}// end if
	}// end update
}

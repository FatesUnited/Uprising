/* Written by: b0rg
 * Last Modified: 4/28/14 03:00 pm
 * Porpose: Left click on minimap will change to main camera view to that part
 * of the map. Right clicking while units are selected will move those units to
 * that part of the map
 */

using UnityEngine;
using System.Collections;

public class minimapFunctions : MonoBehaviour {
    float topBound;
    float rightBound;
    
    // calculation variables
    float percentageX;
    float percentageZ;
    float newX;
    float newZ;

	// Use this for initialization
	void Start () {
        topBound = Screen.height * 0.3325f;
        rightBound = Screen.width * 0.25f;
	}// end Start
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("Current position - x: " + Camera.main.transform.position.x + " y: " + Camera.main.transform.position.y + " z: " + Camera.main.transform.position.z);

        if (Input.GetMouseButton(0) && Input.mousePosition.x <= rightBound
                && Input.mousePosition.y <= topBound) {
            //Debug.Log("Mouse event occured at x: " + Input.mousePosition.x + " y: " + Input.mousePosition.y);
            percentageX = Input.mousePosition.x / rightBound;
            newX = (11.6f * percentageX) + -1.05f;
            percentageZ = Input.mousePosition.y / topBound;
            newZ = (12.47f * percentageZ) + -10.97f;

            //Debug.Log("newX: " + newX + " newZ: " + newZ);
            //Debug.Log("percentageX: " + percentageX + " percentageZ: " + percentageZ);
            //Debug.Log(Input.mousePosition.y + " / " + topBound + " = " + percentageZ);

            Camera.main.transform.position = new Vector3(newX, Camera.main.transform.position.y, newZ);
        }// end if

	}// end Update

    // fires after update method
    void LateUpdate () {

    }// end LateUpdate
}// end minimapFunctions

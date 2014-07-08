using UnityEngine;
using System.Collections;

public class pushback : MonoBehaviour {

	public int countdown = 0;
	public float VELOCITY_DAMPENING = (float).85;
	public Vector3 direction;
	public float MOVE_AMOUNT = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (countdown>0)
		{
			this.rigidbody.velocity = (this.rigidbody.velocity * VELOCITY_DAMPENING);
			this.rigidbody.AddForce (direction*MOVE_AMOUNT);
			this.rigidbody.angularVelocity = new Vector3 (0, 0, 0);
			this.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
			countdown--;
		} else {
			this.rigidbody.angularVelocity = (new Vector3(0,0,0));
			this.rigidbody.velocity = new Vector3(0,0,0);
		}
	}
}

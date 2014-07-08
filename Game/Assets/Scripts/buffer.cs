using UnityEngine;
using System.Collections;

public class buffer : MonoBehaviour {

	private float buffer_radius = 1.0f;
	private float pushback = 20.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] ships = Physics.OverlapSphere (this.transform.position, this.collider.bounds.size.magnitude * buffer_radius);
		foreach (Collider ship in ships) {
			if (ship.rigidbody != null)
			{
				Vector3 direction = ship.transform.position - this.transform.position;
				direction = new Vector3(direction.x, 0.0f, direction.y);
				((pushback)ship.GetComponent("pushback")).countdown = 30;
				((pushback)ship.GetComponent("pushback")).direction = direction;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class visibility : MonoBehaviour {

	public bool slave;
	public float visibility_radius = 5.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Collider[] ships = Physics.OverlapSphere (this.transform.position, visibility_radius);
		foreach (Collider ship in ships) 
		{
			if ((ship.tag == "slave" && (this.tag == "master" || this.tag == "select"))
			    || (ship.tag=="master" && (this.tag == "slave" || this.tag == "select"))) {
				Debug.Log ("Making" + ship.name + "visible!");
				ship.renderer.material.color = new Color(ship.renderer.material.color.r, ship.renderer.material.color.g, ship.renderer.material.color.b, 1.0f);	
			}
			if (ship.tag == "asteroid") //not actually a ship
			{
				((asteroidResources)ship.GetComponent("asteroidResources")).checkExpired();
			}
		}
	}
}
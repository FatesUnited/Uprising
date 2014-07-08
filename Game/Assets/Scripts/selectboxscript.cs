using UnityEngine;
using System.Collections;

public class selectboxscript : MonoBehaviour {

	private int timer = 0;

	// Use this for initialization
	void Start () {
		string type = GameObject.Find ("player_type").tag;
		foreach (GameObject ship in GameObject.FindGameObjectsWithTag(type)){
			if (ship.transform.position.x < this.collider.bounds.max.x &&
			    ship.transform.position.y < this.collider.bounds.max.y &&
			    ship.transform.position.x > this.collider.bounds.min.x &&
			    ship.transform.position.y > this.collider.bounds.min.y)
			{
				Debug.Log (ship.name);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Anything?");
		timer++;
		if (timer == 10) {
			this.transform.Translate(new Vector3(0.0f, -10.0f, 0.0f));		
		}
		if (timer == 20) {
			this.transform.Translate (new Vector3(0.0f, 10.0f, 0.0f));	
		}
		if (timer == 60) {
			Debug.Log ("attempting to destroy");
			GameObject.Destroy (this);
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Hello World!" + other.name);
		if (other.tag == "slave" && GameObject.Find ("player_type").tag == "slave")
			other.tag = "select";
		else if (other.tag == "master" && GameObject.Find ("player_type").tag == "master")
			other.tag = "select";
	}
}

using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float FORCE_AMOUNT = (float)17.25 	;
	public float VELOCITY_DAMPENING = (float).85;
	public Vector3 destination;
	public bool going;
	public bool following;
	public bool canMine;
	public bool mining;
	public GameObject asteroid;
	public Transform target;
	//public Transform playerPrefab;
	// Use this for initialization
	void Start () {
		destination = this.transform.position;
		going = false;
		following = false;
		InvokeRepeating("attackHelper", 2, 2F); // fire projectiles at a specific rate
		if (canMine)
		{
			InvokeRepeating("miningHelper", 2, 2F);
		}
		//Network.Instantiate (playerPrefab, transform.position, transform.rotation, 0);
	}

	private Vector3 ChooseMovementVector(Vector3 start, Vector3 destination)
	{
		Vector3 normal_vector =	(destination - start).normalized *2* FORCE_AMOUNT;
		Vector3 relative_vector = (destination - start) * FORCE_AMOUNT;
		Vector3 return_vector;
		if (normal_vector.magnitude < relative_vector.magnitude) {
			return_vector = normal_vector;
		}
		else{ 
			return_vector = relative_vector;
		}
		return new Vector3 (return_vector.x, 0, return_vector.z);
	}



	// Update is called once per frame
	void Update () {
		//Debug.Log (this.tag);
		if (target == null)
			following = false;
		//this.transform.position = new Vector3 (this.transform.position.x, 0, this.transform.position.z);
		if (going) {
			if (Vector3.Distance (this.transform.position, destination) > .25) {
				this.rigidbody.velocity = (this.rigidbody.velocity * VELOCITY_DAMPENING);
				this.transform.LookAt (destination);
				this.rigidbody.AddForce (ChooseMovementVector(transform.position, destination));
				this.rigidbody.angularVelocity = new Vector3 (0, this.rigidbody.angularVelocity.y, 0);
				this.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
			} else {
				going = false;
				this.rigidbody.angularVelocity = (new Vector3(0,0,0));
				this.rigidbody.velocity = new Vector3(0,0,0);
			}
		}

		else if (following) 
		{
			if (Vector3.Distance (this.transform.position, target.position) > 1.5) {
				this.rigidbody.velocity = (this.rigidbody.velocity * VELOCITY_DAMPENING);
				this.transform.LookAt (target.position);
				this.rigidbody.AddForce (ChooseMovementVector(transform.position, target.position));
				this.rigidbody.angularVelocity = new Vector3 (0, this.rigidbody.angularVelocity.y, 0);
				this.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
			} else {
				this.rigidbody.angularVelocity = (new Vector3(0,0,0));
				this.rigidbody.velocity = new Vector3(0,0,0);
			}
		}
		else if (mining)
		{
			if (Vector3.Distance (this.transform.position, asteroid.transform.position) > 1.0) {
				this.rigidbody.velocity = (this.rigidbody.velocity * VELOCITY_DAMPENING);
				this.transform.LookAt (asteroid.transform.position);
				this.rigidbody.AddForce (ChooseMovementVector(transform.position, asteroid.transform.position));
				this.rigidbody.angularVelocity = new Vector3 (0, this.rigidbody.angularVelocity.y, 0);
				this.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
			} else {
				this.rigidbody.angularVelocity = (new Vector3(0,0,0));
				this.rigidbody.velocity = new Vector3(0,0,0);
			}
		}
	}
	
	void attackHelper()
	{
		if (following == true && Vector3.Distance(this.transform.position, target.position) < 3) 
		{
			if (this.GetComponent("ScoutStats") != null)
				((ScoutStats)this.GetComponent ("ScoutStats")).attack ();
			if (this.GetComponent("AntiDreadnoughtStats") != null)
				((AntiDreadnoughtStats)this.GetComponent ("AntiDreadnoughtStats")).attack ();
			if (this.GetComponent("ArtilleryStats") != null)
				((ArtilleryStats)this.GetComponent ("ArtilleryStats")).attack ();
			if (this.GetComponent("CruiserStats") != null)
				((CruiserStats)this.GetComponent ("CruiserStats")).attack ();
			if (this.GetComponent("DreadnoughtStats") != null)
				((DreadnoughtStats)this.GetComponent ("DreadnoughtStats")).attack ();
			if (this.GetComponent("SiegeStats") != null)
				((SiegeStats)this.GetComponent ("SiegeStats")).attack ();
			if (this.GetComponent("StrikerStats") != null)
				((StrikerStats)this.GetComponent ("StrikerStats")).attack ();
			if (this.GetComponent("SupportStats") != null)
				((SupportStats)this.GetComponent ("SupportStats")).attack ();
			if (this.GetComponent("MiningStats") != null)
				((MiningStats)this.GetComponent ("MiningStats")).attack ();
			if (this.GetComponent("StationStats") != null)
				((MiningStats)this.GetComponent ("MiningStats")).attack ();
		}
	}

	void miningHelper()
	{
		if (mining == true && Vector3.Distance(this.transform.position, asteroid.transform.position) <= 1.0)
		{
			((asteroidResources)asteroid.GetComponent ("asteroidResources")).remove_resources ();
			((SaveThis)GameObject.Find("player_type").GetComponent ("SaveThis")).increase_resources();
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		if (this.tag == "select" && (collision.collider.tag == "slave" || collision.collider.tag == "master")) {
			collision.collider.isTrigger = true;
		}
		collision.collider.rigidbody.velocity = (new Vector3 (0, 0, 0));
		collision.collider.rigidbody.angularVelocity = (new Vector3 (0, 0, 0));
		collision.gameObject.rigidbody.velocity = (new Vector3 (0, 0, 0));
		collision.gameObject.rigidbody.angularVelocity = (new Vector3(0,0,0));
		collision.gameObject.transform.position = new Vector3 (collision.gameObject.transform.position.x, 0, collision.gameObject.transform.position.z);
	}

	/*void OnCollisionStay(Collision collision) {
		if (collision.collider.tag == "master" || collision.collider.tag == "slave") {
			collision.collider.rigidbody.velocity = (new Vector3 (0, 0, 0));
		}
		collision.gameObject.transform.position = new Vector3 (collision.gameObject.transform.position.x, 0, collision.gameObject.transform.position.z);
	}*/

	void OnCollisionExit(Collision collision) {
		if (this.tag == "select" && (collision.collider.tag == "slave" || collision.collider.tag == "master")) {
			collision.collider.isTrigger = true;
		}
		collision.collider.rigidbody.velocity = (new Vector3 (0, 0, 0));
		collision.collider.rigidbody.angularVelocity = (new Vector3(0,0,0));
		collision.gameObject.transform.position = new Vector3 (collision.gameObject.transform.position.x, 0, collision.gameObject.transform.position.z);
		collision.gameObject.rigidbody.angularVelocity = (new Vector3(0,0,0));
		collision.gameObject.rigidbody.velocity = (new Vector3 (0, 0, 0));
	}
}

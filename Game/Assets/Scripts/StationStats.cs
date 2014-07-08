using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StationStats : MonoBehaviour {

	// Fields
	public float integrity = 20;
	public float max_integrity = 20;
	public float shield = 20;
	public float max_shield = 20;
	private float shieldResist = 0.44f;
	private float damage = 2;
	private float penetration = 1.0f;

	public GameObject laserObject;
	public Texture green;
	public Texture yellow;
	public Texture red;
	private GameObject targetShip;
	public GameObject damage_sphere;


	public void Start()
	{
		InvokeRepeating("attack", 2, 2F); // fire projectiles at a specific rate
	}

	//DEAL DAMAGE TO SHIT
	public void takeDamage(float dmg, float pen)
	{
		if (networkView.viewID.isMine) {
			GameObject thing = (GameObject)Instantiate(damage_sphere, this.transform.position, Quaternion.identity);
			thing.transform.parent = this.transform;
		}
		float sumDam = dmg * pen; // total damage given from enemy
		float totalDamage = sumDam * shieldResist; // damage calculated after shield resistance applied
		
		if (shield > 0) {
			shield -= totalDamage;
			
			if (shield < 0)
			{
				shield = 0;
				// if damage dealt was greater than remaining shield, take half of leftover and "spill" over to integrity
				integrity += shield/2; 
			}
		} 
		else {
			integrity -= dmg; // only apply flat damage for structure
		}
		
		// Destroy ship if no integrity left
		if (integrity <= 0)
		{
			networkView.RPC("Die",RPCMode.All);
		}
	} // end takeDamage()
	
	//MAKE A LASER
	/*public void attack()
	{
		GameObject targetShip = ((movement)this.GetComponent("movement")).target.gameObject;
		GameObject myLaser = (GameObject)Network.Instantiate(laserObject, this.transform.position, laserObject.transform.rotation, 0);
		laser script = (laser)(myLaser.GetComponent ("laser"));
		script.penetration = penetration;
		script.damage = damage;
		
		myLaser.transform.LookAt (targetShip.transform.position);
		myLaser.transform.Rotate(Vector3.right, 90);
		((laser)myLaser.GetComponent ("laser")).target = targetShip;
	}*/
	
	// Use this for initialization

	public void OnGUI() {
		Vector3 currentPosition = Camera.main.WorldToScreenPoint (this.transform.position);
		Texture myTexture = green;
		if (this.integrity < this.max_integrity * .7) {
			myTexture = yellow;
		}
		if (this.integrity < this.max_integrity * .35) {
			myTexture = red;
		}
		GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, this.shield / this.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
		GUI.DrawTexture(new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, this.integrity / this.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
	}
	// Update is called once per frame
	void Update () {
		Collider[] ships = Physics.OverlapSphere (this.transform.position, 2.5f);
		List<GameObject> attackables = new List<GameObject> ();
		for (int i = 0; i < ships.Length; i++) {
			if ((this.name == "ssp1(Clone)" && ships[i].tag == "slave") || (this.name == "ssp2(Clone)" && ships[i].tag == "master"))	
			{
				attackables.Add(ships[i].gameObject);
			}
		}
		if (targetShip == null && attackables.Count > 0) {
			targetShip = attackables[0];
		}
		bool found = false;
		for (int i = 0; i < attackables.Count; i++)
		{
			if (attackables[i] == targetShip)
			{
				found = true;
				break;
			}
		}
		if (found == false)
		{
			targetShip = null;
		}
	}

	public void attack()
	{
		if (targetShip == null)
			return;
		GameObject myLaser = (GameObject)Network.Instantiate(laserObject, this.transform.position, laserObject.transform.rotation, 0);
		laser script = (laser)(myLaser.GetComponent ("laser"));
		script.penetration = penetration;
		script.damage = damage;
		
		myLaser.transform.LookAt (targetShip.transform.position);
		myLaser.transform.Rotate(Vector3.right, 90);
		((laser)myLaser.GetComponent ("laser")).target = targetShip;
	}
	
	// Destroy Scout Ship
	[RPC]
	void Die()
	{
		Application.LoadLevel ("gameover");
		Destroy(gameObject);
	} // end Die()
}

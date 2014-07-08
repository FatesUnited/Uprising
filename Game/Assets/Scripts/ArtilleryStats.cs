using UnityEngine;
using System.Collections;

public class ArtilleryStats : MonoBehaviour {

	// Fields
	public float damage = 4;
	public float rateOfFire = 5;
	public float range = 6;
	public float integrity = 1;
	public float max_integrity = 1;
	public float shield = 5;
	public float max_shield = 5;
	public float penetration = 1.2f;
	public float shieldResist = 1;
	public GameObject laserObject;
	public GameObject damage_sphere;


	//DEAL DAMAGE TO SHIP
	public void takeDamage(float dmg, float pen)//shieldType[] penetrationTypes, float penetrationAmount, float damage)
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
			this.Die ();
		}
	} // end takeDamage()

	//MAKE A LASER
	public void attack()
	{
		GameObject targetShip = ((movement)this.GetComponent("movement")).target.gameObject;
		GameObject myLaser = (GameObject)Network.Instantiate(laserObject, this.transform.position, laserObject.transform.rotation, 0);
		laser script = (laser)(myLaser.GetComponent ("laser"));
		script.penetration = penetration;
		script.damage = damage;
		
		myLaser.transform.LookAt (targetShip.transform.position);
		myLaser.transform.Rotate(Vector3.right, 90);
		((laser)myLaser.GetComponent ("laser")).target = targetShip;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		if (stream.isWriting) {
			stream.Serialize (ref shield);
			stream.Serialize (ref integrity);
		}
		if (stream.isReading) {
			stream.Serialize (ref shield);
			stream.Serialize (ref integrity);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	// Destroy Scout Ship
	void Die()
	{
		Network.Destroy(gameObject);
	} // end Die()
}

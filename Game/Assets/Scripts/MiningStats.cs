using UnityEngine;
using System.Collections;

public class MiningStats : MonoBehaviour {

	// Fields
	public float integrity = 2;
	public float shield = 5;
	public float max_shield = 5;
	public float max_integrity = 2;
	public float shieldResist = 1;
	public GameObject damage_sphere;


	//DEAL DAMAGE TO SHIP
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
			this.Die ();
		}
	} // end takeDamage()
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// DO NOT DELETE
	public void attack()
	{

	}

	// Destroy Scout Ship
	void Die()
	{
		Network.Destroy(gameObject);
	} // end Die()

	
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
}

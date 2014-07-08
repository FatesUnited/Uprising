using UnityEngine;
using System.Collections;

public class SupportStats : MonoBehaviour {

	// Fields
	public float integrity = 1;
	public float max_integrity = 1;
	public float shield = 10;
	public float max_shield = 10;
	public float shieldResist = 1;
	public GameObject healing_bubble;
	private string mytag;
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

	// Use this for initialization
	public void Start()
	{
		mytag = this.tag;
		InvokeRepeating("heal", 2, 2F); // fire projectiles at a specific rate
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// DO NOT DELETE
	public void attack()
	{
	
	}

	void heal()
	{
		if ((GameObject.Find("player_type").tag == "slave" && this.mytag == "slave") ||
		    (GameObject.Find("player_type").tag == "master" && this.mytag == "master"))
		{
			GameObject thing = (GameObject)Network.Instantiate (healing_bubble, this.transform.position, Quaternion.identity, 0);
			networkView.RPC ("assign_properties", RPCMode.All, thing.networkView.viewID, this.networkView.viewID);
		}
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

	[RPC]
	void assign_properties(NetworkViewID child, NetworkViewID parent)
	{
		GameObject c = NetworkView.Find(child).gameObject;
		GameObject p = NetworkView.Find(parent).gameObject;
		c.transform.parent = p.transform;
		c.tag = p.tag;
	}

	// Destroy Scout Ship
	void Die()
	{
		Network.Destroy(gameObject);
	} // end Die()
}

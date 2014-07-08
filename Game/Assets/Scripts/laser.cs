using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {

	public GameObject target;
	public float penetration;
	public float damage;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.target != null) {
			target.collider.isTrigger = false;
			float step = 4.0f * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
		}
		else if (networkView.viewID.isMine)
			Network.Destroy(gameObject); // Destroy the laser
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("Hello World!");
		Debug.Log ("Col" + col.gameObject);
		Debug.Log (this.target == col.gameObject);
		if (col.gameObject == this.target) 
		{
			networkView.RPC ("CallDamage", RPCMode.All, col.gameObject.networkView.viewID, damage, penetration);

			Debug.Log("Attempting to destroy..."+ networkView.viewID.isMine);
			if (networkView.viewID.isMine)
				Network.Destroy(gameObject); // Destroy the laser
		}
	}

	[RPC]
	void CallDamage(NetworkViewID id, float dam, float pen)
	{
		GameObject col = NetworkView.Find (id).gameObject;
		if (col.GetComponent("ScoutStats") != null)
			((ScoutStats)col.GetComponent("ScoutStats")).takeDamage(dam, pen);
		if (col.GetComponent("AntiDreadnoughtStats") != null)
			((AntiDreadnoughtStats)col.GetComponent("AntiDreadnoughtStats")).takeDamage(dam, pen);
		if (col.GetComponent("ArtilleryStats") != null)
			((ArtilleryStats)col.GetComponent("ArtilleryStats")).takeDamage(dam, pen);
		if (col.GetComponent("CruiserStats") != null)
			((CruiserStats)col.GetComponent("CruiserStats")).takeDamage(dam, pen);
		if (col.GetComponent("DreadnoughtStats") != null)
			((DreadnoughtStats)col.GetComponent("DreadnoughtStats")).takeDamage(dam, pen);
		if (col.GetComponent("MiningStats") != null)
			((MiningStats)col.GetComponent("MiningStats")).takeDamage(dam, pen);
		if (col.GetComponent("SiegeStats") != null)
			((SiegeStats)col.GetComponent("SiegeStats")).takeDamage(dam, pen);
		if (col.GetComponent("StrikerStats") != null)
			((StrikerStats)col.GetComponent("StrikerStats")).takeDamage(dam, pen);
		if (col.GetComponent("SupportStats") != null)
			((SupportStats)col.GetComponent("SupportStats")).takeDamage(dam, pen);
		if (col.GetComponent ("StationStats") != null)
			((StationStats)col.GetComponent ("StationStats")).takeDamage (dam, pen);
	}
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		if (stream.isWriting) {
			Vector3 pos = new Vector3();
			Quaternion rot = new Quaternion();;
			pos = this.transform.position;
			rot = this.transform.rotation;
			stream.Serialize (ref pos);
			stream.Serialize(ref rot);
		}
		if (stream.isReading) {
			Vector3 pos = new Vector3();
			Quaternion rot = new Quaternion();
			GameObject tar = new GameObject();
			stream.Serialize (ref pos);
			stream.Serialize (ref rot);
			this.transform.position = pos;
			this.transform.rotation = rot;
		}
	}
}

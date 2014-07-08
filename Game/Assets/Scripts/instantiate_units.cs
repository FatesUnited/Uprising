using UnityEngine;
using System.Collections;

public class instantiate_units : MonoBehaviour {

	public GameObject slave;
	public GameObject slave_miner;
	public GameObject master;
	public GameObject master_miner;
	public GameObject ssp1;
	public GameObject ssp2;
	public GameObject dummy1;
	public GameObject dummy2;
	public GameObject defog;
	private bool instantiated = false;
	// Use this for initialization
	void Start () {
		if (Network.isServer)
		{
			Network.Instantiate(dummy1, dummy1.transform.position, dummy1.transform.rotation, 0);
			Network.Instantiate(ssp1, ssp1.transform.position, ssp1.transform.rotation, 0);
			GameObject followee = (GameObject)Network.Instantiate(master, master.transform.position, master.transform.rotation, 0);
			followee = (GameObject)Network.Instantiate(master_miner, master_miner.transform.position, master_miner.transform.rotation, 0);
			this.transform.position = new Vector3(master.transform.position.x, (float)1.813781, master.transform.position.z);
		}
		if (!instantiated && Network.isClient) {
			Network.Instantiate(ssp2, ssp2.transform.position, ssp2.transform.rotation, 0);
			Network.Instantiate(dummy2, dummy2.transform.position, dummy2.transform.rotation, 0);
			GameObject followee = (GameObject)Network.Instantiate(slave, slave.transform.position, slave.transform.rotation, 0);
			followee = (GameObject)Network.Instantiate(slave_miner, slave_miner.transform.position, slave_miner.transform.rotation, 0);
			this.transform.position = new Vector3(slave.transform.position.x, (float)1.813781, slave.transform.position.z);
			this.instantiated = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnConnectedToServer(){
		if (!instantiated && Network.isClient) {
			Network.Instantiate(dummy2, dummy2.transform.position, dummy2.transform.rotation, 0);
			Network.Instantiate(ssp2, ssp2.transform.position, ssp2.transform.rotation, 0);
			GameObject followee = (GameObject)Network.Instantiate(slave, slave.transform.position, slave.transform.rotation, 0);
			followee = (GameObject)Network.Instantiate(slave_miner, slave_miner.transform.position, slave_miner.transform.rotation, 0);
			this.transform.position = new Vector3(slave.transform.position.x, (float)1.813781, slave.transform.position.z);
			this.instantiated = true;
		}
	}
}

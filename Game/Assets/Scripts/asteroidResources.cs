using UnityEngine;
using System.Collections;

public class asteroidResources : MonoBehaviour {

	private int resources = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void remove_resources()
	{
		this.resources -= 10;
	}

	public void checkExpired()
	{
		if (this.resources == 0)
		{
			Destroy (gameObject);
		}
	}
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		if (stream.isWriting) {
			int resources = new int ();
			resources = this.resources;
			stream.Serialize (ref resources);
		}
		if (stream.isReading) {
			int resources = new int();
			stream.Serialize (ref resources);
			this.resources = resources;
		}
	}
}

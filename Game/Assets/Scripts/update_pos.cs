using UnityEngine;
using System.Collections;

public class update_pos : MonoBehaviour {

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		if (stream.isWriting) {
			Vector3 pos = new Vector3();
			Quaternion rot = new Quaternion();
			Vector3 dest = new Vector3();
			bool going = new bool();
			Vector3 angVeloc = new Vector3();
			Vector3 vel = new Vector3();
			pos = this.transform.position;
			rot = this.transform.rotation;
			dest = ((movement)this.GetComponent ("movement")).destination;
			going = ((movement)this.GetComponent ("movement")).going;
			angVeloc = this.rigidbody.angularVelocity;
			vel = this.rigidbody.velocity;
			stream.Serialize(ref pos);
			stream.Serialize(ref rot);
			stream.Serialize(ref dest);
			stream.Serialize(ref going);
			stream.Serialize (ref angVeloc);
			stream.Serialize(ref vel);
		} else if (stream.isReading) {
			Vector3 pos = new Vector3();
			Quaternion rot = new Quaternion();
			Vector3 dest = new Vector3();
			bool going = new bool();
			Vector3 angVeloc = new Vector3();
			Vector3 vel = new Vector3();
			stream.Serialize (ref pos);
			this.transform.position = pos;
			stream.Serialize (ref rot);
			this.transform.rotation = rot;
			stream.Serialize(ref dest);
			((movement)this.GetComponent("movement")).destination = dest;
			stream.Serialize (ref going);
			((movement)this.GetComponent ("movement")).going = going;
			stream.Serialize (ref angVeloc);
			this.rigidbody.angularVelocity = angVeloc;
			stream.Serialize (ref vel);
			this.rigidbody.velocity = vel;
		}
	}
}

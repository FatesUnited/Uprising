using UnityEngine;
using System.Collections;

public class maintainPosition : MonoBehaviour {

	Vector3 position;
	// Use this for initialization
	void Start () {
		position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = position;
	}
}

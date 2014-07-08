using UnityEngine;
using System.Collections;

public class StationAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InvokeRepeating("attackHelper", 2, 2F); // fire projectiles at a specific rate
	}

	void attackHelper()
	{
	}
	// Update is called once per frame
	void Update () {
	
	}
}

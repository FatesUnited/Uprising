using UnityEngine;
using System.Collections;

public class SplashLogo : MonoBehaviour {

	public float splash = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > splash) {
			Destroy(gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public int splash = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > splash) {
			Application.LoadLevel("connect");
		}
	}
}

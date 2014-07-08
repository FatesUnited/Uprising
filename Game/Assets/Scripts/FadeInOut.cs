using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {

	public float fader = 5f;

	// Use this for initialization
	void Start () {
		light.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time < 2) {
			light.intensity += 0.005f;
		}		
		else if (Time.time < fader) {
			light.intensity -= 0.005f;
		}
	}
}
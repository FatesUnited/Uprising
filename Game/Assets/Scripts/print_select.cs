using UnityEngine;
using System.Collections;

public class print_select : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("select") != null) {
			this.guiText.text = GameObject.FindGameObjectWithTag ("select").name;	
		} else {
			this.guiText.text = "none";		
		}
	}
}

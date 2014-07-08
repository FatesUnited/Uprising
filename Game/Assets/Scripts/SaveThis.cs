using UnityEngine;
using System.Collections;

public class SaveThis : MonoBehaviour {

	public int resources = 5000;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void increase_resources()
	{
		this.resources += 10;
	}
}

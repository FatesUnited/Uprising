using UnityEngine;
using System.Collections;

public class creditsGUI : MonoBehaviour {

	float buttonWidth, buttonHeight;

	void Start()
	{
		buttonWidth = 200;
		buttonHeight = 50;
	}
	
	private void Credits()
	{
		Application.LoadLevel ("credits");
	}
	
	void OnGUI () {
		if (GUI.Button (new Rect (50, 650, buttonWidth, buttonHeight), "Click Here for Title Screen")) { 
			Application.LoadLevel("connect");
		}
	}
}

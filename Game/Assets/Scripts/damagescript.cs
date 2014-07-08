using UnityEngine;
using System.Collections;

public class damagescript : MonoBehaviour {

	int time = 20;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale += new Vector3 (0.07F, 0.07F, 0.07F);
		renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, renderer.material.color.a - 0.05F);
		time--;
		if (time <= 0) {
			Destroy (this.gameObject);
		}
	}
}

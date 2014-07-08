using UnityEngine;
using System.Collections;

public class select_change : MonoBehaviour {

	private Color myColor;

	// Use this for initialization
	void Start () {
		myColor = this.renderer.material.color;
	}

	public void Select() {
		this.renderer.material.color = new Color(1f, 0.92f, 0.016f, 1f);
		this.collider.isTrigger = false;
	}

	public void Unselect() {
		this.renderer.material.color = myColor;
	}
}

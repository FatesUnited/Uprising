using UnityEngine;
using System.Collections;

public class healunits : MonoBehaviour {

	int time = 20;
	public bool visible;
	public Color myColor;
	// Use this for initialization
	void Start () {
		myColor = renderer.material.color;
		this.renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (this.tag);
		transform.localScale += new Vector3 (0.07F, 0.07F, 0.07F);
		myColor = new Color (myColor.r, myColor.g, myColor.b, myColor.a - 0.05F);
		time--;
		if (time <= 0) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if ((GameObject.Find ("player_type").tag == "slave" && col.tag == "slave") ||
		    (GameObject.Find ("player_type").tag == "master" && col.tag == "master") ||
		    col.tag == "select")
		{
			if (col.GetComponent("ScoutStats") != null)
				((ScoutStats)col.GetComponent("ScoutStats")).shield = Mathf.Min (((ScoutStats)col.GetComponent("ScoutStats")).max_shield, ((ScoutStats)col.GetComponent("ScoutStats")).shield + 1);
			if (col.GetComponent("AntiDreadnoughtStats") != null)
				((ScoutStats)col.GetComponent("AntiDreadnoughtStats")).shield = Mathf.Min (((ScoutStats)col.GetComponent("AntiDreadnoughtStats")).max_shield, ((ScoutStats)col.GetComponent("AntiDreadnoughtStats")).shield + 1);
			if (col.GetComponent("ArtilleryStats") != null)
				((ScoutStats)col.GetComponent("ArtilleryStats")).shield = Mathf.Min (((ScoutStats)col.GetComponent("ArtilleryStats")).max_shield, ((ScoutStats)col.GetComponent("ArtilleryStats")).shield + 1);
			if (col.GetComponent("CruiserStats") != null)
				((ScoutStats)col.GetComponent("CruiserStats")).shield = Mathf.Min (((ScoutStats)col.GetComponent("CruiserStats")).max_shield, ((ScoutStats)col.GetComponent("CruiserStats")).shield + 1);
			if (col.GetComponent("DreadnoughtStats") != null)
				((ScoutStats)col.GetComponent("DreadnoughtStats")).shield = Mathf.Min (((ScoutStats)col.GetComponent("DreadnoughtStats")).max_shield, ((ScoutStats)col.GetComponent("DreadnoughtStats")).shield + 1);
			if (col.GetComponent("MiningStats") != null)
				((ScoutStats)col.GetComponent("MiningStats")).shield = Mathf.Min (((ScoutStats)col.GetComponent("MiningStats")).max_shield, ((ScoutStats)col.GetComponent("MiningStats")).shield + 1);
			if (col.GetComponent("SiegeStats") != null)
				((ScoutStats)col.GetComponent("SiegeStats")).shield = Mathf.Min (((ScoutStats)col.GetComponent("SiegeStats")).max_shield, ((ScoutStats)col.GetComponent("SiegeStats")).shield + 1);
			if (col.GetComponent("StrikerStats") != null)
				((ScoutStats)col.GetComponent("StrikerStats")).shield = Mathf.Min (((ScoutStats)col.GetComponent("StrikerStats")).max_shield, ((ScoutStats)col.GetComponent("StrikerStats")).shield + 1);
			if (col.GetComponent("SupportStats") != null)
				((ScoutStats)col.GetComponent("SupportStats")).shield = Mathf.Min (((ScoutStats)col.GetComponent("SupportStats")).max_shield, ((ScoutStats)col.GetComponent("SupportStats")).shield + 1);
		}
	}
}

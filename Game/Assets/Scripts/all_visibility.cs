using UnityEngine;
using System.Collections;

public class all_visibility : MonoBehaviour {

	private float visibility_radius = 3.0f;
	public Texture green;
	public Texture yellow;
	public Texture red;
	// Use this for initialization
	void Start () {
	
	}

	void Update() {
		if (GameObject.Find ("New Game Object") != null)
			Destroy (GameObject.Find ("New Game Object"));

	}
	
	// Update is called once per frame
	void OnGUI () {
		if (GameObject.Find ("player_type").tag == "slave") {
			GameObject[] masters = GameObject.FindGameObjectsWithTag ("master");
			foreach (GameObject ship in masters)
			{
				ship.renderer.material.color = new Color(ship.renderer.material.color.r, ship.renderer.material.color.g, ship.renderer.material.color.b, 0.0f);	
				if (ship.GetComponent("healunits") != null)
				{
					ship.renderer.material.color = new Color(ship.renderer.material.color.r, ship.renderer.material.color.g, ship.renderer.material.color.b,0.0f);
				}
			}
			GameObject[] slaves = GameObject.FindGameObjectsWithTag ("slave");
			foreach (GameObject ship in slaves)
			{
				Collider[] visibles = Physics.OverlapSphere (ship.transform.position, visibility_radius);
				foreach (Collider visible in visibles)
				{
					if (visible.tag == "master" || visible.tag == "slave" || visible.tag == "select")
					{
						if (visible.gameObject.name == "healingsphere(Clone)")
						{
							visible.renderer.material.color = ((healunits)visible.GetComponent("healunits")).myColor;
						}
						else
						{
							visible.renderer.material.color = new Color(visible.renderer.material.color.r, visible.renderer.material.color.g, visible.renderer.material.color.b, 1.0f);
						}
						if (visible.GetComponent("ScoutStats") != null)
						{
							ScoutStats script = visible.GetComponent<ScoutStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						}
						if (visible.GetComponent("AntiDreadnoughtStats") != null)
						{
							AntiDreadnoughtStats script = visible.GetComponent<AntiDreadnoughtStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);

						}
						if (visible.GetComponent("ArtilleryStats") != null)
						{
							ArtilleryStats script = visible.GetComponent<ArtilleryStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						}
						if (visible.GetComponent("CruiserStats") != null)
						{
							CruiserStats script = visible.GetComponent<CruiserStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);

						}
						if (visible.GetComponent("DreadnoughtStats") != null)
						{
							DreadnoughtStats script = visible.GetComponent<DreadnoughtStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);

						}
						if (visible.GetComponent("MiningStats") != null)
						{
							MiningStats script = visible.GetComponent<MiningStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);

						}
						if (visible.GetComponent("SiegeStats") != null)
						{
							SiegeStats script = visible.GetComponent<SiegeStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);

						}
						if (visible.GetComponent("StrikerStats") != null)
						{
							StrikerStats script = visible.GetComponent<StrikerStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);

						}
						if (visible.GetComponent("SupportStats") != null)
						{
							SupportStats script = visible.GetComponent<SupportStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						}
					}
					if (visible.tag == "asteroid") //not actually a ship
					{
						((asteroidResources)visible.GetComponent("asteroidResources")).checkExpired();
					}
				}
			}
		}
		if (GameObject.Find ("player_type").tag == "master") {
			GameObject[] slaves = GameObject.FindGameObjectsWithTag ("slave");
			foreach (GameObject ship in slaves)
			{
				ship.renderer.material.color = new Color(ship.renderer.material.color.r, ship.renderer.material.color.g, ship.renderer.material.color.b, 0.0f);	
				if (ship.GetComponent("healunits") != null)
				{
					ship.renderer.material.color = new Color(ship.renderer.material.color.r, ship.renderer.material.color.g, ship.renderer.material.color.b,0.0f);
				}
			}
			GameObject[] masters = GameObject.FindGameObjectsWithTag ("master");
			foreach (GameObject ship in masters)
			{
				Collider[] visibles = Physics.OverlapSphere (ship.transform.position, visibility_radius);
				foreach (Collider visible in visibles)
				{
					if (visible.tag == "slave" || visible.tag == "master" || visible.tag == "select")
					{
						if (visible.gameObject.name == "healingsphere(Clone)")
						{
							visible.renderer.material.color = ((healunits)visible.GetComponent("healunits")).myColor;
						}
						else
						{
							visible.renderer.material.color = new Color(visible.renderer.material.color.r, visible.renderer.material.color.g, visible.renderer.material.color.b, 1.0f);
						}
						if (visible.GetComponent("ScoutStats") != null)
						{
							ScoutStats script = visible.GetComponent<ScoutStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						}
						if (visible.GetComponent("AntiDreadnoughtStats") != null)
						{
							AntiDreadnoughtStats script = visible.GetComponent<AntiDreadnoughtStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
							
						}
						if (visible.GetComponent("ArtilleryStats") != null)
						{
							ArtilleryStats script = visible.GetComponent<ArtilleryStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						}
						if (visible.GetComponent("CruiserStats") != null)
						{
							CruiserStats script = visible.GetComponent<CruiserStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
							
						}
						if (visible.GetComponent("DreadnoughtStats") != null)
						{
							DreadnoughtStats script = visible.GetComponent<DreadnoughtStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
							
						}
						if (visible.GetComponent("MiningStats") != null)
						{
							MiningStats script = visible.GetComponent<MiningStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
							
						}
						if (visible.GetComponent("SiegeStats") != null)
						{
							SiegeStats script = visible.GetComponent<SiegeStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
							
						}
						if (visible.GetComponent("StrikerStats") != null)
						{
							StrikerStats script = visible.GetComponent<StrikerStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
							
						}
						if (visible.GetComponent("SupportStats") != null)
						{
							SupportStats script = visible.GetComponent<SupportStats>();
							Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
							Texture myTexture = green;
							if (script.integrity < script.max_integrity * .7) {
								myTexture = yellow;
							}
							if (script.integrity < script.max_integrity * .35) {
								myTexture = red;
							}
							GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
							GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						}
					}
					if (visible.tag == "asteroid") //not actually a ship
					{
						((asteroidResources)visible.GetComponent("asteroidResources")).checkExpired();
					}
				}
			}
		}
		GameObject[] all = GameObject.FindGameObjectsWithTag ("select");
		foreach (GameObject ship in all)
		{
			Collider[] visibles = Physics.OverlapSphere (ship.transform.position, visibility_radius);
			foreach (Collider visible in visibles)
			{
				if (visible.tag == "slave" || visible.tag == "master" || visible.tag == "select")
				{
					if (visible.gameObject.name == "healingsphere(Clone)")
					{
						visible.renderer.material.color = ((healunits)visible.GetComponent("healunits")).myColor;
					}
					else
					{
						visible.renderer.material.color = new Color(visible.renderer.material.color.r, visible.renderer.material.color.g, visible.renderer.material.color.b, 1.0f);
					}
					if (visible.GetComponent("ScoutStats") != null)
					{
						ScoutStats script = visible.GetComponent<ScoutStats>();
						Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
						Texture myTexture = green;
						if (script.integrity < script.max_integrity * .7) {
							myTexture = yellow;
						}
						if (script.integrity < script.max_integrity * .35) {
							myTexture = red;
						}
						GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
						GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
					}
					if (visible.GetComponent("AntiDreadnoughtStats") != null)
					{
						AntiDreadnoughtStats script = visible.GetComponent<AntiDreadnoughtStats>();
						Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
						Texture myTexture = green;
						if (script.integrity < script.max_integrity * .7) {
							myTexture = yellow;
						}
						if (script.integrity < script.max_integrity * .35) {
							myTexture = red;
						}
						GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
						GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						
					}
					if (visible.GetComponent("ArtilleryStats") != null)
					{
						ArtilleryStats script = visible.GetComponent<ArtilleryStats>();
						Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
						Texture myTexture = green;
						if (script.integrity < script.max_integrity * .7) {
							myTexture = yellow;
						}
						if (script.integrity < script.max_integrity * .35) {
							myTexture = red;
						}
						GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
						GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
					}
					if (visible.GetComponent("CruiserStats") != null)
					{
						CruiserStats script = visible.GetComponent<CruiserStats>();
						Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
						Texture myTexture = green;
						if (script.integrity < script.max_integrity * .7) {
							myTexture = yellow;
						}
						if (script.integrity < script.max_integrity * .35) {
							myTexture = red;
						}
						GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
						GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						
					}
					if (visible.GetComponent("DreadnoughtStats") != null)
					{
						DreadnoughtStats script = visible.GetComponent<DreadnoughtStats>();
						Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
						Texture myTexture = green;
						if (script.integrity < script.max_integrity * .7) {
							myTexture = yellow;
						}
						if (script.integrity < script.max_integrity * .35) {
							myTexture = red;
						}
						GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
						GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						
					}
					if (visible.GetComponent("MiningStats") != null)
					{
						MiningStats script = visible.GetComponent<MiningStats>();
						Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
						Texture myTexture = green;
						if (script.integrity < script.max_integrity * .7) {
							myTexture = yellow;
						}
						if (script.integrity < script.max_integrity * .35) {
							myTexture = red;
						}
						GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
						GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						
					}
					if (visible.GetComponent("SiegeStats") != null)
					{
						SiegeStats script = visible.GetComponent<SiegeStats>();
						Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
						Texture myTexture = green;
						if (script.integrity < script.max_integrity * .7) {
							myTexture = yellow;
						}
						if (script.integrity < script.max_integrity * .35) {
							myTexture = red;
						}
						GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
						GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						
					}
					if (visible.GetComponent("StrikerStats") != null)
					{
						StrikerStats script = visible.GetComponent<StrikerStats>();
						Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
						Texture myTexture = green;
						if (script.integrity < script.max_integrity * .7) {
							myTexture = yellow;
						}
						if (script.integrity < script.max_integrity * .35) {
							myTexture = red;
						}
						GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
						GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
						
					}
					if (visible.GetComponent("SupportStats") != null)
					{
						SupportStats script = visible.GetComponent<SupportStats>();
						Vector3 currentPosition = Camera.main.WorldToScreenPoint (visible.transform.position);
						Texture myTexture = green;
						if (script.integrity < script.max_integrity * .7) {
							myTexture = yellow;
						}
						if (script.integrity < script.max_integrity * .35) {
							myTexture = red;
						}
						GUI.DrawTexture (new Rect(currentPosition.x - 20, Screen.height - currentPosition.y - 25, script.shield / script.max_shield * 40, 5), yellow, ScaleMode.StretchToFill);
						GUI.DrawTexture (new Rect (currentPosition.x - 20, Screen.height - currentPosition.y - 20, script.integrity / script.max_integrity * 40, 5), myTexture, ScaleMode.StretchToFill);
					}
				}
				if (visible.tag == "asteroid") //not actually a ship
				{
					((asteroidResources)visible.GetComponent("asteroidResources")).checkExpired();
				}
			}
		}
	}
}


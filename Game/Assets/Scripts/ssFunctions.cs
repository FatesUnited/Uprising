using UnityEngine;
using System.Collections;

/* Written by: b0rg
 * Last Modified: 3/20/14 18:30
 * Porpose: All functions of the spess station are included here,
 * including the production of units and the building of addons.
 */

public class ssFunctions : MonoBehaviour {
    public GameObject miner;
    public GameObject scout;
	public GameObject cruiser;
	public GameObject support;
	public GameObject striker;
	public GameObject artillery;
	public GameObject dreadnought;
	public GameObject aTank;
	public GameObject siege;

    public GameObject station;
	InGameGUI gui;

	/* Menu States:
     * 0 - Nothing
     * 1 - Main Menu (Choose to build units/addons)
     * 2 - Unit Menu (Choose which unit to build)
     * 3 - Addon Menu (Choose which addon to build)
     */
    public int menuState;

	/* Tier States:
     * 1 - Early Tier
     * 2 - Middle Tier
     * 3 - End Tier
     */
    public int currTier;

	/* Variable Naming
	 * s<name> - cost to spawn that unit
	 * r<name> - cost to research that unit
	 */
    // Tier 1
    public int cruiserUnlock;
	int sMiner;
	int sScout;
	int sCruiser;
	int rCruiser;

    // Tier 2
    public int strikerUnlock;
    public int artilleryUnlock;
	int sSupport;
	int sStriker;
	int sArtillery;
	int rStriker;
	int rArtillery;
	
    // Tier 3
    public int siegeUnlock;
    public int aTankUnlock;
	public int sDreadnought;
	int sSiege;
	int sATank;
	int rSiege;
	int rATank;

	// Use this for initialization
	void Start () {
        menuState = 0;

        currTier = 1;// player starts at Tier 1

		if (GameObject.Find("player_type").tag == "master") {
			GameObject masterStation = GameObject.Find("ssp1");
			gui = (InGameGUI)Camera.main.GetComponent("InGameGUI");
			//menuState = ss.menuState;
		}else if (GameObject.Find("player_type").tag == "slave") {
			GameObject slaveStation = GameObject.Find("ssp2");
			gui = (InGameGUI)Camera.main.GetComponent("InGameGUI");
			//menuState = ss.menuState;
		}
		
		// Unlock State
		cruiserUnlock = 0;
		strikerUnlock = 0;
		artilleryUnlock = 0;
        siegeUnlock = 0;
        aTankUnlock = 0;

		// Unit Spawn Costs
		sMiner = 25;
		sScout = 50;
		sCruiser = 75;
		sSupport = 60;
		sStriker = 90;
		sArtillery = 100;
		sDreadnought = 175;
		sSiege = 125;
		sATank = 125;

		// Unit Research Costs
		rCruiser = 75;
		rStriker = 90;
		rArtillery = 100;
		rSiege = 125;
		rATank = 125;
	}// end Start
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (this.name + " " + this.tag);
        if (station.tag == "select" && menuState == 0)
            menuState = 1;
        if (station.tag != "select")
            menuState = 0;

        if (Input.GetButtonDown("v") && (menuState == 2 || menuState == 3))
            menuState = 1;

        if (menuState == 1)
            StateOne();
        else if (menuState == 2)
            StateTwo();
        else if (menuState == 3)
            StateThree();
	}// end Update

    void StateOne() {
        // option to build units
        if (Input.GetButtonDown("q"))
            menuState = 2;
        if (Input.GetButtonDown("w"))
            menuState = 3;

        if (Input.GetButtonDown("z"))
        {
            if(currTier == 1 && ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= 100){
				((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources -= 100;
                currTier = 2;
            }else if(currTier == 2 && ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= 250){
				((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources -= 250;
                currTier = 3;
            }// end if-else if
        }// end if
    }// end StateOne

    // ship building options
    void StateTwo() {
        if (Input.GetButtonDown("q")) {
            // instantiate mining ship relative to masterStation's position
            gui.result = SpawnMiner();
        }// end build mining ship
        if (Input.GetButtonDown("w")) {
            // instantiate scout ship relative to masterStation's position
			gui.result = SpawnScout();
        }// end build scout ship
        if (Input.GetButtonDown("e")) {
			gui.result = SpawnCruiser();
        }// end build Cruiser Ship
        if (Input.GetButtonDown("a")) {
			gui.result = SpawnSupport();
        }
        if (Input.GetButtonDown("s")) {
			gui.result = SpawnStriker();
        }
        if (Input.GetButtonDown("d")) {
			gui.result = SpawnArtillery();
        }
        if (Input.GetButtonDown("z")) {
			gui.result = SpawnDreadnought();
        }
        if (Input.GetButtonDown("x")) {
			gui.result = SpawnSiege();
        }
        if (Input.GetButtonDown("c")) {
			gui.result = SpawnAntiTank();
        }

        if (Input.GetButtonDown("v") && (menuState == 2 || menuState == 3))
            menuState = 1;
    }// end StateTwo

    void StateThree() {
        if (Input.GetButtonDown("q")) {
			gui.result = researchCruiser();
        }
        if (Input.GetButtonDown("a")) {
			gui.result = researchStriker();
        }
        if (Input.GetButtonDown("s")) {
			gui.result = researchArtillery();
        }
        if (Input.GetButtonDown("z")) {
			gui.result = researchSiege();
        }
        if (Input.GetButtonDown("x")) {
			gui.result = researchATank();
        }
        
        if (Input.GetButtonDown("v") && (menuState == 2 || menuState == 3))
            menuState = 1;
    }// end StateThree

    // Ship spawn/research helper functions
    // Tier 1
    public int SpawnMiner() {
		if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources >= sMiner) {
			((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources -= sMiner;
			Vector3 rand = Random.insideUnitSphere / 10;
			Vector3 pos = new Vector3(station.transform.position.x + 0.5f, station.transform.position.y, station.transform.position.z + 0.5f);
			pos = pos + rand;
			pos = new Vector3(pos.x, station.transform.position.y, pos.z);
        	Network.Instantiate(miner, pos, Quaternion.identity, 0);
			return 0;
		}// end if
		if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < sMiner)
			return 3;

		return 8;
    }// end SpawnMiner

	public int SpawnScout() {
		if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources >= sScout) {
			((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources -= sScout;
			Vector3 rand = Random.insideUnitSphere / 10;
			Vector3 pos = new Vector3(station.transform.position.x + 0.5f, station.transform.position.y, station.transform.position.z + 0.5f);
			pos = pos + rand;
			pos = new Vector3(pos.x, station.transform.position.y, pos.z);        	
			Network.Instantiate(scout, pos, Quaternion.identity, 0);
			return 0;
		}// end if
		if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < sScout)
			return 3;

		return 8;
    }// end SpawnScout

    public int SpawnCruiser() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= sCruiser && cruiserUnlock == 1) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= sCruiser;
			Vector3 rand = Random.insideUnitSphere / 10;
			Vector3 pos = new Vector3(station.transform.position.x + 0.5f, station.transform.position.y, station.transform.position.z + 0.5f);
			pos = pos + rand;
			pos = new Vector3(pos.x, station.transform.position.y, pos.z);			Network.Instantiate(cruiser, pos, Quaternion.identity, 0);
        }// end if
		if (cruiserUnlock != 1)
			return 2;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < sCruiser)
			return 3;

		return 8;
    }// end SpawnCruiser

    public int researchCruiser() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= rCruiser && cruiserUnlock == 0) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= rCruiser;
            cruiserUnlock = 1;
			return 0;
        }// end if

		if (cruiserUnlock == 1)
			return 4;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < rCruiser)
			return 3;

		return 8;
    }// end researchCruiser

    // Tier 2
    public int SpawnSupport() { 
        if(((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= sSupport && currTier >= 2) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= sSupport;
			Vector3 rand = Random.insideUnitSphere / 10;
			Vector3 pos = new Vector3(station.transform.position.x + 0.5f, station.transform.position.y, station.transform.position.z + 0.5f);
			pos = pos + rand;
			pos = new Vector3(pos.x, station.transform.position.y, pos.z);			Network.Instantiate(support, pos, Quaternion.identity, 0);
			return 0;
        }// end if

		if (currTier < 2)
			return 1;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < sSupport)
			return 3;

		return 8;
    }// end SpawnSupport

    public int SpawnStriker() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= sStriker && currTier >= 2 && strikerUnlock == 1) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= sStriker;
			Vector3 rand = Random.insideUnitSphere / 10;
			Vector3 pos = new Vector3(station.transform.position.x + 0.5f, station.transform.position.y, station.transform.position.z + 0.5f);
			pos = pos + rand;
			pos = new Vector3(pos.x, station.transform.position.y, pos.z);			Network.Instantiate(striker, pos, Quaternion.identity, 0);
			return 0;
        }// end if

		if (currTier < 2)
			return 1;
		else if (strikerUnlock != 1)
			return 2;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < sStriker)
			return 3;

		return 8;
    }// end SpawnStriker

    public int SpawnArtillery() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= sArtillery && currTier >= 2 && artilleryUnlock == 1) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= sArtillery;
			Vector3 rand = Random.insideUnitSphere / 10;
			Vector3 pos = new Vector3(station.transform.position.x + 0.5f, station.transform.position.y, station.transform.position.z + 0.5f);
			pos = pos + rand;
			pos = new Vector3(pos.x, station.transform.position.y, pos.z);			Network.Instantiate(artillery, pos, Quaternion.identity, 0);
			return 0;
        }// end if

		if (currTier < 2)
			return 1;
		else if (artilleryUnlock != 1)
			return 2;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < sArtillery)
			return 3;

		return 8;
    }// end SpawnArtillery

    public int researchStriker() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= rStriker && currTier >= 2 && strikerUnlock == 0) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= rStriker;
            strikerUnlock = 1;
			return 0;
        }// end if

		if (strikerUnlock == 1)
			return 4;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < rStriker)
			return 3;

		return 8;
    }// end researchStriker

    public int researchArtillery() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= rArtillery && currTier >= 2 && artilleryUnlock == 0) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= rArtillery;
            artilleryUnlock = 1;
			return 0;
        }// end if

		if (artilleryUnlock == 1)
			return 4;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < rArtillery)
			return 3;

		return 8;
    }// end researchArtillery

    // Tier 3
    public int SpawnDreadnought() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= sDreadnought && currTier >= 3) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= sDreadnought;
			Vector3 rand = Random.insideUnitSphere / 10;
			Vector3 pos = new Vector3(station.transform.position.x + 0.5f, station.transform.position.y, station.transform.position.z + 0.5f);
			pos = pos + rand;
			pos = new Vector3(pos.x, station.transform.position.y, pos.z);			Network.Instantiate(dreadnought, pos, Quaternion.identity, 0);
			return 0;
        }// end if   

		if (currTier < 3)
			return 1;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < sDreadnought)
			return 3;

		return 8;
    }// end SpawnDreadnought

    public int SpawnSiege() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= sSiege && currTier >= 3 && siegeUnlock == 1) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= sSiege;
			Vector3 rand = Random.insideUnitSphere / 10;
			Vector3 pos = new Vector3(station.transform.position.x + 0.5f, station.transform.position.y, station.transform.position.z + 0.5f);
			pos = pos + rand;
			pos = new Vector3(pos.x, station.transform.position.y, pos.z);			Network.Instantiate(siege, pos, Quaternion.identity, 0);
			return 0;
        }// end if

		if (currTier < 3)
			return 1;
		else if (siegeUnlock != 1)
			return 2;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < sSiege)
			return 3;

		return 8;
    }// end SpawnSiege

    public int SpawnAntiTank() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= sATank && currTier >= 3 && aTankUnlock == 1) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= sATank;
			Vector3 rand = Random.insideUnitSphere / 10;
			Vector3 pos = new Vector3(station.transform.position.x + 0.5f, station.transform.position.y, station.transform.position.z + 0.5f);
			pos = pos + rand;
			pos = new Vector3(pos.x, station.transform.position.y, pos.z);			Network.Instantiate(aTank, pos, Quaternion.identity, 0);
			return 0;
        }// end if

		if (currTier < 3)
			return 1;
		else if (aTankUnlock != 1)
			return 2;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < sATank)
			return 3;

		return 8;
    }// end SpawnAntiTank

    public int researchSiege() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= rSiege && currTier >= 3 && siegeUnlock == 0) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= rSiege;
            siegeUnlock = 1;
			return 0;
        }// end if

		if (currTier < 3)
			return 1;
		else if (siegeUnlock == 1)
			return 4;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < rSiege)
			return 3;

		return 8;
    }// end researchSiege

    public int researchATank() {
        if (((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= rATank && currTier >= 3 && aTankUnlock == 0) {
            ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources -= rATank;
            aTankUnlock = 1;
			return 0;
        }// end if

		if (currTier < 3)
			return 1;
		else if (aTankUnlock == 1)
			return 4;
		else if (((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources < rATank)
			return 3;

		return 8;
    }// end researchATank

}// end ssFunctions

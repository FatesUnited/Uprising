using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Written by: b0rg
 * Last Modified: 3/20/14 18:32
 * Porpose: Drawing the boxes, buttons for the GUI and updating
 * information in their respective fields
 */

// GUI Reference: https://docs.unity3d.com/Documentation/ScriptReference/GUI.html
// GUI Basics: http://docs.unity3d.com/Documentation/Components/gui-Basics.html

public class InGameGUI : MonoBehaviour {
    // global vars
    float screenWidth, screenHeight;
    float buttonWidth, buttonHeight;
    Rect map, info, command, button, status;
    ssFunctions ss;
	public int result;
	string[] labels;
	string[] stateZeroLabels;
	string[] stateOneLabels;
	string[] stateTwoLabels;
	string[] stateThreeLabels;
	string[] errorMessages;

	// public vars
	public Texture2D defaultPic;
	public GUISkin defaultSkin;
	//public GUIText myText;
	public int menuState;

	// Ian's edits
	public List<GameObject> selected;
	public Texture antitank;
	public Texture antitank_y;
	public Texture artillery;
	public Texture artillery_y;
	public Texture cruiser;
	public Texture cruiser_y;
	public Texture dreadnought;
	public Texture dreadnought_y;
	public Texture miner;
	public Texture miner_y;
	public Texture scout;
	public Texture scout_y;
	public Texture siege;
	public Texture siege_y;
	public Texture striker;
	public Texture striker_y;
	public Texture support;
	public Texture support_y;
	public int select_select = 0;

	public bool escMenu = false;
	string[] tips;
	string[] stateZeroTips;
	string[] stateOneTips;
	string[] stateTwoTips;
	string[] stateThreeTips;
    string[] ssResearchStatus;

	// Use this for initialization
    void Start() {
		labels = new string[12];
		//stateZeroLabels = new string[12];
		stateZeroLabels = new string[12] { "", "", "", "", "", "", "", "", "", "", "", "" };
		//stateOneLabels = new string[12];
		stateOneLabels = new string[12] { "Units", "Addons", "", "", "", "", "", "", "Next Tier", "", "", "" };
		//stateTwoLabels = new string[12];
		stateTwoLabels = new string[12] { "Miner", "Scout", "Cruiser", "", "Support", "Striker", "Artillery", "", "Dread-\nnought", "Siege", "Anti\nTank", "Back" };
		//stateThreeLabels = new string[12];
		stateThreeLabels = new string[12] { "Cruiser\nResearch", "", "", "", "Striker\nResearch", "Artillery\nResearch", "", "", "Siege\nResearch", "Anti-Tank\nResearch", "", "Back" };

        ssResearchStatus = new string[2] { "Not Researched", "Researched" };

		tips = new string[12];
		//stateZeroLabels = new string[12];
		stateZeroTips = new string[12] { "", "", "", "", "", "", "", "", "", "", "", "" };
		//stateOneLabels = new string[12];
        stateOneTips = new string[12] { "Hotkey: Q\nSelect units to build in this menu", 
            "Hotkey: W\nPurchasing Addons will allow you to build better ships", "", "", "", "", "", "", 
            "Resource Cost: 100 - Tier 2\nResource Cost: 250 - Tier 3\nHotkey: Z\nResearching the Next Tier will allow you to build new Addons", "", "", "" };
		//stateTwoLabels = new string[12];
		stateTwoTips = new string[12] { "Resource Cost: 25 - Hotkey: Q\nThis ship collects additional resources\nTech Requirements\n - None", 
            "Resource Cost: 50 - Hotkey: W\nA light fighter with fast movement\nTech Requirements\n - None", 
            "Resource Cost: 75 - Hotkey: E\nThe Cruiser is the cheap, reliable bulk of most forces\nTech Requirements\n - Cruiser Research", "", 
            "Resource Cost: 60 - Hotkey: A\nThe Support ship repairs ships on the move\nTech Requirements\n - Tier 2 Research", 
            "Resource Cost: 90 - Hotkey: S\nThe Striker is a fragile, hard hitting fighter\nTechRequirements\n - Tier 2 Research\n - Striker Research", 
            "Resource Cost: 100 - Hotkey: D\nThis ship is a slow, long range fire support ship\nTech Requirements\n - Tier 2 Research\n - Artillery Research", "", 
            "Resource Cost: 175 - Hotkey: Z\nThis ship is a slow, tough, short range ship\nTech Requirements\n - Tier 3 Research", 
            "Resource Cost: 125 - Hotkey: X\nThis long range ship that specializes in destroying buildings\nTech Requirements\n - Tier 3 Research\n - Siege Research", 
            "Resource Cost: 125 - Hotkey: C\nThis ship specializes in fighting large, sturdy ships\nTech Requirements\n - Tier 3 Research\n - Anti-Tank Research", " Return to previous menu" };
		//stateThreeLabels = new string[12];
		stateThreeTips = new string[12] { "Resource Cost: 75 - Hotkey: Q\nAllows the production of Cruisers\nTech Requirements\n - None", "", "", "", 
            "Resource Cost: 90 - Hotkey: A\nAllows the production of Strikers\nTech Requirements\n - Tier 2 Research", 
            "Resource Cost: 100 - Hotkey: S\nAllows the production of Artillery\nTech Requirements\n - Tier 2 Research", "", "", 
            "Resource Cost: 125 - Hotkey: Z\nAllows the production of Siege Ships\nTech Requirements\n - Tier 3 Research", 
            "Resource Cost: 125 - Hotkey: X\nAllows the production of Anti-Tank ships\nTech Requirements\n - Tier 3 Research", "", "Hotkey:V\nReturn to previous menu" };
		
		/* Error Messages
		 * 0 - No error
		 * 1 - Not at appropriate Tier (upgrade to necessary tier)
		 * 2 - Unit not unlocked through research
		 * 3 - Insufficient resources to complete action
		 * 4 - already reserached
		 */
		errorMessages = new string[10] { "", "Not at appropriate Tech Tier", "Unit Not Researched", "Insufficient Resources",
			"Unit Already Researached", "", "", "", "", "YOU MUST CONSTRUCT ADDITIONAL PYLONS"};

        screenWidth = Screen.width;
        screenHeight = Screen.height;
        buttonWidth = screenWidth / 16;
        buttonHeight = screenHeight / 12;

        // where the minimap box is
        map = new Rect (0, ((2 * screenHeight) / 3), screenWidth / 4, screenHeight / 3);
        // where the information box is
        info = new Rect (screenWidth / 4, ((3 * screenHeight) / 4), screenWidth / 2, screenHeight / 4);
        // where the command box is
        command = new Rect (((3 * screenWidth) / 4), ((3 * screenHeight) / 4), screenWidth / 4, screenHeight / 4);
		// status message box
		status = new Rect (screenWidth / 4, ((5.5f * screenHeight) / 8), screenWidth / 2, screenHeight / 16);

		result = 9;
	}// end of Start

    // called once every frame
    void OnGUI() {
				GUI.skin = defaultSkin;
				//GUI.Box(map, defaultPic);
				GUI.Box (map, "");// map box
				GUI.Box (info, "");// info box
				GUI.Box (command, "");// command box
				GUI.Box (status, errorMessages[result]);// status message box

		// On pressing ESC, opens escape menu GUI
		if (Input.GetKeyDown(KeyCode.Escape))
		{ 
			escMenu = true;
		}
		if (escMenu == true)
		{
			if (GUI.Button (new Rect (500, 185, 200, 50), "Close Menu"))
			{
				escMenu = false;
			}
			if (GameObject.Find("Main Camera").GetComponent<AudioSource>().audio.mute == true)
			{
				if (GUI.Button (new Rect (500, 250, 200, 50), "Unmute SPACE AMBIANCE"))
				{
					GameObject.Find("Main Camera").GetComponent<AudioSource>().audio.mute = false;
					escMenu = false;
				}
			}
			else
			{
				if (GUI.Button (new Rect (500, 250, 200, 50), "Mute SPACE AMBIANCE"))
				{
					GameObject.Find("Main Camera").GetComponent<AudioSource>().audio.mute = true;
					escMenu = false;
				}
			}
			if (GUI.Button (new Rect (500, 315, 200, 50), "Forfeit"))
			{
				escMenu = false;
				Network.Disconnect();
				if (GameObject.Find ("player_type").tag == "master") {
					MasterServer.UnregisterHost();
				}
				Application.LoadLevel ("gameover");
			}
		}

				if (selected != null) {
						for (int i = 0; i < selected.Count; i++) {
								if (select_select == i) {								
										if (selected [i].GetComponent ("ScoutStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), scout_y, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("AntiDreadnoughtStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), antitank_y, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("ArtilleryStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), artillery_y, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("CruiserStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), cruiser_y, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("DreadnoughtStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), dreadnought_y, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("MiningStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), miner_y, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("SiegeStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), siege_y, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("StrikerStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), striker_y, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("SupportStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), support_y, ScaleMode.StretchToFill);
								} else {
										if (selected [i].GetComponent ("ScoutStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), scout, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("AntiDreadnoughtStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), antitank, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("ArtilleryStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), artillery, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("CruiserStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), cruiser, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("DreadnoughtStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), dreadnought, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("MiningStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), miner, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("SiegeStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), siege, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("StrikerStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), striker, ScaleMode.StretchToFill);
										if (selected [i].GetComponent ("SupportStats") != null)
												GUI.DrawTexture (new Rect (screenWidth / 4 + 10 + (i % 7) * 20, 3 * screenHeight / 4 + 10 + Mathf.Floor (i / 3) * 20, 20, 20), support, ScaleMode.StretchToFill);
								}
						}
						GameObject ship;
						if (select_select < selected.Count)
							ship = selected [select_select];
						else
							ship = null;
						if (ship != null) {
								if (ship.GetComponent ("ScoutStats") != null) {
										ScoutStats script = ship.GetComponent <ScoutStats> ();
										GUI.Label (new Rect (screenWidth / 4 + 200, 3 * screenHeight / 4 + 2, 100, 180), 
				           "Scout\n---------------\n" +
												"Integrity: " + script.integrity + "/" + script.max_integrity + "\n" +
												"Shield: " + script.shield + "/" + script.max_shield + "\n" +
												"Shield Resist: " + (1 - script.shieldResist) * 100 + "%\n" +
												"Damage: " + script.damage);
										GUI.Label (new Rect (screenWidth / 4 + 310, 3 * screenHeight / 4 + 32, 100, 180),
					   				            "Rate Of Fire: " + script.rateOfFire + "\n" +
												"Range: " + script.range + "\n" +
												"Penetration: " + script.penetration + "\n" +
												"Speed: " + "0");
								}
								if (ship.GetComponent ("AntiDreadnoughtStats") != null) {
										AntiDreadnoughtStats script = ship.GetComponent <AntiDreadnoughtStats> ();
										GUI.Label (new Rect (screenWidth / 4 + 200, 3 * screenHeight / 4 + 2, 100, 180), 
				           "Anti-Dreadnought\n---------------\n" +
												"Integrity: " + script.integrity + "/" + script.max_integrity + "\n" +
												"Shield: " + script.shield + "/" + script.max_shield + "\n" +
					           "Shield Resist: " + (1 - script.shieldResist) * 100 + "%\n" +
												"Damage: " + script.damage);
										GUI.Label (new Rect (screenWidth / 4 + 310, 3 * screenHeight / 4 + 32, 100, 180),
				           "Rate Of Fire: " + script.rateOfFire + "\n" +
												"Range: " + script.range + "\n" +
												"Penetration: " + script.penetration + "\n" +
												"Speed: " + "0");
								}
								if (ship.GetComponent ("ArtilleryStats") != null) {
										ArtilleryStats script = ship.GetComponent <ArtilleryStats> ();
										GUI.Label (new Rect (screenWidth / 4 + 200, 3 * screenHeight / 4 + 2, 100, 180), 
				           "Artillery\n---------------\n" +
												"Integrity: " + script.integrity + "/" + script.max_integrity + "\n" +
												"Shield: " + script.shield + "/" + script.max_shield + "\n" +
					           "Shield Resist: " + (1 - script.shieldResist) * 100 + "%\n" +
												"Damage: " + script.damage);
										GUI.Label (new Rect (screenWidth / 4 + 310, 3 * screenHeight / 4 + 32, 100, 180),
				           "Rate Of Fire: " + script.rateOfFire + "\n" +
												"Range: " + script.range + "\n" +
												"Penetration: " + script.penetration + "\n" +
												"Speed: " + "0");
								}
								if (ship.GetComponent ("CruiserStats") != null) {
										CruiserStats script = ship.GetComponent <CruiserStats> ();
										GUI.Label (new Rect (screenWidth / 4 + 200, 3 * screenHeight / 4 + 2, 100, 180), 
				           "Cruiser\n---------------\n" +
												"Integrity: " + script.integrity + "/" + script.max_integrity + "\n" +
												"Shield: " + script.shield + "/" + script.max_shield + "\n" +
					           "Shield Resist: " + (1 - script.shieldResist) * 100 + "%\n" +
												"Damage: " + script.damage);
										GUI.Label (new Rect (screenWidth / 4 + 310, 3 * screenHeight / 4 + 32, 100, 180),
				           "Rate Of Fire: " + script.rateOfFire + "\n" +
												"Range: " + script.range + "\n" +
					           "Penetration: " + (1 - script.shieldResist) * 100 + "%\n" +
												"Speed: " + "0");
								}
								if (ship.GetComponent ("DreadnoughtStats") != null) {
										DreadnoughtStats script = ship.GetComponent <DreadnoughtStats> ();
										GUI.Label (new Rect (screenWidth / 4 + 200, 3 * screenHeight / 4 + 2, 100, 180), 
				           "Dreadnought\n---------------\n" +
												"Integrity: " + script.integrity + "/" + script.max_integrity + "\n" +
												"Shield: " + script.shield + "/" + script.max_shield + "\n" +
					           "Shield Resist: " + (1 - script.shieldResist) * 100 + "%\n" +
					           					"Damage: "+ script.damage);
										GUI.Label (new Rect (screenWidth / 4 + 310, 3 * screenHeight / 4 + 32, 100, 180),
				           "Rate Of Fire: " + script.rateOfFire + "\n" +
												"Range: " + script.range + "\n" +
					           "Penetration: " + (1 - script.shieldResist) * 100 + "%\n" +
												"Speed: " + "0");
								}
								if (ship.GetComponent ("MiningStats") != null) {
										MiningStats script = ship.GetComponent <MiningStats> ();
										GUI.Label (new Rect (screenWidth / 4 + 200, 3 * screenHeight / 4 + 2, 100, 180), 
				           "Miner\n---------------\n" +
												"Integrity: " + script.integrity + "/" + script.max_integrity + "\n" +
												"Shield: " + script.shield + "/" + script.max_shield + "\n" +
					           "Shield Resist: " + (1 - script.shieldResist) * 100 + "%\n" +
												"Damage: 0\n");
										GUI.Label (new Rect (screenWidth / 4 + 310, 3 * screenHeight / 4 + 32, 100, 180),
				           "Rate Of Fire: 0\n" +
												"Range: 0\n" +
												"Penetration: 0\n" +
												"Speed: " + "0");
								}
								if (ship.GetComponent ("SiegeStats") != null) {
										SiegeStats script = ship.GetComponent <SiegeStats> ();
										GUI.Label (new Rect (screenWidth / 4 + 200, 3 * screenHeight / 4 + 2, 100, 180), 
				           "Siege\n---------------\n" +
												"Integrity: " + script.integrity + "/" + script.max_integrity + "\n" +
												"Shield: " + script.shield + "/" + script.max_shield + "\n" +
					           "Shield Resist: " + (1 - script.shieldResist) * 100 + "%\n" +
												"Damage: " + script.damage);
										GUI.Label (new Rect (screenWidth / 4 + 310, 3 * screenHeight / 4 + 32, 100, 180),
				           "Rate Of Fire: " + script.rateOfFire + "\n" +
												"Range: " + script.range + "\n" +
												"Penetration: " + script.penetration + "\n" +
												"Speed: " + "0");
								}
								if (ship.GetComponent ("StrikerStats") != null) {
										StrikerStats script = ship.GetComponent <StrikerStats> ();
										GUI.Label (new Rect (screenWidth / 4 + 200, 3 * screenHeight / 4 + 2, 100, 180), 
				           "Striker\n---------------\n" +
												"Integrity: " + script.integrity + "/" + script.max_integrity + "\n" +
												"Shield: " + script.shield + "/" + script.max_shield + "\n" +
					           "Shield Resist: " + (1 - script.shieldResist) * 100 + "%\n" +
												"Damage: " + script.damage);
										GUI.Label (new Rect (screenWidth / 4 + 310, 3 * screenHeight / 4 + 32, 100, 180),
				           "Rate Of Fire: " + script.rateOfFire + "\n" +
												"Range: " + script.range + "\n" +
												"Penetration: " + script.penetration + "\n" +
												"Speed: " + "0");
								}	
								if (ship.GetComponent ("SupportStats") != null) {
										SupportStats script = ship.GetComponent <SupportStats> ();
										GUI.Label (new Rect (screenWidth / 4 + 200, 3 * screenHeight / 4 + 2, 100, 180), 
				           "Support\n---------------\n" +
												"Integrity: " + script.integrity + "/" + script.max_integrity + "\n" +
												"Shield: " + script.shield + "/" + script.max_shield + "\n" +
					           "Shield Resist: " + (1 - script.shieldResist) * 100 + "%\n" +
												"Damage: 0\n");
										GUI.Label (new Rect (screenWidth / 4 + 310, 3 * screenHeight / 4 + 32, 100, 180),
				           "Rate Of Fire: 0\n" +
												"Range: 0\n" +
												"Penetration: 0\n" +
												"Speed: " + "0");
								}

		
						}
				}
        float startX, startY, guiX, guiY;
        startX = (3 * screenWidth) / 4;
        startY = (3 * screenHeight) / 4;
		guiX = startX;
		guiY = startY - 2 * buttonHeight;

		//myText.text = "Resources: " + ((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources;

        if (GameObject.Find("player_type").tag == "master") {
            GameObject masterStation = GameObject.Find("ssp1(Clone)");
             ss = (ssFunctions)masterStation.GetComponent("ssFunctions");
            menuState = ss.menuState;
        }else if (GameObject.Find("player_type").tag == "slave") {
            GameObject slaveStation = GameObject.Find("ssp2(Clone)");
            ss = (ssFunctions)slaveStation.GetComponent("ssFunctions");
            menuState = ss.menuState;
        }

        if (menuState == 0)
		{
            labels = stateZeroLabels;
			tips = stateZeroTips;
            GUI.Box(info, "Resources: " + ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources);
		}
        else if (menuState == 1)
		{
            labels = stateOneLabels;
			tips = stateOneTips;
            GUI.Box(info, "Resources: " + ((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources + "\n\nCurrent Tier: " + ss.currTier +
                        "\nCruiser: " + ssResearchStatus[ss.cruiserUnlock] +
                        "\nStriker: " + ssResearchStatus[ss.strikerUnlock] +
                        "\nSiege: " + ssResearchStatus[ss.siegeUnlock] +
                        "\nAnti-Tank: " + ssResearchStatus[ss.aTankUnlock]);// info box
		}
        else if (menuState == 2)
		{
            labels = stateTwoLabels;
			tips = stateTwoTips;
            GUI.Box(info, "Current Tier: " + ss.currTier +
                        "\nCruiser: " + ssResearchStatus[ss.cruiserUnlock] +
                        "\nStriker: " + ssResearchStatus[ss.strikerUnlock] +
                        "\nSiege: " + ssResearchStatus[ss.siegeUnlock] +
                        "\nAnti-Tank: " + ssResearchStatus[ss.aTankUnlock]);// info box
		}
        else if (menuState == 3)
		{
            labels = stateThreeLabels;
			tips = stateThreeTips;
            GUI.Box(info, "Current Tier: " + ss.currTier +
                        "\nCruiser: " + ssResearchStatus[ss.cruiserUnlock] +
                        "\nStriker: " + ssResearchStatus[ss.strikerUnlock] +
                        "\nSiege: " + ssResearchStatus[ss.siegeUnlock] +
                        "\nAnti-Tank: " + ssResearchStatus[ss.aTankUnlock]);// info box
		}

        // row 1
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[0])) {
            //print("Q pressed");
            if (menuState == 1)
                ss.menuState = 2;
            else if (menuState == 2)
                result = ss.SpawnMiner();
			else if (menuState == 3)
				result = ss.researchCruiser ();
        }
		if (Input.mousePosition.x > screenWidth-4*buttonWidth && Input.mousePosition.x < screenWidth-3*buttonWidth)
		{
			if (Input.mousePosition.y > 2*buttonHeight && Input.mousePosition.y < 3*buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[0]);
				}
				else if (menuState == 2)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[0]);
				}
				else if (menuState == 3)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[0]);
				}
			}
		}
		startX += buttonWidth;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[1])) {
            //print("W pressed");
            if (menuState == 1)
                ss.menuState = 3;
            else if (menuState == 2)
                result = ss.SpawnScout();
        }
		if (Input.mousePosition.x > screenWidth-3*buttonWidth && Input.mousePosition.x < screenWidth-2*buttonWidth)
		{
			if (Input.mousePosition.y > 2*buttonHeight && Input.mousePosition.y < 3*buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[1]);
				}
				else if (menuState == 2)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[1]);
				}
				else if (menuState == 3)
				{
					//No GUI
				}
			}
		}
        startX += buttonWidth;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[2])) {
            //print("E pressed");
			if(menuState == 2)
				result = ss.SpawnCruiser ();
        }
		if (Input.mousePosition.x > screenWidth-2*buttonWidth && Input.mousePosition.x < screenWidth-buttonWidth)
		{
			if (Input.mousePosition.y > 2*buttonHeight && Input.mousePosition.y < 3*buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					//No GUI
				}
				else if (menuState == 2)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[2]);
				}
				else if (menuState == 3)
				{
					//No GUI
				}
			}
		}
        startX += buttonWidth;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[3])) {
            //print("R pressed");
        }
		if (Input.mousePosition.x > screenWidth-buttonWidth && Input.mousePosition.x < screenWidth)
		{
			if (Input.mousePosition.y > 2*buttonHeight && Input.mousePosition.y < 3*buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					//No GUI
				}
				else if (menuState == 2)
				{
					//No GUI
				}
				else if (menuState == 3)
				{
					//No GUI
				}
			}
		}
        // row 2
        startX = (3 * screenWidth) / 4;
        startY += buttonHeight;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[4])) {
            //print("A pressed");
			if(menuState == 2)
				result = ss.SpawnSupport ();
			if(menuState == 3)
				result = ss.researchStriker();
        }
		if (Input.mousePosition.x > screenWidth-4*buttonWidth && Input.mousePosition.x < screenWidth-3*buttonWidth)
		{
			if (Input.mousePosition.y > buttonHeight && Input.mousePosition.y < 2*buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					//No GUI
				}
				else if (menuState == 2)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[4]);
				}
				else if (menuState == 3)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[4]);
				}
			}
		}
        startX += buttonWidth;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[5])) {
            //print("S pressed");
			if(menuState == 2)
				result = ss.SpawnStriker ();
			if(menuState == 3)
				result = ss.researchArtillery();
        }
		if (Input.mousePosition.x > screenWidth-3*buttonWidth && Input.mousePosition.x < screenWidth-2*buttonWidth)
		{
			if (Input.mousePosition.y > buttonHeight && Input.mousePosition.y < 2*buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					//No GUI
				}
				else if (menuState == 2)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[5]);
				}
				else if (menuState == 3)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[5]);
				}
			}
		}
        startX += buttonWidth;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[6])) {
            //print("D pressed");
			if(menuState == 2)
				result = ss.SpawnArtillery ();
        }
		if (Input.mousePosition.x > screenWidth-2*buttonWidth && Input.mousePosition.x < screenWidth-buttonWidth)
		{
			if (Input.mousePosition.y > buttonHeight && Input.mousePosition.y < 2*buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					//No GUI
				}
				else if (menuState == 2)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[6]);
				}
				else if (menuState == 3)
				{
					//No GUI
				}
			}
		}
        startX += buttonWidth;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[7])) {
            //print("F pressed");
        }
		if (Input.mousePosition.x > screenWidth-buttonWidth && Input.mousePosition.x < screenWidth)
		{
			if (Input.mousePosition.y > buttonHeight && Input.mousePosition.y < 2*buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					//No GUI
				}
				else if (menuState == 2)
				{
					//No GUI
				}
				else if (menuState == 3)
				{
					//No GUI
				}
			}
		}
        // row 3
        startX = (3 * screenWidth) / 4;
        startY += buttonHeight;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[8])) {
            //print("Z pressed");
			if(menuState == 1){
				// upgrade to next tier
				if(ss.currTier == 1 && ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= 100){
					((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources -= 100;
					ss.currTier = 2;
				}else if(ss.currTier == 2 && ((SaveThis)GameObject.Find("player_type").GetComponent("SaveThis")).resources >= 250){
					((SaveThis)GameObject.Find ("player_type").GetComponent ("SaveThis")).resources -= 250;
					ss.currTier = 3;
				}// end if-else if
			} else if(menuState == 2)
				result = ss.SpawnDreadnought ();
			else if(menuState == 3)
				result = ss.researchSiege ();
        }
		if (Input.mousePosition.x > screenWidth-4*buttonWidth && Input.mousePosition.x < screenWidth-3*buttonWidth)
		{
			if (Input.mousePosition.y > 0 && Input.mousePosition.y < buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[8]);
				}
				else if (menuState == 2)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[8]);
				}
				else if (menuState == 3)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[8]);
				}
			}
		}
        startX += buttonWidth;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[9])) {
            //print("X pressed");
			if(menuState == 2)
				result = ss.SpawnSiege ();
			if(menuState == 3)
				result = ss.researchATank();
        }
		if (Input.mousePosition.x > screenWidth-3*buttonWidth && Input.mousePosition.x < screenWidth-2*buttonWidth)
		{
			if (Input.mousePosition.y > 0 && Input.mousePosition.y < buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					//No GUI
				}
				else if (menuState == 2)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[9]);
				}
				else if (menuState == 3)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[9]);
				}
			}
		}
        startX += buttonWidth;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[10])) {
            //print("C pressed");
			if(menuState == 2)
				result = ss.SpawnAntiTank ();
        }
		if (Input.mousePosition.x > screenWidth-2*buttonWidth && Input.mousePosition.x < screenWidth-buttonWidth)
		{
			if (Input.mousePosition.y > 0 && Input.mousePosition.y < buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					//No GUI
				}
				else if (menuState == 2)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[10]);
				}
				else if (menuState == 3)
				{
					//No GUI
				}
			}
		}
        startX += buttonWidth;
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, labels[11])) {
            //print("V pressed");
            if (menuState == 2 || menuState == 3)
                result = ss.menuState = 1;
        }
		if (Input.mousePosition.x > screenWidth-buttonWidth && Input.mousePosition.x < screenWidth)
		{
			if (Input.mousePosition.y > 0 && Input.mousePosition.y < buttonHeight)
			{
				if (menuState == 0)
				{
					//No GUI
				}
				else if (menuState == 1)
				{
					//No GUI
				}
				else if (menuState == 2)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[11]);
				}
				else if (menuState == 3)
				{
					GUI.TextArea (new Rect (guiX, guiY, buttonWidth*4, buttonHeight*2), tips[11]);
				}
			}
		}
    }// end of OnGUI

}// end InGameGUI

// looping way of creating command box buttons
/*for (int i = 0; i < 4;++i) {
    startY = (3 * screenHeight) / 4;
    for (int j = 0; j < 3; ++j) {
        button = new Rect(startX, startY, buttonWidth, buttonHeight);
        if (GUI.Button(button, "ASS")) {
            print("button pressed");
        }

        startY += buttonHeight;
    }// end for
    startX += buttonWidth;
}// end for*/

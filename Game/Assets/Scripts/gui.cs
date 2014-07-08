using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {

	float buttonWidth, buttonHeight;
	private string GAME_NAME = "UPRISING_GAME";
	private string PW = "";
	private string MAP_NAME = "map1";
	private HostData[] hostList;
	
	// 0 = main menu, 1 = starting a server, 2 = searching for servers, 3 = options, 4 = waiting for client, 5 = waiting for host, 6 = how to play
	private int gameState = 0; 
	
	void Start()
	{
		GameObject.Find ("player_type").tag = "none";
		buttonWidth = 200;
		buttonHeight = 100;
		gameState = 0;
	}
	
	private void StartServer()
	{
		Network.incomingPassword = PW;
		Network.InitializeServer (2, 25002, !Network.HavePublicAddress ());
		MasterServer.RegisterHost (MAP_NAME, GAME_NAME);
		GameObject.Find ("player_type").tag = "master";
	}
	
	void OnServerInitialized()
	{
		GUI.TextArea (new Rect (500, 200, 325, 20), "SERVER INITIALIZED, WAITING FOR A PLAYER...");
	}
	
	void OnServerWaiting()
	{
		GUI.TextArea (new Rect (500, 200, 200, 20), "WAITING FOR HOST...");
	}
	
	void OnPlayerConnected(NetworkPlayer player)
	{
		Application.LoadLevel (MAP_NAME);
	}
	
	private void RefreshHostList()
	{
		MasterServer.RequestHostList (MAP_NAME);
	}
	
	private void HowToPlay()
	{
		
	}

	private void Credits()
	{
		Application.LoadLevel ("credits");
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived) {
			hostList = MasterServer.PollHostList ();
		}
	}
	
	private void JoinServer(HostData hostData, string pass)
	{
		Network.Connect (hostData, pass);
		GameObject.Find ("player_type").tag = "slave";
		Application.LoadLevel (MAP_NAME);
	}
	
	void OnGUI () {
		//if (!Network.isClient && !Network.isServer) {
		if (getState() == 0) //0 = main menu 
		{ 
			if (GUI.Button (new Rect (100, 600, buttonWidth, buttonHeight), "Create A Server")) { 
				setState(1);
			}
			if (GUI.Button (new Rect (550, 600, buttonWidth, buttonHeight), "Find A Server")) {
				setState(2);
				RefreshHostList ();
			}
			if (GUI.Button (new Rect (1000, 600, buttonWidth, buttonHeight), "Options")) {
				setState(3);
			}
		}
		else if (getState() == 1) // 1 = starting a server
		{
			//Server Name
			GUI.TextArea (new Rect (10, 10, 320, 20), "Please enter a Server Name in the field below");
			GAME_NAME = GUI.TextField(new Rect(10, 35, 320, 20), GAME_NAME, 25);
			//Password
			GUI.TextArea (new Rect (10, 80, 320, 20), "Please enter a password in the field below (optional)");
			PW = GUI.PasswordField(new Rect(10, 105, 320, 20), PW, "*"[0], 25);
			//Map Select
			GUI.TextArea (new Rect (1050, 10, 200, 20), "Please select a map to play");
			if (GUI.Button (new Rect (1050, 40, 200, 50), "DEFAULT SYSTEM")) { 
				MAP_NAME = "map1";
			}
			if (GUI.Button (new Rect (1050, 100, 200, 50), "TESTING PURPOSES ONLY")) { 
				MAP_NAME = "space!";
			}
			//Start Server
			if (GUI.Button (new Rect (300, 650, 200, 50), "Start Server")) { 
				setState(4);
				StartServer();
			}
			//Cancel
			if (GUI.Button (new Rect (50, 650, 200, 50), "Cancel")) { 
				setState(0);
			}
		}
		else if (getState() == 2) // 2 = searching for servers
		{
			//Password
			GUI.TextArea (new Rect (10, 10, 350, 20), "Please enter the password (Leave blank for no password)");
			PW = GUI.PasswordField(new Rect(10, 35, 350, 20), PW, "*"[0], 25);
			//Map Filter
			GUI.TextArea (new Rect (1050, 10, 200, 20), "Please select a map filter");
			if (GUI.Button (new Rect (1050, 40, 200, 50), "DEFAULT SYSTEM")) { 
				MAP_NAME = "map1";
			}
			if (GUI.Button (new Rect (1050, 100, 200, 50), "TESTING PURPOSES ONLY")) { 
				MAP_NAME = "space!";
			}
			//Available Servers
			GUI.TextArea (new Rect (500, 10, 300, 20), "Select after inputting the password & map");
			if (hostList != null) {
				for (int i = 0; i<hostList.Length; i++) {
					if (GUI.Button (new Rect (500, 35 + (30 * i), 300, 25), hostList[i].gameName)) {
						setState(5);
						JoinServer (hostList [i], PW);
					}
				}
			}
			//Refresh
			if (GUI.Button (new Rect (300, 650, 200, 50), "Refresh List")) { 
				RefreshHostList();
			}
			//Cancel
			if (GUI.Button (new Rect (50, 650, 200, 50), "Cancel")) { 
				setState(0);
			}
		}
		else if (getState() == 3) // 3 = options
		{
			if (GUI.Button (new Rect (550, 100, buttonWidth, buttonHeight), "How To Play")) {
				setState(6);
			}
			if (GUI.Button (new Rect (550, 300, buttonWidth, buttonHeight), "FatesUnited.com")) {
				Application.OpenURL("http://www.fatesunited.com/");
			}
			if (GUI.Button (new Rect (550, 500, buttonWidth, buttonHeight), "Credits")) {
				Credits();
			}

			if (GUI.Button (new Rect (50, 650, 200, 50), "Cancel")) { 
				setState(0);
			}
		}
		else if (getState() == 4) // 4 = waiting for client
		{
			OnServerInitialized();
			
			if (GUI.Button (new Rect (50, 650, 200, 50), "Cancel")) { 
				setState(0);
				Network.Disconnect();
				MasterServer.UnregisterHost();
			}
		}
		else if (getState() == 5) // 5 = waiting for host
		{
			OnServerWaiting();
			
			if (GUI.Button (new Rect (50, 650, 200, 50), "Cancel")) { 
				setState(0);
			}
			
			// Cancel join? Need to test this?
		}
		else if (getState() == 6) // 6 = How To Play
		{
			// HOW TO PLAY GUI
			
			if (GUI.Button (new Rect (50, 650, 200, 50), "Back To Options")) { 
				setState(3);
			}
			
			// Cancel join? Need to test this?
		}
	}
	
	private int getState()
	{
		return gameState;
	}
	
	private void setState(int state)
	{
		gameState = state;
	}

	void OnFailedToConnect(NetworkConnectionError error) {
		if (error == NetworkConnectionError.InvalidPassword) {
			Debug.Log("Invalid Password Entered");
		}
		else {
			Debug.Log("MADE IT");
		}

		Debug.Log("Could not connect to server because: " + error);
	}
}
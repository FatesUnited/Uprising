using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selector : MonoBehaviour {

	private Vector3 mouse_down_position;
	private Vector3 mouse_hold_position;
	/// <summary>
	/// The box_texture.
	/// </summary>
	public Texture box_texture;
	/// <summary>
	/// My selector.
	/// </summary>
	public GameObject mySelector;
	private bool draw_box;
	private bool do_select;
	private List<GameObject> selected = null;
	private List<GameObject> group1 = null;
	private List<GameObject> group2 = null;
	private List<GameObject> group3 = null;
	private List<GameObject> group4 = null;
	private List<GameObject> group5 = null;
	private bool control_down = false;

	// Use this for initialization
	void Start () {
	}

	void OnGUI()
	{
		if (Input.GetMouseButton (0) && draw_box) {
			if (mouse_down_position != null && mouse_hold_position != null) {
				Vector3 screen_down_pos = camera.WorldToScreenPoint (mouse_down_position);
				Vector3 screen_hold_pos = camera.WorldToScreenPoint (mouse_hold_position);
				GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 0.3f);
				GUI.DrawTexture( new Rect(Mathf.Min (screen_down_pos.x, screen_hold_pos.x), Screen.height - Mathf.Max (screen_down_pos.y, screen_hold_pos.y),
				                          Mathf.Abs (screen_down_pos.x - screen_hold_pos.x), Mathf.Abs (screen_down_pos.y - screen_hold_pos.y)), box_texture);
			}
		}
	}

	// Update is called once per frame
	void Update () {
        // left click select
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha1))
		{
			group1 = selected;
		}if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha2))
		{
			group2 = selected;
		}if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha3))
		{
			group3 = selected;
		}if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha4))
		{
			group4 = selected;
		}if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha5))
		{
			group5 = selected;
		}
		if (!Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha1))
		{
			Debug.Log ("1");
			if (group1 != null)
			{
				bool my_break = true;
				for (int i = 0; i < group1.Count; i++)
				{
					if (group1[i] != null)
					{
						my_break = false;
					}
				}
				if (!my_break)
				{
					selected = group1;
					((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).selected = group1;
				}
				GameObject[] selects;
				if (GameObject.FindWithTag("select") != null) {
					selects = GameObject.FindGameObjectsWithTag("select");
				}
				else
					selects = null;
				if (selects != null && GameObject.Find("player_type").tag == "slave")
				{
					foreach (GameObject select in selects)
					{
						select.transform.tag = "slave";
						((select_change)(select.GetComponent ("select_change"))).Unselect();
						if (select.transform.name == "ssp2(Clone)")
							select.transform.tag = "Spess Station";
					}// end foreach
				}// end if
				if (selects != null && GameObject.Find("player_type").tag == "master")
				{
					foreach (GameObject select in selects)
					{
						select.transform.tag = "master";
						((select_change)(select.GetComponent ("select_change"))).Unselect();
						if (select.transform.name == "ssp1(Clone)")
							select.transform.tag = "Spess Station";
					}// end for each
				}// end if
				for (int i = 0; i < selected.Count; i++)
				{
					selected[i].tag = "select";
					((select_change)(selected[i].GetComponent ("select_change"))).Select();
				}
			}
		}
		if (!Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Alpha2))
		{
			if (group2 != null)
			{
				bool my_break = true;
				for (int i = 0; i < group2.Count; i++)
				{
					if (group2[i] != null)
					{
						my_break = false;
					}
				}
				if (!my_break)
				{
					selected = group2;
					((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).selected = group2;
				}
				GameObject[] selects;
				if (GameObject.FindWithTag("select") != null) {
					selects = GameObject.FindGameObjectsWithTag("select");
				}
				else
					selects = null;
				if (selects != null && GameObject.Find("player_type").tag == "slave")
				{
					foreach (GameObject select in selects)
					{
						select.transform.tag = "slave";
						((select_change)(select.GetComponent ("select_change"))).Unselect();
						if (select.transform.name == "ssp2(Clone)")
							select.transform.tag = "Spess Station";
					}// end foreach
				}// end if
				if (selects != null && GameObject.Find("player_type").tag == "master")
				{
					foreach (GameObject select in selects)
					{
						select.transform.tag = "master";
						((select_change)(select.GetComponent ("select_change"))).Unselect();
						if (select.transform.name == "ssp1(Clone)")
							select.transform.tag = "Spess Station";
					}// end for each
				}// end if
				for (int i = 0; i < selected.Count; i++)
				{
					selected[i].tag = "select";
					((select_change)(selected[i].GetComponent ("select_change"))).Select();
				}
			}
		}
		if (!Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Alpha3))
		{
			if (group3 != null)
			{
				bool my_break = true;
				for (int i = 0; i < group3.Count; i++)
				{
					if (group3[i] != null)
					{
						my_break = false;
					}
				}
				if (!my_break)
				{
					selected = group3;
					((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).selected = group3;
				}
				GameObject[] selects;
				if (GameObject.FindWithTag("select") != null) {
					selects = GameObject.FindGameObjectsWithTag("select");
				}
				else
					selects = null;
				if (selects != null && GameObject.Find("player_type").tag == "slave")
				{
					foreach (GameObject select in selects)
					{
						select.transform.tag = "slave";
						((select_change)(select.GetComponent ("select_change"))).Unselect();
						if (select.transform.name == "ssp2(Clone)")
							select.transform.tag = "Spess Station";
					}// end foreach
				}// end if
				if (selects != null && GameObject.Find("player_type").tag == "master")
				{
					foreach (GameObject select in selects)
					{
						select.transform.tag = "master";
						((select_change)(select.GetComponent ("select_change"))).Unselect();
						if (select.transform.name == "ssp1(Clone)")
							select.transform.tag = "Spess Station";
					}// end for each
				}// end if
				for (int i = 0; i < selected.Count; i++)
				{
					selected[i].tag = "select";
					((select_change)(selected[i].GetComponent ("select_change"))).Select();
				}
			}
		}
		if (!Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Alpha4))
		{
			if (group4 != null)
			{
				bool my_break = true;
				for (int i = 0; i < group4.Count; i++)
				{
					if (group4[i] != null)
					{
						my_break = false;
					}
				}
				if (!my_break)
				{
					selected = group4;
					((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).selected = group4;
				}
				GameObject[] selects;
				if (GameObject.FindWithTag("select") != null) {
					selects = GameObject.FindGameObjectsWithTag("select");
				}
				else
					selects = null;
				if (selects != null && GameObject.Find("player_type").tag == "slave")
				{
					foreach (GameObject select in selects)
					{
						select.transform.tag = "slave";
						((select_change)(select.GetComponent ("select_change"))).Unselect();
						if (select.transform.name == "ssp2(Clone)")
							select.transform.tag = "Spess Station";
					}// end foreach
				}// end if
				if (selects != null && GameObject.Find("player_type").tag == "master")
				{
					foreach (GameObject select in selects)
					{
						select.transform.tag = "master";
						((select_change)(select.GetComponent ("select_change"))).Unselect();
						if (select.transform.name == "ssp1(Clone)")
							select.transform.tag = "Spess Station";
					}// end for each
				}// end if
				for (int i = 0; i < selected.Count; i++)
				{
					selected[i].tag = "select";
					((select_change)(selected[i].GetComponent ("select_change"))).Select();
				}
			}
		}
		if (!Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Alpha5))
		{
			if (group5 != null)
			{
				bool my_break = true;
				for (int i = 0; i < group5.Count; i++)
				{
					if (group1[5] != null)
					{
						my_break = false;
					}
				}
				if (!my_break)
				{
					selected = group5;
					((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).selected = group5;
				}
				GameObject[] selects;
				if (GameObject.FindWithTag("select") != null) {
					selects = GameObject.FindGameObjectsWithTag("select");
				}
				else
					selects = null;
				if (selects != null && GameObject.Find("player_type").tag == "slave")
				{
					foreach (GameObject select in selects)
					{
						select.transform.tag = "slave";
						((select_change)(select.GetComponent ("select_change"))).Unselect();
						if (select.transform.name == "ssp2(Clone)")
							select.transform.tag = "Spess Station";
					}// end foreach
				}// end if
				if (selects != null && GameObject.Find("player_type").tag == "master")
				{
					foreach (GameObject select in selects)
					{
						select.transform.tag = "master";
						((select_change)(select.GetComponent ("select_change"))).Unselect();
						if (select.transform.name == "ssp1(Clone)")
							select.transform.tag = "Spess Station";
					}// end for each
				}// end if
				for (int i = 0; i < selected.Count; i++)
				{
					selected[i].tag = "select";
					((select_change)(selected[i].GetComponent ("select_change"))).Select();
				}
			}
		}
		if ( Input.GetMouseButtonDown(0)){
			draw_box = false;
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);




			if (Physics.Raycast (ray,out hit, 100))
			{
				Vector3 mouse_check_position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
				Vector3 check_pos = camera.WorldToScreenPoint(mouse_check_position);

				if (check_pos.x <= Screen.width / 4 && check_pos.y <= Screen.height * 1 / 3)
				{
					//in minimap
					return;
				}
				if (check_pos.x >= Screen.width/4 && check_pos.y <= Screen.height *1 /4)
				{
					if (check_pos.x >= Screen.width/4 + 10 && check_pos.x <= Screen.width/4 + 150 &&
					    check_pos.y <= Screen.height *1/4 - 10 && check_pos.y >= Screen.height*1/4-70)
					{
						float x_stuff = check_pos.x - Screen.width/4 - 10;
						float y_stuff = -check_pos.y + Screen.height/4 - 10;
						int my_select_number = (int)(Mathf.Floor (y_stuff/20))*7 + (int)Mathf.Floor(x_stuff/20);
						if (((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).selected.Count > my_select_number)
							((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).select_select = my_select_number;
					}
					//in menu
					return;
				}
			}

			draw_box = true;
			((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).select_select = 0;
			((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).selected = null;
			selected = null;
			GameObject[] selects;
			if (GameObject.FindWithTag("select") != null) {
				selects = GameObject.FindGameObjectsWithTag("select");
			}
			else
				selects = null;
            if (selects != null && GameObject.Find("player_type").tag == "slave")
            {
                foreach (GameObject select in selects)
                {
					select.transform.tag = "slave";
					((select_change)(select.GetComponent ("select_change"))).Unselect();
                    if (select.transform.name == "ssp2(Clone)")
                        select.transform.tag = "Spess Station";
                }// end foreach
            }// end if
            if (selects != null && GameObject.Find("player_type").tag == "master")
            {
                foreach (GameObject select in selects)
                {
					select.transform.tag = "master";
					((select_change)(select.GetComponent ("select_change"))).Unselect();
					if (select.transform.name == "ssp1(Clone)")
                        select.transform.tag = "Spess Station";
                }// end for each
            }// end if

			if (Physics.Raycast (ray,out hit, 100)){	
				mouse_down_position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
				if (hit.collider.tag == "slave" && GameObject.Find("player_type").tag == "slave")
				{
					hit.collider.transform.tag = "select";
					((select_change)(hit.collider.GetComponent ("select_change"))).Select();
					List<GameObject> my_list = new List<GameObject>();
					my_list.Add(hit.collider.gameObject);
					selected = my_list;
					((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).selected = my_list;
				}
				if (hit.collider.tag == "master" && GameObject.Find ("player_type").tag == "master")
				{
					hit.collider.transform.tag = "select";
					((select_change)(hit.collider.GetComponent ("select_change"))).Select();
					List<GameObject> my_list = new List<GameObject>();
					my_list.Add(hit.collider.gameObject);
					selected = my_list;
					((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).selected = my_list;
				}
                if (hit.collider.name == "ssp1(Clone)" && GameObject.Find("player_type").tag == "master")
                {
					hit.collider.transform.tag = "select";
					((select_change)(hit.collider.GetComponent ("select_change"))).Select();
					List<GameObject> my_list = new List<GameObject>();
					my_list.Add(hit.collider.gameObject);
					selected = my_list;
					draw_box = false;
                    Debug.Log("SSP1 OnCLICK");
                }
                if (hit.collider.name == "ssp2(Clone)" && GameObject.Find("player_type").tag == "slave")
                {
					hit.collider.transform.tag = "select";
					((select_change)(hit.collider.GetComponent ("select_change"))).Select();
					List<GameObject> my_list = new List<GameObject>();
					my_list.Add(hit.collider.gameObject);
					selected = my_list;
					draw_box = false;
					Debug.Log("SSP2 OnCLICK");
				}
			}// end raycast if
		}// end left click select if

		if (Input.GetMouseButton (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray,out hit, 100)){
				mouse_hold_position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			}
		}


		if ( Input.GetMouseButtonUp(0)){

            string myTag = GameObject.Find("player_type").tag;
			int x = 0;
			List<GameObject> my_list = new List<GameObject>();
			foreach (GameObject ship in GameObject.FindGameObjectsWithTag(myTag))
			{
				if (draw_box &&
					ship.transform.position.x < Mathf.Max (mouse_down_position.x, mouse_hold_position.x) &&
				    ship.transform.position.z < Mathf.Max (mouse_down_position.z, mouse_hold_position.z) &&
				    ship.transform.position.x > Mathf.Min (mouse_down_position.x, mouse_hold_position.x) &&
				    ship.transform.position.z > Mathf.Min (mouse_down_position.z, mouse_hold_position.z)) {
					if (x == 20)
						break;
					ship.tag = "select";
					((select_change)(ship.GetComponent ("select_change"))).Select();
					Debug.Log ("Ship_name" + ship.name);
					x++;
					my_list.Add(ship);
				}
			}
			if (my_list.Count != 0)
			{
				((InGameGUI)(Camera.main.GetComponent("InGameGUI"))).selected = my_list;
				selected = my_list;
			}
		}

        // right click movement
		if (Input.GetMouseButtonDown (1) && GameObject.FindWithTag ("select") != null) {
			Debug.Log ("Passed intitial test");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 100))
			{
				if (hit.collider.name == "Plane")
				{
					Debug.Log ("Passed second test");
					GameObject[] selects = GameObject.FindGameObjectsWithTag ("select");
					foreach (GameObject select in selects)
					{
						Debug.Log ("Assigning move!");
						((movement)select.GetComponent ("movement")).destination = new Vector3(hit.point.x, 0, hit.point.z);
						((movement)select.GetComponent ("movement")).going = true;
						((movement)select.GetComponent ("movement")).following = false;
						((movement)select.GetComponent ("movement")).mining = false;
					}
				}

				// Right clicking on an enemy ship to attack and follow
				if (((hit.collider.tag == "slave" || hit.collider.name == "ssp2(Clone)") && GameObject.Find("player_type").tag == "master") || 
				    ((hit.collider.tag == "master" || hit.collider.name == "ssp1(Clone)") && GameObject.Find("player_type").tag == "slave"))
				{
					Transform targetShip = hit.collider.transform;

					GameObject[] selects = GameObject.FindGameObjectsWithTag ("select");
					foreach (GameObject select in selects)
					{
						if (select.name == "ssp1(Clone)" || select.name == "ssp2(Clone)")
						{
							continue;
						}
						((movement)select.GetComponent ("movement")).target = targetShip;
						((movement)select.GetComponent ("movement")).going = false;
						((movement)select.GetComponent ("movement")).mining = false;
						((movement)select.GetComponent ("movement")).following = true;
						Debug.Log("You are controlling the: " + GameObject.Find("player_type").tag + " And you are clicking on the: " + hit.collider.tag);
					}

					/*
					 * Follow enemy ship within a certain range
					 * Then Attack on a specific interval, maybe every 2 seconds to start out?
					 * 		Attack requires to spawn projectiles and fire them at the enemy
					 * 		Destroy object on collision with target
					 * 		On collision subtract HP
					 * 		At <= 0 HP, destroy target
					 */
				}

				if (hit.collider.tag == "asteroid")
				{
					Debug.Log ("asteroid hit!");
					GameObject[] selects = GameObject.FindGameObjectsWithTag ("select");
					foreach (GameObject select in selects)
					{
						Debug.Log ("Ships found!");
						movement myMovement = (movement)select.GetComponent ("movement");
						myMovement.going = false;
						myMovement.following = false;
						myMovement.mining = true;
						myMovement.asteroid = hit.collider.gameObject;
					}
				}
			}
		}
	}
}

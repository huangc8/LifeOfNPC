using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GameObject canvas;
	public GameObject NightMenu;
	public GameObject NightMenuPf;


	// Use this for initialization
	void Start () {
		OpenNightMenu ();
	}

	// open the night menu
	public void OpenNightMenu(){
		if (NightMenu == null) {
			NightMenu = Instantiate (NightMenuPf) as GameObject;
			NightMenu.transform.SetParent (canvas.transform, false);
		}
	}
}

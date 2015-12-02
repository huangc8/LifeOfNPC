﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMaster : MonoBehaviour {

	#region Data
	public static GameObject _GameMaster;
	public static GameObject NightMenu;
	public static GameObject DayPanel;
	public static int currentPhase;
	public GameObject canvas;
	public GameObject NightMenuPf;
	public GameObject DayPanelPf;
	public Image Background;
	#endregion

	#region Player Data
	public static int gold;
	public static int currentDay;
	#endregion

	// Use this for Debug
	void Start () {
		// Debug
		gold = 30;
		currentDay = 0;
		currentPhase = 1;
		ChangePhase ();
	}

	#region Player functions

	// add gold
	public static void AddGold(int quantity){
		gold += quantity;
		UpdateGoldDisplay ();
	}

	// reduce gold
	public static void ReduceGold(int quantity){
		gold -= quantity;
		UpdateGoldDisplay ();
	}

	// update gold display
	public static void UpdateGoldDisplay(){
		if (currentPhase == 0) {
			DayPanel.GetComponent<DayPanelScript> ().GoldLabel.text = gold.ToString();
		} else {

		}
	}

	// add days
	public void newDay(){
		currentDay++;
		ImportSupply ();
		OpenNightMenu ();
	}
	#endregion

	#region OpenMenu
	// open the night menu
	public void OpenNightMenu(){
		if (NightMenu == null) {
			NightMenu = Instantiate (NightMenuPf) as GameObject;
			NightMenu.GetComponent<NightMenuScript>()._Supply = this.GetComponent<Supply>();
			NightMenu.GetComponent<NightMenuScript>()._GameMaster = this;
			NightMenu.GetComponent<NightMenuScript>()._Inventory = this.GetComponent<Inventory>();
			NightMenu.transform.SetParent (canvas.transform, false);
		}
	}

	// close the night menu
	public void CloseNightMenu(){
		Destroy (NightMenu);
	}

	public void StartDayPhase(){
		DayPanel = Instantiate (DayPanelPf) as GameObject;
		DayPanel.GetComponent<DayPanelScript> ()._GameMaster = this;
		DayPanel.transform.SetParent (canvas.transform, false);
		UpdateGoldDisplay ();
		this.GetComponent<StartDialogScene> ().StartDayPhase ();
	}

	public void EndDayPhase(){
		Destroy (DayPanel);
		this.GetComponent<StartDialogScene> ().EndDayPhase ();
	}

	public void ChangePhase(){
		if (currentPhase == 0) {
			EndDayPhase ();
			ClearCanvas();
			currentPhase = 1;
			OpenNightMenu ();
			Background.sprite = Resources.Load<Sprite>("Sprite/backgroundCraftroom");
		} else {
			CloseNightMenu();
			ClearCanvas();
			currentPhase = 0;
			StartDayPhase();
			Background.sprite = Resources.Load<Sprite>("Sprite/backgroundStorefront");
		}
	}

	// clear the canvas
	public void ClearCanvas(){
		foreach (Transform child in canvas.transform) {
			if(child.name != "Background" && child.name != "EventSystem"){
				GameObject.Destroy(child.gameObject);
			}
		}
	}
	#endregion

	#region utility
	public void ImportSupply(){
		Supply _Supply = this.transform.GetComponent<Supply> ();

		// remove gold
		gold -= _Supply.sum;
		_Supply.sum = 0;

		// add items
		foreach (Item it in _Supply.supplyList) {
			if(it.amount > 0){
				Inventory.AddItem(it);
			}
		}
		_Supply.supplyList.Clear ();

		// stack the new supplies
		DataBase _DataBase = this.GetComponent<DataBase> ();
		_DataBase.stackSupply ();
	}
	#endregion
}

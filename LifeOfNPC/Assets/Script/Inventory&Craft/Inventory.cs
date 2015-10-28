using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	#region Data
	// Inventory Data
	public static Inventory _Inventory;			// reference to the class
	public static List<Item> _Items;			// current own item list
	public static GameObject InventoryPanel;	// Inventory Panel object
	public static GameObject canvas;			// the Canvas object
	public static GameObject SetPricePanel;		// the set price panel

	// Prefabs
	public static GameObject InventoryPanelPf;	// prefab for inventory panel
	public static GameObject SetPricePanelPf;	// set price panel
	public GameObject InventoryPanelPf_r;		// none static inventory panel
	public GameObject SetPricePanelPf_r;		// set price panel non static
	public GameObject canvas_r;					// none static canvas reference
	// utilities
	public static List<int> _RemoveIndex;		// removing item index
	#endregion

	// Use this for initialization
	void Start () {
		_Items = new List<Item>();
		_RemoveIndex = new List<int> ();
		InventoryPanelPf = InventoryPanelPf_r;
		SetPricePanelPf = SetPricePanelPf_r;
		canvas = canvas_r;
	}

	#region functions
	// Add an Item
	public static void AddItem(string name, int addAmount, string description){
		
		// increase exisitng item amount
		bool found = false;
		foreach(Item it in _Items){
			if(it.name == name){
				it.AddMore(addAmount);
				found = true;
				break;
			}
		}
		
		// add a new item
		if (found == false) {
			_Items.Add(new Item(name, addAmount, description));
		}
	}// end of CreateItem

	// Add an Item
	public static void AddItem(Item item){
		// increase exisitng item amount
		bool found = false;
		foreach(Item it in _Items){
			if(it.name == item.name){
				it.AddMore(item.amount);
				found = true;
				break;
			}
		}
		
		// add a new item
		if (found == false) {
			_Items.Add(new Item(item.name, item.amount, item.description));
		}
	}

	// Remove certain amount of item
	public static void RemoveItem(string name, int removeAmount){
		
		int currentIndex = 0;
		
		// decrease exisitng item amount
		foreach(Item it in _Items){
			if(it.name == name){
				it.RemoveMore(removeAmount);
				if(it.amount == 0){
					_RemoveIndex.Add(currentIndex);
				}
				break;
			}
			currentIndex++;
		}

		RemoveUpdate ();
	} // end of RemoveItem
	
	// Remove stuff schedule to remove
	public static void RemoveUpdate(){
		if (_RemoveIndex.Count != 0) {
			int j = 0;
			for(int i = 0; i < _RemoveIndex.Count; i++){
				_Items.RemoveAt(_RemoveIndex[i]-j);
				j++;
			}
			_RemoveIndex.Clear();
		}
	}// end of RemoveUpdate
	#endregion

	#region On Screen Inventory
	// opens up the inventory panel
	public void OpenInventoryPanel(){
		if (InventoryPanel == null) {
			InventoryPanel = Instantiate (InventoryPanelPf) as GameObject;
			InventoryPanel.GetComponent<InventoryPanelScript>()._Inventory = this;
			InventoryPanel.transform.SetParent (canvas.transform, false);
		}
		GetComponent<GameMaster>().CloseNightMenu ();
	}

	// close inventory
	public void CloseInventoryPanel(){
		if (InventoryPanel != null) {
			Destroy (InventoryPanel);
		}
		GetComponent<GameMaster>().OpenNightMenu ();
	}

	// get canvas reference
	public static GameObject getCanvas(){
		return canvas;
	}

	// open set price panel
	public void OpenSetPricePanel(){
		if (SetPricePanel == null) {
			SetPricePanel = Instantiate(SetPricePanelPf) as GameObject;
			SetPricePanel.GetComponent<SetPricePanelScript>()._Inventory = this;
			SetPricePanel.GetComponent<SetPricePanelScript>().PopulateSetPriceButton();
			SetPricePanel.transform.SetParent(canvas.transform, false);
		}
		GetComponent<GameMaster> ().CloseNightMenu ();
	}

	// close set price panel
	public void CloseSetPricePanel(){
		// update sell price in inventory
		GameObject contentPanel = SetPricePanel.GetComponent<SetPricePanelScript> ().contentPanel;		
		int index = 0;
		foreach (Transform gb in contentPanel.transform) {
			Inventory._Items[index].sellPrice = gb.GetComponent<PriceListButtonScript>().price;
			index++;
		}

		// destroy set price panel
		if (SetPricePanel != null) {
			Destroy(SetPricePanel);
		}
		GetComponent<GameMaster> ().OpenNightMenu ();
	}

	#endregion
}
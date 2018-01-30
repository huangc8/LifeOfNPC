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
	public static DataBase _DataBase;			// the database

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
	void Awake () {
		_Items = new List<Item>();
		_RemoveIndex = new List<int> ();
		_DataBase = this.GetComponent<DataBase> ();
		InventoryPanelPf = InventoryPanelPf_r;
		SetPricePanelPf = SetPricePanelPf_r;
		canvas = canvas_r;
	}

	#region functions
	// add item with data
	public static void AddItem(string name, int addAmount){
		// increase exisitng item amount
		bool found = false;
		if (_Items.Count > 0) {
			foreach (Item it in _Items) {
				if (it.name == name) {
					it.AddMore (addAmount);
					found = true;
					break;
				}
			}
		}
		// add a new item
		if (found == false) {
			string description = _DataBase.getDescription(name);
			int officalPrice = _DataBase.getOfficalPrice(name);
			int type = 0;
			AddItem(new Item(name, addAmount, description, officalPrice, type));
		}
	}
	
	// Add an Item
	public static void AddItem(string name, int addAmount, string description, int type){
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
			_Items.Add(new Item(name, addAmount, description, _DataBase.getOfficalPrice(name),type));
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
			_Items.Add(new Item(item.name, item.amount, item.description, item.supplyPrice, item.type));
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

	// get the item amount
	public static int getItemAmount(string name){
		// increase exisitng item amount
		foreach(Item it in _Items){
			if(it.name == name){
				return it.amount;
			}
		}
		return 0;
	}

	// get the item
	public static Item getItem(string name){
		// increase exisitng item amount
		foreach(Item it in _Items){
			if(it.name == name){
				return it;
			}
		}
		return null;
	}
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
			SetPricePanel.GetComponent<SetPricePanelScript>()._dataBase = this.GetComponent<DataBase>();
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
		foreach (Transform gb in contentPanel.transform) {
			int index = gb.GetComponent<PriceListButtonScript>().index;
			Inventory._Items[index].sellPrice = gb.GetComponent<PriceListButtonScript>().price;
		}

		// destroy set price panel
		if (SetPricePanel != null) {
			Destroy(SetPricePanel);
		}
		GetComponent<GameMaster> ().OpenNightMenu ();
	}

	#endregion
}
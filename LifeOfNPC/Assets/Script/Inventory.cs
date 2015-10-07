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

	// Prefabs
	public static GameObject InventoryPanelPf;	// prefab for inventory panel
	public GameObject InventoryPanelPf_r;		// none static inventory panel
	public GameObject canvas_r;					// none static canvas reference
	// utilities
	public static List<int> _RemoveIndex;		// removing item index
	#endregion

	// Use this for initialization
	void Start () {
		_Items = new List<Item>();
		_RemoveIndex = new List<int> ();
		InventoryPanelPf = InventoryPanelPf_r;
		canvas = canvas_r;
		Debugging ();
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

	// Make an Item on Screen
	public static void CreateObject(){

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
	void Debugging(){
		AddItem ("Apple", 1, "An Apple");
		AddItem ("Orange", 1, "An Orange");
	}

	// opens up the inventory panel
	public static void OpenInventoryPanel(){
		InventoryPanel = Instantiate (InventoryPanelPf) as GameObject;
		InventoryPanel.transform.SetParent (canvas.transform, false);
	}

	// close inventory
	public static void CloseInventoryPanel(){
		Destroy (InventoryPanel);
	}
	#endregion
}
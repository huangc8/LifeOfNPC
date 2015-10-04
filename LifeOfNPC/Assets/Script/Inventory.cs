using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public static Inventory _Inventory;		// reference to the class
	public static List<Item> _Items;		// current own item list
	public static List<int> _RemoveIndex;	// removing item index
	public GameObject itemObjectPf;			// prefab for item object

	// Use this for initialization
	void Start () {
		_Items = new List<Item>();
		_RemoveIndex = new List<int> ();
	}

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
}
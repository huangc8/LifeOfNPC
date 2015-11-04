using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;


public class Item : MonoBehaviour {

	// Item Class
	public string name;
	public int amount;
	public int type;					// item - 0, armor - 1, weapon - 2 
	public string description;
	public int sellPrice;
	public int supplyPrice;
		
	// constructor
	public Item (string name, int amount, string description){
		this.name = name;
		this.amount = amount;
		this.type = 0;
		this.description = description;
	}

	#region Display

	// display item with given item
	public void DisplayItem(Item it){
		this.name = it.name;
		this.amount = it.amount;
		this.description = it.description;
		this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/" + it.name);
		this.GetComponentInChildren<Text> ().text = amount.ToString ();
	}

	// update the display parts
	public void UpdateDisplay(){
		if (this.GetComponentInChildren<Text> ().text != null) {
			this.GetComponentInChildren<Text> ().text = amount.ToString ();
		}
	}

	#endregion

	#region functions
	// add more of this item
	public void AddMore(int amount){
		this.amount += amount;
	}
		
	// remove more of this item
	public void RemoveMore(int amount){
		this.amount -= amount;
	}

	public string GetName(){
		return this.name;
	}
	#endregion
}

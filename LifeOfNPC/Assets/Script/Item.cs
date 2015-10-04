using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour {

	// Item Class
	public string name;
	public int amount;
	public string description;
	public Sprite icon;
		
	// constructor
	public Item (string name, int amount, string description){
		this.name = name;
		this.amount = amount;
		this.description = description;
	}
		
	// add more of this item
	public void AddMore(int amount){
		this.amount += amount;
	}
		
	// remove more of this item
	public void RemoveMore(int amount){
		this.amount -= amount;
	}
}

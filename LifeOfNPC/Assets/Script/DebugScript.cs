using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class DebugScript : MonoBehaviour {

	void OnGUI(){
		/*
		if(GUI.Button(new Rect(10, 100, 100, 30), "Add Apple")){
			Inventory.AddItem("Apple", 1, "An Apple");
		}
		if(GUI.Button(new Rect(10, 135, 100, 30), "Remove Apple")){
			Inventory.RemoveItem("Apple", 1);
		}
		if (GUI.Button (new Rect (10, 170, 100, 30), "Add Orange")) {
			Inventory.AddItem("Orange", 1, "A Orange");
		}
		if (GUI.Button (new Rect (10, 205, 100, 30), "Remove Orange")) {
			Inventory.RemoveItem("Orange", 1);
		}
		if (GUI.Button (new Rect (10, 240, 100, 30), "Craft Banana")) {
			Craft.CraftItem(new Item("Apple", 1, "An Apple"), new Item("Apple", 1, "An Apple"),
			                new Item("Orange", 1, "A Orange"));
		}
        if (GUI.Button (new Rect (10, 275, 100, 30), "Add Recipe")){
			List<string> ltmp = new List<string> ();
			ltmp.Add("Apple");
			ltmp.Add("Apple");
			ltmp.Add("Orange");

			Craft.AddRecipe("Banana", ltmp, "A Banana");
		}
		*/
        if (GUI.Button(new Rect(10, 310, 100, 30), "Back"))
        {
			Inventory.CloseInventoryPanel();
        }

		if (GUI.Button (new Rect (10, 345, 100, 30), "Open")) {
			Inventory.OpenInventoryPanel();    
		}

        int pos = 100;
		int i = 0;
		int k = 35;
        //writes items and numbers to screen
		foreach (Item it in Inventory._Items) {
            GUI.Label(new Rect(300, (pos += i*k), 100, 30), it.name + " " + it.amount);
			i++;
		}
	}
}

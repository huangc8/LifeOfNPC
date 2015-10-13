using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class DebugScript : MonoBehaviour {

	void Start(){
		Inventory.AddItem ("Apple", 3, "An Apple");
		Inventory.AddItem ("Orange", 1, "An Orange");

		List<string> ltmp = new List<string> ();
		ltmp.Add("Apple");
		ltmp.Add("Apple");
		ltmp.Add("Orange");
		
		Craft.AddRecipe("Banana", ltmp, "A Banana");
	}

	void OnGUI(){

        if (GUI.Button(new Rect(10, 310, 100, 30), "BackInv"))
        {
			Inventory.CloseInventoryPanel();
        }

		if (GUI.Button (new Rect (10, 345, 100, 30), "OpenInv")) {
			Inventory.OpenInventoryPanel();    
		}

		if (GUI.Button (new Rect (120, 310, 100, 30), "OpenCrf")) {
			Craft.OpenCraftPanel();
		}

		if (GUI.Button (new Rect (120, 345, 100, 30), "BackCrf")) {
			Craft.CloseCraftPanel();
		}

	}
}
